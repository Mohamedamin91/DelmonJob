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
    public partial class ResumeBuild : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        string query = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ShowUserInfo();
                }
                else 
                { 
                }
            }
        }

        private void ShowUserInfo()
        {
            try
            {
                Sqlconn.OpenConection();
                SqlParameter paramIDQuery = new SqlParameter("@C1", SqlDbType.Int);
                paramIDQuery.Value = Request.QueryString["id"].ToString().Trim();
                dr = Sqlconn.DataReader("Select  *  from  Users where Userid=@C1", paramIDQuery);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtUsername.Text = dr["username"].ToString();
                        txtFullName.Text = dr["name"].ToString();
                        txtEmail.Text = dr["email"].ToString();
                        txtMobileNumber.Text = dr["mobile"].ToString();

                        txtPrimarystage.Text = dr["Primarystage"].ToString();
                        txtHigherstage.Text = dr["Higherstage"].ToString();
                        txtGraduatestage.Text = dr["Graduatestage"].ToString();
                        txtPostGraduate.Text = dr["PostGraduate"].ToString();

                        txtWorksOn.Text = dr["WorksOn"].ToString();
                        txtExperiance.Text = dr["Experiance"].ToString();

                        txtAddress.Text = dr["address"].ToString();
                        DDCountry.SelectedValue = dr["country"].ToString();



                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "User not found :( ";
                    lblMsg.CssClass = "alert alert-danger";

                }
                dr.Close();
                Sqlconn.CloseConnection();
            }
            catch (Exception ex)
            {

                Sqlconn.CloseConnection();
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

    protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string Filepath = string.Empty;
                    // bool isValidtoexecute = false;
                    bool isValid = false;

                    if (FuResume.HasFile)
                    {
                        if (IsValidExtension(FuResume.FileName))
                        {
                            concatQuery = "Resume=@C11,";
                            isValid = true;
                        }
                        else

                        {
                             concatQuery = string.Empty;
                           

                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;

                    }
                    query = @"Update users set username=@C1,name=@C2,Email=@C3,Mobile=@C4 ,[Primarystage]=@C5 ,[Higherstage] = @C6,[Graduatestage] = @C7 ,[PostGraduate] =@C8, Workson=@C9 ,[Experiance] = @C10," + concatQuery + " [Address]= @C12 ,[Country] = @C13 where userid=@ID";
                    SqlParameter paramusername = new SqlParameter("@C1", SqlDbType.NVarChar);
                    paramusername.Value = txtUsername.Text.Trim();
                    SqlParameter paramFullname = new SqlParameter("@C2", SqlDbType.NVarChar);
                    paramFullname.Value = txtFullName.Text.Trim();
                    SqlParameter paramEmail = new SqlParameter("@C3", SqlDbType.NVarChar);
                    paramEmail.Value = txtEmail.Text.Trim();
                    SqlParameter paramMobile = new SqlParameter("@C4", SqlDbType.NVarChar);
                    paramMobile.Value = txtMobileNumber.Text.Trim();
                    SqlParameter paramprimary = new SqlParameter("@C5", SqlDbType.NVarChar);
                    paramprimary.Value = txtPrimarystage.Text.Trim();
                    SqlParameter paramSecondry = new SqlParameter("@C6", SqlDbType.NVarChar);
                    paramSecondry.Value = txtHigherstage.Text.Trim();
                    SqlParameter paramGradute = new SqlParameter("@C7", SqlDbType.NVarChar);
                    paramGradute.Value = txtGraduatestage.Text.Trim();
                    SqlParameter paramPostGraduate = new SqlParameter("@C8", SqlDbType.NVarChar);
                    paramPostGraduate.Value = txtPostGraduate.Text.Trim();
                    SqlParameter paramWorkon = new SqlParameter("@C9", SqlDbType.NVarChar);
                    paramWorkon.Value = txtWorksOn.Text.Trim();
                    SqlParameter paramExperiance = new SqlParameter("@C10", SqlDbType.NVarChar);
                    paramExperiance.Value = txtExperiance.Text.Trim();

                    SqlParameter paramResume = new SqlParameter("@C11", SqlDbType.NVarChar);


                    SqlParameter paramAddress = new SqlParameter("@C12", SqlDbType.NVarChar);
                    paramAddress.Value = txtAddress.Text.Trim();
                    SqlParameter paramCountry = new SqlParameter("@C13", SqlDbType.NVarChar);
                    paramCountry.Value = DDCountry.SelectedValue;

                    SqlParameter paramuserid = new SqlParameter("@ID", SqlDbType.NVarChar);
                    paramuserid.Value = Request.QueryString["id"].ToString();
                    if (FuResume.HasFile)
                    {
                        if (IsValidExtension(FuResume.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            Filepath = "ResumesProject/" + obj.ToString() + FuResume.FileName;
                            FuResume.PostedFile.SaveAs(Server.MapPath("~/ResumesProject/") + obj.ToString() + FuResume.FileName);

                            paramResume.Value = Filepath;
                            isValid = true;
                        }
                        else 
                        {
                            concatQuery = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please select .doc , .docx , .pdf for resume :( ";
                            lblMsg.CssClass = "alert alert-danger";
                        }

                    }
                    else
                    {
                        isValid = true;
                    }
                    if (isValid)
                    {
                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(query, paramusername, paramFullname, paramEmail, paramMobile, paramprimary, paramSecondry, paramGradute, paramPostGraduate, paramWorkon, paramExperiance, paramAddress, paramCountry, paramResume, paramuserid);


                        dr = Sqlconn.DataReader("select  max (userid) from users  where  userid != 0 and userid=@ID ", paramuserid);
                        dr.Read();

                        if (dr.HasRows)
                        {

                            lblMsg.Visible = true;
                            lblMsg.Text = "Resume details updated successful..  :) ";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot  Update record right now,Please try again after sometime  :( ";
                            lblMsg.CssClass = "alert alert-danger";

                            dr.Dispose();
                            dr.Close();

                        }
                        dr.Dispose();
                        dr.Close();
                        Sqlconn.CloseConnection();

                    }
                }

                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot  Update record right now,Please try <b>Relogin</b>   :( ";
                    lblMsg.CssClass = "alert alert-danger";


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
        public static bool IsValidExtension(string furesume)
        {
            bool isValid = false;
            string[] filextension = { ".doc", ".docs", ".pdf" };
            for (int i = 0; i <= filextension.Length - 1; i++)
            {
                if (filextension.Contains(filextension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

    }
}