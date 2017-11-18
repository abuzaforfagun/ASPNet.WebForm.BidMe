using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    Category cat;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCategory();
            DisplayCategory();
        }
    }

    private void DisplayCategory()
    {
        if (cat == null)
            GetCategory();

        lblCategoryTitle.InnerText = cat.Name;

        List<Listings> items = cat.GetAllListings();
        if (items.Count == 0)
        {
            lblRecentListingContainer.Text = "No items found";
            return;
        }
            
        string html = "";
        foreach(var item in items)
        {
            html += @"
                <div class='col-md-3 gallery-grid '>
                    <a href = 'single.aspx?id=" + item.Id + @"'>
                        <img src = 'data/" + item.ImageUrl + @"' class='img-responsive'/>
                        <div class='gallery-info'>
                            <div class='quick'>
                                <p><span class='glyphicon glyphicon-eye-open' aria-hidden='true'></span>view</p>
                            </div>
                        </div>
                    </a>
                    <div class='galy-info'>
                        <p>" + item.Title + @"</p>
                        <div class='galry'>
                            <div class='prices'>
                                <h5 class='item_price'>£ " + item.Price + @"</h5>
                            </div>
                            <div class='clearfix'></div>
                        </div>
                    </div>
                </div>
                ";
        }

        lblRecentListingContainer.Text = html;
    }

    private void GetCategory()
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }
        var _id = Request.QueryString["id"].ToString();
        int id;
        int.TryParse(_id, out id);
        cat = new Category();
        cat.Id = id;
        cat.Get();
    }
}