using System;
using System.Collections.Generic;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public bool isUserLoggedIn = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayNavigationMenu();
            isUserLoggedIn = Session["LoggedInuser"] != null;
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
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string keywords = "";
        keywords = txtSearch.Text;
        if (keywords == "")
            return;
        Response.Redirect("Search.aspx?terms=" + keywords);
    }
}
