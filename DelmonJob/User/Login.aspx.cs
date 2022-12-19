using DelmonJob.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonJob.User
{
    public partial class Login : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        string userename, password = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlParameter paramUsername = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramUsername.Value = txtUsername.Text.Trim();
            SqlParameter paramPassword = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramPassword.Value = txtPassword.Text.Trim();
            
            SqlParameter paramUserSuperAdmin = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramUserSuperAdmin.Value = "Super Admin" ;

            SqlParameter paramUserAdmin = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramUserAdmin.Value = "Admin";

            try
            {
                Sqlconn.OpenConection();


                SqlDataReader dr = Sqlconn.DataReader("select *  from Users  where   Username =@C1 and password = @C2  and usertype=@C3 or usertype=@C4 ", paramUsername, paramPassword,paramUserSuperAdmin,paramUserAdmin);
                if (dr.Read())
                {
                    Session["Admin"] = dr["usertype"].ToString();
                    Session["MainUserType"] = dr["usertype"].ToString();
                    Session["Admin"] = dr["usertype"].ToString();
                    Session["Department"] = dr["CompanyName"].ToString();
                   
                    
                    Response.Redirect("../Admin/Dashboard.aspx", false);

                    dr.Dispose();
                    dr.Close();
                }
                
                //if (DDLoginType.SelectedValue == "Admin")
                //{
                //    userename = ConfigurationManager.AppSettings["username"];
                //    password = ConfigurationManager.AppSettings["password"];
                //    if (userename == txtUsername.Text.Trim() && password == txtPassword.Text.Trim())
                //    {
                //        Session["Admin"] = userename;
                //        Response.Redirect("../Admin/Dashboard.aspx", false);

                //    }
                //    else
                //    {
                //        showErrorMsg("Admin");
                //    }
                //}
                else 
                {
                    dr.Dispose();
                    dr.Close();

                    dr = Sqlconn.DataReader("select *  from Users  where  Username =@C1 and password = @C2 ", paramUsername, paramPassword);
                    if (dr.Read())
                    {
                        Session["User"] = dr["Username"].ToString();
                        Session["userID"] = dr["UserID"].ToString();

                        Response.Redirect("../User/Default.aspx", false);


                        dr.Dispose();
                        dr.Close();
                    }
                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        showErrorMsg("User");

                    }
                    Sqlconn.CloseConnection();

                }
                
                


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                lblMsg.Visible = true;
                lblMsg.CssClass = "alert alert-danger";
                lblMsg.Text = ex.Message;
                Sqlconn.CloseConnection();
            }
            finally
            {
                Sqlconn.CloseConnection();
            }

        }
        public void showErrorMsg(string userType)
        {
            //Response.Write("<script>alert('" + userType.ToString() + "');</script>");
            lblMsg.Visible = true;
            lblMsg.CssClass = "alert alert-danger";
            lblMsg.Text = "Credentials are incorrect.. :(";
        }





    }
}