using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    Listings item;
    Users User;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            User = HelperClass.GetLoggedInUser();
            lblDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            item = new Listings();
            GetListing();
            DisplayProduct();
            InitialDisplay();
            DisplayForLoggedInUsers();
        }
        
    }
    private void GetListing()
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }
        var _id = Request.QueryString["id"].ToString();
        int id;
        int.TryParse(_id, out id);
        item = new Listings();
        item.Id = id;
        item.Get();
    }
    void DisplayProduct()
    {
        lblTitle.Text = item.Title;
        lblCategory.Text = item.Category.Name;
        lblAskingPrice.Text = item.Price.ToString();
        lblDescription.Text = item.Description;
        lblListingCode.Text = item.ListingCode.ToString();
        lblTotalBid.Text = item.TotalBids.ToString();
        lblLastDate.Text = item.LastDate.ToString("yyyy-MM-dd");
        imgItem.Src = "data/" + item.ImageUrl;
        

    }

    private void InitialDisplay()
    {
        divForAlreadyBid.Style.Add("Display", "None");
        divForLoggedInuser.Style.Add("Display", "None");
        divDeadline.Style.Add("Display", "None");
    }
    private void DisplayForLoggedInUsers()
    {
        if (Session["LoggedInuser"] != null)
        {
            if (!Bids.isAvailableForBid(item))
            {
                divDeadline.Style.Add("display", "block");
                divForGuest.Style.Add("display", "none");
                return;
            }
            divForLoggedInuser.Style.Add("Display", "Block");
            divForGuest.Style.Add("Display", "None");
            
            if (Bids.isUserAlreadyBid(item.Id, User))
            {

                DisplayForAlreadyBid();
            }
        }
        
    }

    private void DisplayForDeadlineReached()
    {

    }

    private void DisplayForAlreadyBid()
    {
        var Bid = User.GetMyBid(item.Id);
        lblYourBid.Text = Bid.Price.ToString();
        divForLoggedInuser.Style.Add("Display", "None");
        divForAlreadyBid.Style.Add("Display", "Block");
    }

    protected void btnBidNow_Click(object sender, EventArgs e)
    {
        if (item == null)
            GetListing();

        Users user = HelperClass.GetLoggedInUser();
        var _price = txtYourBudget.Text;
        int price;
        int.TryParse(_price, out price);
        Bids bid = new Bids(item, user, price);
        bid.Add();

        Response.Redirect("Single.aspx?id=" + item.Id);
    }
}