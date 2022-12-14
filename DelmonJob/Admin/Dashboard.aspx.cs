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
    public partial class Dashboard : System.Web.UI.Page
    {

        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        string query = "";
    
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                jobs();
                appliedjobs();
                users();
                contactcount();
            }
        }

        private void users()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select count(*) from users ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Users"] = dt.Rows[0][0];
            }
            else
            {
                Session["Users"] = 0;
            
            }
            Sqlconn.CloseConnection();
        }

        private void contactcount()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select count(*) from contact ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["contact"] = dt.Rows[0][0];
            }
            else
            {
                Session["contact"] = 0;

            }
            Sqlconn.CloseConnection();
        }

        private void jobs()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select count(*) from jobs ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["jobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["jobs"] = 0;

            }
            Sqlconn.CloseConnection();
        }

        private void appliedjobs()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select count(*) from AppliedJobs ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["AppliedJobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["AppliedJobs"] = 0;

            }
            Sqlconn.CloseConnection();
        }
    }
}