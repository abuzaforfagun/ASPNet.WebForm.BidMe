using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Listings
/// </summary>
public class Listings
{
    public int Id { get; set; }
    public int ListingCode { get; set; }
    public string Title { get; set; }
    public Category Category { get; set; }
    public Users User { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime LastDate { get; set; }
    public string ImageUrl { get; set; }
    public string Location { get; set; }

    public int TotalBids
    {
        get
        {
            return GetTotalBids();
        }
    }

    public string Status
    {
        get
        {
            if (LastDate >= DateTime.Now)
                return "Open";
            else
                return "Close";
        }
    }

    public int LowestBId
    {
        get
        {
            return GetLowestBid();
        }

    }

    private int GetLowestBid()
    {
        string sql = "SELECT MIN(price) as Price from Bids Where listingid = " + Id;
        DataRow row = Db.getOne(sql);
        int Result = 0;
        if (!row.IsNull(0))
        {
            var _result = row["Price"].ToString();
            int.TryParse(_result, out Result);
        }
        return Result;
    }

    private int GetTotalBids()
    {
        string sql = "SELECT COUNT(*) as Count FROM BIDS WHERE LISTINGID = " + Id;
        DataRow row = Db.getOne(sql);
        int count = 0;
        if (!row.IsNull(0))
        {
            var _count = row["count"].ToString();
            int.TryParse(_count, out count);
        }
        return count;
    }


    public Listings()
    {
        Category = new Category();
        User = new Users();
    }

    public Listings(int ListingCode, string Title, int CategoryId, int UserId, int Price, 
        string Description, string Location, DateTime LastDate, string ImageUrl)
    {
        this.ListingCode = ListingCode;
        this.Title = Title;
        this.Category = new Category();
        this.Category.Id = CategoryId;
        this.User = new Users();
        this.User.Id = UserId;
        this.Description = Description;
        this.Price = Price;
        this.AddedDate = DateTime.Now;
        this.LastDate = LastDate;
        this.ImageUrl = ImageUrl;
        this.Location = Location;
    }

    public void Add()
    {
        Description = Description.Replace("'", "''");
        string sql = @"INSERT INTO Listings (ListingCode, Title, CategoryId, SellerId, Price, Location, Description,
                        AddedDate, LastDate, ImageUrl) VALUES
                        (" + ListingCode + ", '" + Title + "', " + Category.Id + "," + User.Id + ", " + Price +", '" + Location + "','" + 
                        Description + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "','"+ LastDate.ToString("yyyy-MM-dd") +"','"+ImageUrl+"')";

        Db.execute(sql);
    }

    public void Get()
    {
        string sql = "SELECT * FROM Listings WHERE id = " + Id;
        DataRow row = Db.getOne(sql);

        if (row.ItemArray.Count() == 0)
            return;
        if (row != null)
        {
            var _listingCode = row["ListingCode"].ToString();
            int listCode;
            int.TryParse(_listingCode, out listCode);
            ListingCode = listCode;
            Title = row["Title"].ToString();

            var _catId =  row["CategoryId"].ToString();
            int catId;
            int.TryParse(_catId, out catId);
            Category.Id = catId;
            Category.Get();

            var _userId = row["SellerId"].ToString();
            int userId;
            int.TryParse(_userId, out userId);
            User.Id = userId;

            Description = row["description"].ToString();
            var _price = row["Price"].ToString();
            int price;
            int.TryParse(_price, out price);
            Price = price;

            var _addedDate = row["AddedDate"].ToString();
            AddedDate = Convert.ToDateTime(_addedDate);

            var _lastDate = row["lastDate"].ToString();
            LastDate = Convert.ToDateTime(_lastDate);

            ImageUrl = row["ImageUrl"].ToString();
        }

    }

    public static List<Listings> GetAll(string terms = "")
    {
        List<Listings> Listings = new List<Listings>();
        string sql;
        int listingCode;
        int.TryParse(terms, out listingCode);
        if (terms == "")
            sql = "SELECT * FROM Listings";
        else
            sql = "SELECT * FROM Listings WHERE title like '%" + terms + "%' OR ListingCode = "+ listingCode;
        DataTable _categories = Db.getAll(sql);
        foreach (DataRow row in _categories.Rows)
        {
            Listings listing = new Listings();
            var _id = row["id"].ToString();
            int id;
            int.TryParse(_id, out id);
            listing.Id = id;
            listing.Get();

            Listings.Add(listing);
        }

        return Listings;
    }

   

    public Bids GetMinimumBid()
    {
        string sql = "SELECT Bids.*, MIN(Price) FROM Bids WHERE listingid = " + Id;
        Bids Bid = new Bids();
        DataRow row = Db.getOne(sql);

        if (!row.IsNull(0))
        {

            var _listingId = row["listingid"].ToString();
            int listingId;
            int.TryParse(_listingId, out listingId);
            Bid.Listing = new Listings();
            Bid.Listing.Id = listingId;

            var _userId = row["userid"].ToString();
            int userId;
            int.TryParse(_userId, out userId);
            Bid.User = new Users();
            Bid.User.Id = userId;

            var _price = row["price"].ToString();
            int price;
            int.TryParse(_price, out price);
            Bid.Price = price;

            var dateTime = row["datetime"].ToString();
            Bid.DateTime = Convert.ToDateTime(dateTime);

        }
        return Bid;
    }

    public static List<Listings> Search(string KeyWords)
    {
        List<Listings> Listings = GetAll(KeyWords);
        return Listings;
    }

    public static List<Listings> GetLastListing(int limit)
    {
        string sql = "SELECT TOP " + limit + " * FROM Listings ORDER BY Id DESC ";
        List<Listings> items = new List<Listings>();
        DataTable dt = Db.getAll(sql);
        if (dt.Rows.Count == 0)
            return items;
        foreach (DataRow row in dt.Rows)
        {

            if (!row.IsNull(0))
            {
                Listings listing = new Listings();
                var _id = row["Id"].ToString();
                int id;
                int.TryParse(_id, out id);
                listing.Id = id;
                var _listingCode = row["ListingCode"].ToString();
                int listCode;
                int.TryParse(_listingCode, out listCode);
                listing.ListingCode = listCode;
                listing.Title = row["Title"].ToString();

                var _catId = row["CategoryId"].ToString();
                int catId;
                int.TryParse(_catId, out catId);
                listing.Category.Id = catId;

                var _userId = row["SellerId"].ToString();
                int userId;
                int.TryParse(_userId, out userId);
                listing.User.Id = userId;

                listing.Description = row["description"].ToString();
                var _price = row["Price"].ToString();
                int price;
                int.TryParse(_price, out price);
                listing.Price = price;

                var _addedDate = row["AddedDate"].ToString();
                listing.AddedDate = Convert.ToDateTime(_addedDate);

                var _lastDate = row["lastDate"].ToString();
                listing.LastDate = Convert.ToDateTime(_lastDate);

                listing.ImageUrl = row["ImageUrl"].ToString();

                items.Add(listing);
            }
        }
        return items;
    }
}