using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    
    List<Listings> SearchResult;
    string terms;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetSearchTerms();
            DisplayResult();
        }
    }

    
    private void DisplayResult()
    {

        if (SearchResult.Count == 0)
        {
            lblRecentListingContainer.Text = "No items found";
            return;
        }

        string html = "";
        foreach (var item in SearchResult)
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
    private void GetSearchTerms()
    {
        if (Request.QueryString["terms"] == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }
        terms = Request.QueryString["terms"].ToString();

        SearchResult = Listings.GetAll(terms);

    }
}