using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HelperClass
/// </summary>
public static class HelperClass
{
    public static bool isCustomerLogin()
    {
        if (HttpContext.Current.Session["user"] != null)
        {
            return true;
        }
        else
            return false;
    }

    public static Users GetLoggedInUser()
    {
        Users user = new Users();
        if (HttpContext.Current.Session["user"] != null)
        {
            var _userId = HttpContext.Current.Session["user"].ToString();
            int id;
            int.TryParse(_userId, out id);
            user.Id = id;
            user.Get() ;
        }
        else
        {
            user = null;
        }
        return user;
    }
}