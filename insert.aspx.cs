using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

public partial class insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        if (Session["uNames"] == null)
        {
            Response.Redirect("main.aspx");
        }
    }
    protected void cmdInsert_Click(object sender, EventArgs e)
    {
        //clear error message
        lblError.Text = "";
        //get ArrayList from Session
        ArrayList uNames = (ArrayList)Session["uNames"];
        //validate PrimaryKey
        if (uNames.Contains(txtUName.Text.ToLower()))
        {
            lblError.Text = "This username exists...Enter new username";
        }
        else
        {
            //insert row
            String sql = "INSERT INTO [tUsers] ([username],[password]) VALUES (@uname, @pword)";
            String connStr = ConfigurationManager.ConnectionStrings["connStr_Users"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;

                cmd.Parameters.Add("@uname", System.Data.SqlDbType.VarChar, 10).Value = txtUName.Text;
                cmd.Parameters.Add("@pword", System.Data.SqlDbType.VarChar, 10).Value = txtPWord.Text;

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
    }
}