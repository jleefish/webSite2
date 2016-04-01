using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Specialized;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;


public partial class update : System.Web.UI.Page
{
    ArrayList uNames = null;
    public int rowIndex;
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

        txtUName.Text = uName;
        txtPWord.Text = pWord;
    }
    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        //clear error lable
        lblErrUName.Text = "";
        lblErrPWord.Text = "";
        //validate input
        if (txtUName.Text.Length < 1)
        {
            lblErrUName.Text = "Username is required";
        }
        else if(txtPWord.Text.Length < 1)
        {
            lblErrUName.Text = "Password is required";
        }
        else if(!isValid(txtUName.Text))
        {
            lblErrUName.Text = "Username contains invalid character";
        }
        else if(!isValid(txtPWord.Text)) 
        {
            lblErrPWord.Text = "Passwrod contains invalid character";
        }
        else if (!isValidPrimaryKey())
        {
            lblErrUName.Text = "This username exists..Enter new username";
        }
        else
        {
            //update row
            string sql = "UPDATE [tUsers] SET [username] = @uname, [password] = @pword WHERE [username] = @origUname";
            string connStr = ConfigurationManager.ConnectionStrings["connStr_Users"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                //============ parameter objects for @variables
                cmd.Parameters.Add("@uname",System.Data.SqlDbType.VarChar,10).Value = txtUName.Text;
                cmd.Parameters.Add("@pword",System.Data.SqlDbType.VarChar,10).Value = txtPWord.Text;
                cmd.Parameters.Add("@origUname",System.Data.SqlDbType.VarChar,10).Value = uName;;
                //============
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

    private bool isValid(string data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            char c = data[i];
            if ((c < 65 || c > 90) && (c < 97 || c > 122))
            {
                if (c < 48 || c > 57)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private bool isValidPrimaryKey()
    {
        for (int i = 0; i < uNames.Count; i++)
        {
            if (rowIndex != i)
            {
                if (uNames[i].ToString().Equals(txtUName.Text.ToLower()))
                {
                    return false;
                }
            }
        }
            return true;
    }
}