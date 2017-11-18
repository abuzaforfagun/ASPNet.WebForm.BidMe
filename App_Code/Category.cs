using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Get()
    {
        string sql = "SELECT * FROM Category WHERE Id = " + Id;
        DataRow row = Db.getOne(sql);
        if(row.ItemArray.Count() >0)
        {
            Name = row["name"].ToString();
        }
    }

    public static List<Category> GetAll()
    {
        List<Category> Categories = new List<Category>();
        
        string sql = "SELECT * FROM Category";
        DataTable _categories = Db.getAll(sql);
        foreach (DataRow row in _categories.Rows)
        {
            Category category = new Category();
            var _id = row["id"].ToString();
            int id;
            int.TryParse(_id, out id);
            category.Id = id;
            category.Name = row["name"].ToString();
            
            Categories.Add(category);
        }

        return Categories;
    }

    public List<Listings> GetAllListings()
    {
        List<Listings> Listings = new List<Listings>();
        string sql;

        sql = "SELECT * FROM Listings WHERE categoryid = " + Id;
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
}