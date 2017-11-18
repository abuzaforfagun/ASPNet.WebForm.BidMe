using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Db
/// </summary>
public class Db
{
    static string conn = ConfigurationManager.ConnectionStrings["DBBidMe"].ConnectionString;
    public Db()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static DataRow getOne(string sql)
    {
        
        DataRow row;
        using (SqlConnection con = new SqlConnection(Db.conn))
        {
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                            row = dt.Rows[0];
                        else
                            return new DataTable().NewRow();

                        return row;
                    }
                }
            }
        }
    }

    public static DataTable getAll(string sql)
    {
        
        using (SqlConnection con = new SqlConnection(Db.conn))
        {
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    public static void execute(string sql)
    {
        
        using (SqlConnection con = new SqlConnection(Db.conn))
        {
            con.Open();
            SqlCommand cmd;
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public static string executeandGetId(string sql)
    {
        
        using (SqlConnection con = new SqlConnection(Db.conn))
        {
            int _id;
            string Id;
            con.Open();
            SqlCommand cmd;
            cmd = new SqlCommand(sql, con);
            _id = Convert.ToInt32(cmd.ExecuteScalar());
            Id = _id.ToString();
            return Id;
        }
    }
}