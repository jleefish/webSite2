using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;

public partial class delete : System.Web.UI.Page
{
    public string uName = null;
    public string pWord = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection qsData = Request.QueryString;
        if (qsData.Get("uName") == null || qsData.Get("pWord") == null)
        {
            Response.Redirect("main.aspx");
        }
        uName = qsData.Get("uName");
        pWord = qsData.Get("pWord");
    }


    protected void cmdYes_Click(object sender, EventArgs e)
    {
        //delete row
        string sql = "DELETE FROM [tUSER] WHERE [username] = @origUname";
        string connStr = ConfigurationManager.ConnectionStrings["connStr_Users"].ConnectionString;
        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            // set parameter object
            cmd.Parameters.Add("@origUname", System.Data.SqlDbType.VarChar, 10).Value = uName;
            // ====================
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("main.aspx");
        }
        catch (SqlException ex)
        {
            if (conn != null)
            {
                conn.Close();
            }
            Response.Write(ex.Message);
        }
    }
    protected void cmdNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("main.aspx");
    }
}