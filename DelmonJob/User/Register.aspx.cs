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
    public partial class Register : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtFullName.Text = string.Empty; 
            txtAddress.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            DDCountry.ClearSelection();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlParameter paramUsername = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramUsername.Value = txtUsername.Text.Trim();
            SqlParameter paramPassword = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramPassword.Value = txtConfirmPassword.Text.Trim();
            SqlParameter paramFullname= new SqlParameter("@C3", SqlDbType.NVarChar);
            paramFullname.Value = txtFullName.Text.Trim();
            SqlParameter paramAddress = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramAddress.Value = txtAddress.Text.Trim();
            SqlParameter paramMobile = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramMobile.Value = txtMobileNumber.Text.Trim();
            SqlParameter paramEmail = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramEmail.Value = txtEmail.Text.Trim();
            SqlParameter paramCountry = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramCountry.Value = DDCountry.SelectedValue;




            try
            {
                Sqlconn.OpenConection();

                 dr = Sqlconn.DataReader("select   (Username) from Users  where  Username =@C1 ", paramUsername);
                if (dr.HasRows == true)
                {
                   
                    lblMsg.Visible = true;
                    lblMsg.Text = " Username already exist,Please try new one..  :( ";
                    lblMsg.CssClass = "alert alert-danger";
                    dr.Dispose();
                    dr.Close();
                }
                else
                {

                    dr.Dispose();
                    dr.Close();
                    Sqlconn.ExecuteQueries("INSERT INTO [dbo].[Users]  ([Username],[Password],[Name],[Address],[Mobile],[Email],[Country])  Values (@C1,@C2,@C3,@C4,@C5,@C6,@C7)"
                      , paramUsername, paramPassword, paramFullname, paramAddress, paramMobile, paramEmail, paramCountry);

                    dr = Sqlconn.DataReader("select  max (UserID) from Users  where  UserID != 0 ");
                    dr.Read();

                    if (dr.HasRows)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Registered Successfull  :) ";
                        lblMsg.CssClass = "alert alert-success";
                        Clear();
                        dr.Dispose();
                        dr.Close();
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot save record right now,Please try again after sometime  :( ";
                        lblMsg.CssClass = "alert alert-danger";

                        dr.Dispose();
                        dr.Close();
                    }
                    dr.Dispose();
                    dr.Close();


                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constrain"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + txtUsername.Text.Trim() + "</b>" + " Username already exist,Please try new one..  :( ";
                    lblMsg.CssClass = "alert alert-danger";
                    lblMsg.Text = ex.Message;
                    dr.Dispose();
                    dr.Close();
                }
                else
                {

                    Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                    lblMsg.Text = ex.Message.ToString();
                    lblMsg.CssClass = "alert alert-danger";
                    lblMsg.Visible = true;
                    dr.Dispose();
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                lblMsg.Visible = true;
                lblMsg.CssClass = "alert alert-danger";
                lblMsg.Text = ex.Message;
            }
            finally
            {
                Sqlconn.CloseConnection();
            }
        }
    }
}