using System;

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

        var authService = new AuthenticationService(email, password);
        if (authService.IsLoginSuccess())
        {
            Response.Redirect("Default.aspx");
            return;
        }
        lblWarning.Text = "Wrong Email/Password";
        return;
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