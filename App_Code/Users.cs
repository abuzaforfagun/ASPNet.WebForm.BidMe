using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Location { get; set; } // null for buyer
    public int UserType { get; set; } // 0 for buyer and 1 for seller


    public Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Users(string Name, string Email, string Password, bool isSeller, string Location = "")
    {
        this.Name = Name;
        this.Email = Email;
        this.Password = Password;
        if (isSeller)
            UserType = 1;
        else
            UserType = 0;
        this.UserType = UserType;
        this.Location = Location;
    }

    public void Add()
    {
        string sql = @"INSERT INTO Users (name, email, password, usertype, location) VALUES 
                        ('" + Name + "', '" + Email + "', '" + Password + "', " + UserType + ",'" + Location + "')";

        Db.execute(sql);

    }

    public void Get()
    {
        string sql = "SELECT * FROM USERS WHERE id = " + Id;
        DataRow row = Db.getOne(sql);
        if (!row.IsNull(0))
        {
            Name = row["name"].ToString();
            Email = row["email"].ToString();
            Password = row["password"].ToString();
            Location = row["location"].ToString();
            var userType = row["usertype"].ToString();
            int _userType;
            int.TryParse(userType, out _userType);
            UserType = _userType;
        }

    }

    public static bool isEmailAdded(string Email)
    {
        string sql = "SELECT count(id) as count FROM Users where email = '" + Email + "';";
        DataTable table = new DataTable();
        table = Db.getAll(sql);
        DataRow row = table.Rows[0];
        if(row["count"].ToString() == "0")
        {
            return false;
        }
        return true;
        
    }

    public List<Bids> ChanceToWin()
    {
        string sql = @"SELECT * FROM LISTINGS WHERE LastDate >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";

        DataTable ListingTable = Db.getAll(sql);
        List<Bids> chanceToWin = new List<Bids>();
        foreach (DataRow row in ListingTable.Rows)
        {
            var listingId = row["id"].ToString();
            
            sql = "SELECT MIN(Price) as min FROM BIDS WHERE listingid = " + listingId;
            DataRow MinimumPrice = Db.getOne(sql);
            var _minimumPrice = MinimumPrice["min"].ToString();
            if (_minimumPrice == "")
                _minimumPrice = "0";
            sql = "SELECT * FROM Bids WHERE listingid = " + listingId + " and UserId = " + Id + " and Price = "+_minimumPrice;
            DataRow chanceToWinRow = Db.getOne(sql);
            if(chanceToWinRow.ItemArray.Count() > 0)
            {
                sql = "SELECT * FROM Bids Where listingId = " + listingId + " and UserId = " + Id;
                DataRow bidrow = Db.getOne(sql);
                var _bidId = bidrow["id"].ToString();
                int bidId = Convert.ToInt32(_bidId);

                Bids bid = new Bids();
                bid.Id = bidId;
                bid.Get();
                chanceToWin.Add(bid);
            }

        }
        return chanceToWin;
    }


    public List<Bids> BidsIWon()
    {
        string sql = @"SELECT * FROM [bidme].[dbo].LISTINGS WHERE LastDate <= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
        
        DataTable ListingTable = Db.getAll(sql);
        List<Bids> chanceToWin = new List<Bids>();
        foreach (DataRow row in ListingTable.Rows)
        {
            var listingId = row["id"].ToString();

            sql = "SELECT MIN(Price) as min FROM BIDS WHERE listingid = " + listingId;
            DataRow MinimumPrice = Db.getOne(sql);
            var _minimumPrice = MinimumPrice["min"].ToString();
            if (_minimumPrice == "")
                continue;
            sql = "SELECT * FROM [BidMe].[dbo].Bids WHERE listingid = " + listingId + " and UserId = " + Id + " and Price = " + _minimumPrice;
            DataRow chanceToWinRow = Db.getOne(sql);
            if (chanceToWinRow.ItemArray.Count() > 0)
            {
                sql = "SELECT * FROM [BidMe].[dbo].Bids Where listingId = " + listingId + " and UserId = " + Id;
                DataRow bidrow = Db.getOne(sql);
                var _bidId = bidrow["id"].ToString();
                int bidId = Convert.ToInt32(_bidId);

                Bids bid = new Bids();
                bid.Id = bidId;
                bid.Get();
                chanceToWin.Add(bid);
            }

        }
        return chanceToWin;
    }

    public List<Bids> AlreadyWin()
    {
        string sql = "SELECT Bids.*, MIN(Price) FROM Bids WHERE UserId = " + Id + " and DateTime < '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
        DataTable BidsTable = Db.getAll(sql);
        List<Bids> Bids = new List<Bids>();
        foreach (DataRow row in BidsTable.Rows)
        {
            Bids Bid = new Bids();
            var _id = row["id"].ToString();
            int id;
            int.TryParse(_id, out id);
            Bid.Id = id;

            Bid.Get();
            Bids.Add(Bid);
        }
        return Bids;
    }


    public List<Bids> AppliedFor()
    {
        List<Bids> Bids = new List<Bids>();
        string sql = "SELECT * FROM Bids WHERE UserId = " + Id;
        DataTable BidsTable = Db.getAll(sql);
        foreach (DataRow row in BidsTable.Rows)
        {
            Bids Bid = new Bids();
            var _id = row["id"].ToString();
            int id;
            int.TryParse(_id, out id);
            Bid.Id = id;

            Bid.Get();
            Bids.Add(Bid);
        }
        return Bids;
    }

    public  List<Listings> GetAllListing()
    {
        List<Listings> Listings = new List<Listings>();

        string sql = "SELECT * FROM Listings WHERE SellerId = " + Id;
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

    public Bids GetMyBid(int ListingId)
    {
        string sql = "SELECT * FROM Bids WHERE listingid = " + ListingId + " and Userid = " + Id;
        DataRow row = Db.getOne(sql);

        Bids bid = new Bids();
        if (row.ItemArray.Count() > 0)
        {
            var _id = row["id"].ToString();
            int id;
            int.TryParse(_id, out id);
            bid.Id = id;

            var _listingId = row["listingid"].ToString();
            int listingid;
            int.TryParse(_listingId, out listingid);
            bid.Listing = new Listings();
            bid.Listing.Id = listingid;
            bid.Listing.Get();

            var _userid = row["userid"].ToString();
            int userid;
            int.TryParse(_userid, out userid);
            bid.User = this;

            var _price = row["price"].ToString();
            int price;
            int.TryParse(_price, out price);
            bid.Price = price;

            var date = row["datetime"].ToString();
            bid.DateTime = Convert.ToDateTime(date);
            return bid;
        }
        bid = null;
        return bid;
    }
}