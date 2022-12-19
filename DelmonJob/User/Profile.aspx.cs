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
        
        string query = "";
       
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
            query = "Select   userid, username, CONCAT(FirstName , ' ' , SecondName , ' ' ,ThirdName , ' ', Lastname) as FullName, Address, Mobile , Email, Country, Resume  from  Users where UserName=@C1 ";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@C1", Session["user"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count>0)
            {
                DLProfile.DataSource = dt;
                DLProfile.DataBind();
            }
            else
            {
                Response.Write("<script>alert(' Please do login again with your latest username ');</script>");

            }

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