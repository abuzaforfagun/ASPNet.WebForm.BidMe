using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bids
/// </summary>
public class Bids
{
    public int Id { get; set; }
    public Listings Listing { get; set; }
    public Users User { get; set; }
    public int Price { get; set; }
    public DateTime DateTime { get; set; }

    public Bids()
    {
        User = new Users();
        Listing = new Listings();
    }
    public Bids(Listings Listing, Users User, int Price)
    {
        this.Listing = Listing;
        this.User = User;
        this.Price = Price;
        this.DateTime = DateTime.Now;
    }

    
    public void Add()
    {
        string format = "yyyy-MM-dd HH:mm:ss";
        string sql = "INSERT INTO Bids (ListingId, UserId, price, DateTime) VALUES (" + Listing.Id + "," + User.Id + "," + Price + ", '"+Convert.ToDateTime(DateTime)+"')";
        
        Db.execute(sql);
    }

    public void Get()
    {
        
        string sql = "SELECT * FROM Bids WHERE id = " + Id;
        DataRow row = Db.getOne(sql);
        
        if (!row.IsNull(0))
        {
            
            var _listingId = row["listingid"].ToString();
            int listingId;
            int.TryParse(_listingId, out listingId);
            Listing = new Listings();
            Listing.Id = listingId;
            Listing.Get();

            var _userId = row["userid"].ToString();
            int userId;
            int.TryParse(_userId, out userId);
            User = new Users();
            User.Id = userId;

            var _price = row["price"].ToString();
            int price;
            int.TryParse(_price, out price);
            Price = price;

            var dateTime = row["datetime"].ToString();
            DateTime = Convert.ToDateTime(dateTime);
            
        }
    }


    

    public List<Bids> GetByListingId(int ListingId)
    {
        List<Bids> Bids = new List<Bids>();
        string sql = "SELECT * FROM Bids WHERE ListingId = " + ListingId;
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

    public static bool isUserAlreadyBid(int ListingId, Users User)
    {
        string sql = "SELECT * FROM Bids WHERE listingid = " + ListingId + " and Userid = "+User.Id;
        DataRow row = Db.getOne(sql);

        if (row.ItemArray.Count() >0)
        {
            return true;
        }
        return false;
    }

    



    public static bool isAvailableForBid(Listings listing)
    {
        var CurrentDate = new DateTime();
        CurrentDate = DateTime.Now;
        if (CurrentDate > listing.LastDate)
            return false;
        else
            return true;
    }

}