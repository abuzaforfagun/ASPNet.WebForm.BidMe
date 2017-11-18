using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayNavigationMenu();
            DisplayUserNavigation();
        }
    }

    void DisplayNavigationMenu()
    {
        List<Category> Categories = Category.GetAll();
        string html = listNavigation.InnerHtml;
        if (Categories.Count == 0)
            return;
        foreach (var cat in Categories)
        {
            html += "<li><a href = 'Category.aspx?id=" + cat.Id + "'>" + cat.Name + "</a></li>";
        }

        listNavigation.InnerHtml = html;
    }

    private void DisplayUserNavigation()
    {
        
        if(Session["LoggedInuser"] != null)
        {
            listUserNavigation.InnerHtml = @"<li><a href = 'dashboard.aspx'>My Account</a></li>
                                             <li><a href = 'logout.aspx'>Log Out</a></li>";
        }
        else
        {
            listUserNavigation.InnerHtml = "<li><a href = 'login.aspx'>Login</a></li>";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string keywords = "";
        keywords = txtSearch.Text;
        if (keywords == "")
            return;
        Response.Redirect("Search.aspx?terms=" + keywords);
    }
}
