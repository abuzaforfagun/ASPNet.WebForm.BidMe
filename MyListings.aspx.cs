using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    Users User;
    protected void Page_Load(object sender, EventArgs e)
    {
        string _user = "";
        if (Session["LoggedInuser"] != null)
            _user = Session["LoggedInuser"].ToString();
        else
        {
            Response.Redirect("Login.aspx");
            return;
        }
        int user;
        int.TryParse(_user, out user);
        User = new Users();
        User.Id = user;
        User.Get();

        if (!IsPostBack)
        {
            LoadListings();
        }
    }

    private void LoadListings()
    {
        List<Listings> YourListings = User.GetAllListing();
        if (YourListings.Count == 0)
        {
            PrintForNoItems();
            return;
        }

        string html = "";
        int sl = 1;
        foreach (var listing in YourListings)
        {
            html += "<tr>";

            html += "<td>";
            html += sl;
            html += "</td>";

            html += "<td>";
            html += "<img class='table-image' src = 'data/" + listing.ImageUrl + "'/>";
            html += "</td>";

            html += "<td>";
            html += listing.Title;
            html += "</td>";

            html += "<td>";
            html += listing.ListingCode;
            html += "</td>";

            html += "<td>";
            html += listing.Price;
            html += "</td>";
            
            html += "<td>";
            html += listing.TotalBids;
            html += "</td>";

            html += "<td>";
            html += listing.LowestBId;
            html += "</td>";

            html += "<td>";
            html += listing.LastDate.ToShortDateString();
            html += "</td>";

            

            html += "</tr>";

            sl++;
        }
        lblYourListingsContainer.Text = html;
    }


    void PrintForNoItems()
    {
        lblYourListingsContainer.Text = "<tr><td colspan='5'>No items available</td></tr>";
    }
}