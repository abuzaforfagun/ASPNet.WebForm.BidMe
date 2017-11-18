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
        if (!IsPostBack)
        {
            LoadCateogries();
            
        }
    }

    void GetUser()
    {
        string _user;
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
    }

    void LoadCateogries()
    {
        List<Category> Categories = Category.GetAll();
        ddlCategory.Items.Add(new ListItem("Select Category", "-1"));
        foreach(var cat in Categories)
        {
            ListItem item = new ListItem(cat.Name, cat.Id.ToString());
            ddlCategory.Items.Add(item);
        }
    }

    protected void btnSaveListing_Click(object sender, EventArgs e)
    {
        GetUser();
        var _listingCode = txtItemCode.Text;
        int listingCode;
        int.TryParse(_listingCode, out listingCode);

        var title = txtTitle.Text;

        var _categoryId = ddlCategory.SelectedValue;
        int categoryId;
        int.TryParse(_categoryId, out categoryId);

        var _price = txtPrice.Text;
        int price;
        int.TryParse(_price, out price);

        string imageUrl = "";
        if (uploadImage.HasFiles)
        {

            var uploadFile = uploadImage.PostedFile;
            string _filename = listingCode.ToString();
            string path = System.IO.Path.Combine(Server.MapPath("~/data/"), _filename + uploadFile.FileName);
            uploadFile.SaveAs(path);
            var fileUrl = _filename + uploadFile.FileName;
            imageUrl = fileUrl;
            
        }

        var description = txtDescripiton.Text;
        var location = txtLocation.Text;
        var _lastDate = txtLastDate.Text;
        DateTime lastDate;
        lastDate =Convert.ToDateTime(_lastDate);


        Listings Listing = new Listings(listingCode, title, categoryId, User.Id, price, description, location, lastDate, imageUrl);
        Listing.Add();

        Session["listingAdded"] = "New listing successfully added";
        Response.Redirect("AddNew.aspx");
    }
}