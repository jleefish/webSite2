using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //step1
        String sql = "SELECT * FROM [tUsers]";
        //final exam!!
        String connStr = ConfigurationManager.ConnectionStrings["connStr_Users"].ConnectionString;

        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            //don't forget close processes
            dr.Close();
            conn.Close();
        }
        catch (SqlException ex)
        {
            if (conn != null)
            {
                conn.Close();
            }
            Response.Write(ex.Message);
        }

        //step2
        //create container for primarykey values
        ArrayList uNames = new ArrayList();
        
        //populate ArrayList .... all values LOWER CASE!!!
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            uNames.Add(GridView1.Rows[i].Cells[0].Text.ToLower());
        }
        
        //save ArrayList to session
        Session["uNames"] = uNames;

        //wire up RowCommand event for GridView1
        GridView1.RowCommand += GridView1_RowCommand;
    }

    void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("updateRow"))
        {
            //Response.Write(e.CommandArgument);//return index of row
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("update.aspx?uName="+GridView1.Rows[rowIndex].Cells[0].Text+ 
                "&pWord="+GridView1.Rows[rowIndex].Cells[1].Text+
                "&rowIndex="+rowIndex);
        }
        else if (e.CommandName.Equals("deleteRow"))
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("delete.aspx?uName=" + GridView1.Rows[rowIndex].Cells[0].Text +
                "&pWord=" + GridView1.Rows[rowIndex].Cells[1].Text);
        }
    }
}