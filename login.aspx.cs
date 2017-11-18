using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{

    string email;
    string password;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["RegistrationMessage"] != null)
        {
            if(Session["RegistrationMessage"].ToString() == "Success")
            {
                lblRegistrationSuccess.Text = "Registration Complete! Please log in with email and password.";
                Session.Remove("RegistrationMessage");
            }
        }

        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblRegistrationSuccess.Text = lblWarning.Text = "";
        if (!isValidInputs())
            return;
        Users user = Users.tryLogin(email, password);
        if (user == null)
        {
            lblWarning.Text = "Wrong Email/Password";
            return;
        }

        Session["LoggedInuser"] = user.Id;
        Response.Redirect("Default.aspx");
    }

    private bool isValidInputs()
    {
        if(txtEmail.Text == "" || txtPassword.Text == "")
        {
            lblWarning.Text = "Please enter email and password";
            return false;
        }

        email = txtEmail.Text;
        password = txtPassword.Text;
        return true;
        
    }
}