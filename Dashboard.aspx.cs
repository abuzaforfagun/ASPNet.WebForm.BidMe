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
            LoadBids();
        }
    }

    private void LoadBids()
    {
        List<Bids> YourBids = User.AppliedFor();
        if (YourBids.Count == 0)
        {
            PrintForNoItems();
            return;
        }
            
        string html = "";
        int sl = 1;
        foreach(var bid in YourBids)
        {
            html += "<tr>";

            html += "<td>";
            html += sl;
            html += "</td>";

            html += "<td>";
            html += "<img class='table-image' src = 'data/" + bid.Listing.ImageUrl + "'/>";
            html += "</td>";

            html += "<td>";
            html += bid.Listing.Title;
            html += "</td>";

            html += "<td>";
            html += bid.Listing.ListingCode;
            html += "</td>";

            html += "<td>";
            html += bid.Listing.Price;
            html += "</td>";

            html += "<td>";
            html += bid.Price;
            html += "</td>";

            html += "<td>";
            html += bid.Listing.TotalBids;
            html += "</td>";

            html += "<td>";
            html += bid.Listing.Status;
            html += "</td>";

            html += "</tr>";

            sl++;
        }
        lblYourBidsContainer.Text = html;
    }

    void PrintForNoItems()
    {
        lblYourBidsContainer.Text = "<tr><td colspan='5'>No items available</td></tr>";
    }
}