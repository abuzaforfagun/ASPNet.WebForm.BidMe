using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AuthenticationService
/// </summary>
public class AuthenticationService
{
    private readonly string email;
    private readonly string password;

    public AuthenticationService(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public bool IsLoginSuccess()
    {
        string sql = "SELECT id from Users WHERE email = '" + email + "' and password = '" + password + "'";
        DataRow row = Db.getOne(sql);
        if (row.ItemArray.Count() > 0)
        {
            string _id;
            _id = row[0].ToString();
            string key = "user";
            HttpContext.Current.Session[key] = _id;
            HttpContext.Current.Session["LoggedInuser"] = _id;
            return true;
        }

        return false;
    }
}
