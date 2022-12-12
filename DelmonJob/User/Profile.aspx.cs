using DelmonJob.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonJob.User
{
    public partial class Profile : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        
        string query = "";
        int jobId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowUserProfile();
            }

        }

        private void ShowUserProfile()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;

          
            query = "Select   userid, username, Name, Address, Mobile , Email, Country, Resume  from  Users where UserName=@C1 ";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@C1", Session["user"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DLProfile.DataSource = dt;
            DLProfile.DataBind();
            Sqlconn.CloseConnection();
        }

        protected void DLProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditUserProfile")
            {
                Response.Redirect("ResumeBuild.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}