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
            if (Session["LoggedInuser"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            
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
        var userid = Session["LoggedInuser"].ToString();
        int _userId;
        int.TryParse(userid, out _userId);
        Users User = new Users();
        User.Id = _userId;
        User.Get();
        if(User.UserType == 0)
        {
            sideMenuForSeller.Style.Add("display", "none");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}
