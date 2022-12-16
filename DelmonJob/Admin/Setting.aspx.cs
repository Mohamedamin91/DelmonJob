using DelmonJob.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonJob.Admin
{
    public partial class Setting : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        string query = "";
        int Userid;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowUser();
            }
        }
        private void ShowUser()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "  Select Row_number() over (Order by (select 1)) as [Sr.No],  userid, Name, Email, mobile, country , UserType   from  users ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Sqlconn.CloseConnection();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowUser();

        }

       

        protected void btnEditJob_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Userid  = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

        }
    }
}