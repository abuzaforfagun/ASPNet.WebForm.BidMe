using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadFeatureBanner();
        LoadRecentItems();
    }

    private void LoadFeatureBanner()
    {
        string html = "";
        List<Listings> RecentItems = Listings.GetLastListing(1);
        var item = RecentItems[0];
        lblBannerTitle.Text = item.Title;
        lblDescription.Text = item.Description;
        imgBanner.Src = "data/" + item.ImageUrl;
        anchorBannerProductLink.HRef = "Single.aspx?id=" + item.Id;
    }

    private void LoadRecentItems()
    {
        string html = "";
        List<Listings> RecentItems = Listings.GetLastListing(8);

        foreach(var item in RecentItems)
        {
            html += @"
                <div class='col-md-3 gallery-grid '>
                    <a href = 'single.aspx?id=" + item.Id + @"'>
                        <img src = 'data/" + item.ImageUrl +@"' class='img-responsive'/>
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
}