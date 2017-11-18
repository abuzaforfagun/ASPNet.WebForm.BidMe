using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    string name;
    string email;
    string location;
    string password;
    bool isSeller;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnRegistrations_Click(object sender, EventArgs e)
    {
        if (!CheckInputs())
            return;

        name = txtName.Text;
        email = txtEmail.Text;
        location = txtLocation.Text;
        password = txtPassword.Text;
        isSeller = chkSeller.Checked;

        if (CheckEmail())
        {
            return;
        }
        Users user = new Users(name, email, password, isSeller, location);
        user.Add();
        Session["RegistrationMessage"] = "Success";
        Response.Redirect("login.aspx");
    }

    private bool CheckInputs()
    {
        string errorList = "";
        bool isValid = true;
        if(txtName.Text == "")
        {
            isValid = false;
            errorList += "Please enter your name.<br/>";
        }
        if(txtEmail.Text == "")
        {
            isValid = false;
            errorList += "Please enter your email.<br/>";
        }
        if(txtPassword.Text == "")
        {
            isValid = false;
            errorList += "Please enter a password. <br/>";
        }

        lblErrors.Text = errorList;
        return isValid;
    }

    private bool CheckEmail()
    {
        bool isExist = false;
        if (Users.isEmailAdded(email))
        {
            isExist = true;
            string errorList = "Email already exist.";
            lblErrors.Text = errorList;
        }
        
        return isExist;
    }
}