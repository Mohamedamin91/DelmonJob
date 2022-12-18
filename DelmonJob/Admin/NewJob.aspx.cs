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
    public partial class NewJob : System.Web.UI.Page
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
            Session["Title"] = "Add Job";
            if (!IsPostBack)
            {
                fiilData();
            }
        }

        private void fiilData()
        {
            if (Request.QueryString["id"] != null)
            {
                
                Sqlconn.OpenConection();
                SqlParameter paramIDQuery = new SqlParameter("@IDD", SqlDbType.Int);
                paramIDQuery.Value = Request.QueryString["id"].ToString().Trim();
                dr = Sqlconn.DataReader("select * from jobs where jobid =@IDD", paramIDQuery);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtJobTitle.Text = dr["Title"].ToString();
                        txtNumberOFPostions.Text = dr["postions"].ToString();
                        txtdescription.Text = dr["Description"].ToString();
                        txtQualification.Text = dr["Qualification"].ToString();
                        txtExpereiance.Text = dr["Experiance"].ToString();
                        txtSpecialization.Text = dr["Specialization"].ToString();
                        txtLastDate.Text = Convert.ToDateTime(dr["LastDayToApply"]).ToString("yyyy-MM-dd");
                        txtsalary.Text = dr["salary"].ToString();
                        DDJobTypes.SelectedValue = dr["jobtype"].ToString();
                         DDepartment.SelectedValue = dr["companyname"].ToString();
                        txtWebsite.Text = dr["website"].ToString();
                        txtEmail.Text = dr["email"].ToString();
                        txtAddress.Text = dr["address"].ToString();
                        DDCountry.SelectedValue = dr["country"].ToString();
                        txtstate.Text = dr["state"].ToString();

                        btnAdd.Text = "Update";
                        linkBack.Visible = true;
                        Session["Title"] = "Edit Job";
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Job not found :( ";
                    lblMsg.CssClass = "alert alert-danger";
                  
                }
                dr.Close();
                Sqlconn.CloseConnection();
            }
            
        
        
        
        }

        private void Clear()
        {
            txtJobTitle.Text = string.Empty;
            txtNumberOFPostions.Text = string.Empty;
            txtdescription.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtExpereiance.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
            txtLastDate.Text = string.Empty;
            txtsalary.Text = string.Empty;
           
            txtWebsite.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtstate.Text = string.Empty;
            txtEmail.Text = string.Empty;
            DDCountry.ClearSelection();
            DDJobTypes.ClearSelection();
            DDepartment.ClearSelection();


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                    string type,concatQuery, imagePath = string.Empty;
                    bool isValidToexecute = false;
                    DateTime time = DateTime.Now;
                if (Request.QueryString["id"] != null)
                {

                    if (Fucompanylogo.HasFile)

                    {
                        if (IsValidExtension(Fucompanylogo.FileName))
                        {
                            concatQuery = "companyimage=@C11,";
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
                    query = " update  [dbo].[Jobs] set [Title]=@C1,[postions]=@C2,[Description]=@C3,[Qualification]=@C4,[Experiance]=@C5,[Specialization]=@C6,[LastDayToApply]=@C7,[Salary]=@C8,[JobType]=@C9,[CompanyName]= @C10 ," +concatQuery+ @"[Website]=@C12,[Email]=@C13,[Address]=@C14,[Country]=@C15,[state]=@C16  " +
                " where jobid=@ID ";
                    type = "updated";
                    SqlParameter paramTitle = new SqlParameter("@C1", SqlDbType.NVarChar);
                    paramTitle.Value = txtJobTitle.Text.Trim();
                    SqlParameter parampostions = new SqlParameter("@C2", SqlDbType.NVarChar);
                    parampostions.Value = txtNumberOFPostions.Text.Trim();
                    SqlParameter paramDescription = new SqlParameter("@C3", SqlDbType.NVarChar);
                    paramDescription.Value = txtdescription.Text.Trim();
                    SqlParameter paramQualtification = new SqlParameter("@C4", SqlDbType.NVarChar);
                    paramQualtification.Value = txtQualification.Text.Trim();
                    SqlParameter paramExperiance = new SqlParameter("@C5", SqlDbType.NVarChar);
                    paramExperiance.Value = txtExpereiance.Text.Trim();
                    SqlParameter paramSpecial = new SqlParameter("@C6", SqlDbType.NVarChar);
                    paramSpecial.Value = txtSpecialization.Text.Trim();
                    SqlParameter paramLastDate = new SqlParameter("@C7", SqlDbType.NVarChar);
                    paramLastDate.Value = txtLastDate.Text.Trim();
                    SqlParameter paramSalary = new SqlParameter("@C8", SqlDbType.NVarChar);
                    paramSalary.Value = txtsalary.Text.Trim();
                    SqlParameter paramJobtype = new SqlParameter("@C9", SqlDbType.NVarChar);
                    paramJobtype.Value = DDJobTypes.SelectedValue;
                    SqlParameter paramCompanyname = new SqlParameter("@C10", SqlDbType.NVarChar);
                    paramCompanyname.Value =  DDepartment.SelectedValue;
                    SqlParameter paramcompanylogo = new SqlParameter("@C11", SqlDbType.NVarChar);
                    paramcompanylogo.Value = imagePath;

                    SqlParameter paramwebsite = new SqlParameter("@C12", SqlDbType.NVarChar);
                    paramwebsite.Value = txtWebsite.Text.Trim();
                    SqlParameter paramEmail = new SqlParameter("@C13", SqlDbType.NVarChar);
                    paramEmail.Value = txtEmail.Text.Trim();
                    SqlParameter paramAddress = new SqlParameter("@C14", SqlDbType.NVarChar);
                    paramAddress.Value = txtAddress.Text.Trim(); ;
                    SqlParameter paramCountry = new SqlParameter("@C15", SqlDbType.NVarChar);
                    paramCountry.Value = DDCountry.SelectedValue;
                    SqlParameter paramState = new SqlParameter("@C16", SqlDbType.NVarChar);
                    paramState.Value = txtstate.Text.Trim();
                    SqlParameter paramjobid= new SqlParameter("@ID", SqlDbType.NVarChar);
                    paramjobid.Value = Request.QueryString["id"].ToString() ;

                    if (Fucompanylogo.HasFile)
                    {
                        if (IsValidExtension(Fucompanylogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "ImagesProject/" + obj.ToString() + Fucompanylogo.FileName;
                            Fucompanylogo.PostedFile.SaveAs(Server.MapPath("~/ImagesProject/") + obj.ToString() + Fucompanylogo.FileName);

                            isValidToexecute = true;
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please Select .jpg , .png , .jpeg for logo    :( ";
                            lblMsg.CssClass = "alert alert-danger";
                            isValidToexecute = true;
                        }
                    }
                    else
                    {

                        isValidToexecute = true;

                    }
                    if (isValidToexecute)
                    {
                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(query, paramTitle, parampostions, paramDescription, paramQualtification, paramExperiance, paramSpecial, paramLastDate, paramSalary, paramJobtype, paramCompanyname, paramcompanylogo, paramwebsite, paramEmail, paramAddress, paramCountry, paramState, paramjobid);

                        dr = Sqlconn.DataReader("select  max (jobid) from jobs  where  jobid != 0 ");
                        dr.Read();

                        if (dr.HasRows)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Operation Has been " + type + " Successfull  :) ";
                            lblMsg.CssClass = "alert alert-success";
                            Clear();
                            dr.Dispose();
                            dr.Close();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot " + type + " record right now,Please try again after sometime  :( ";
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
                    query = " INSERT INTO [dbo].[Jobs]  ([Title],[postions],[Description],[Qualification],[Experiance],[Specialization],[LastDayToApply],[Salary],[JobType],[CompanyName],[CompanyLogo],[Website],[Email],[Address],[Country],[state],[CreateDate])" +
                   " Values (@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8,@C9,@C10,@C11,@C12,@C13,@C14,@C15,@C16,@C17) ";
                    type = "saved";
                    SqlParameter paramTitle = new SqlParameter("@C1", SqlDbType.NVarChar);
                    paramTitle.Value = txtJobTitle.Text.Trim();
                    SqlParameter parampostions = new SqlParameter("@C2", SqlDbType.NVarChar);
                    parampostions.Value = txtNumberOFPostions.Text.Trim();
                    SqlParameter paramDescription = new SqlParameter("@C3", SqlDbType.NVarChar);
                    paramDescription.Value = txtdescription.Text.Trim();
                    SqlParameter paramQualtification = new SqlParameter("@C4", SqlDbType.NVarChar);
                    paramQualtification.Value = txtQualification.Text.Trim();
                    SqlParameter paramExperiance = new SqlParameter("@C5", SqlDbType.NVarChar);
                    paramExperiance.Value = txtExpereiance.Text.Trim();
                    SqlParameter paramSpecial = new SqlParameter("@C6", SqlDbType.NVarChar);
                    paramSpecial.Value = txtSpecialization.Text.Trim();
                    SqlParameter paramLastDate = new SqlParameter("@C7", SqlDbType.NVarChar);
                    paramLastDate.Value = txtLastDate.Text.Trim();
                    SqlParameter paramSalary = new SqlParameter("@C8", SqlDbType.NVarChar);
                    paramSalary.Value = txtsalary.Text.Trim();
                    SqlParameter paramJobtype = new SqlParameter("@C9", SqlDbType.NVarChar);
                    paramJobtype.Value = DDJobTypes.SelectedValue;
                    SqlParameter paramCompanyname = new SqlParameter("@C10", SqlDbType.NVarChar);
                    paramCompanyname.Value =  DDepartment.SelectedValue;
                    SqlParameter paramcompanylogo = new SqlParameter("@C11", SqlDbType.NVarChar);
                    paramcompanylogo.Value = imagePath;

                    SqlParameter paramwebsite = new SqlParameter("@C12", SqlDbType.NVarChar);
                    paramwebsite.Value = txtWebsite.Text.Trim();
                    SqlParameter paramEmail = new SqlParameter("@C13", SqlDbType.NVarChar);
                    paramEmail.Value = txtEmail.Text.Trim();
                    SqlParameter paramAddress = new SqlParameter("@C14", SqlDbType.NVarChar);
                    paramAddress.Value = txtAddress.Text.Trim(); ;
                    SqlParameter paramCountry = new SqlParameter("@C15", SqlDbType.NVarChar);
                    paramCountry.Value = DDCountry.SelectedValue;
                    SqlParameter paramState = new SqlParameter("@C16", SqlDbType.NVarChar);
                    paramState.Value = txtstate.Text.Trim();
                    SqlParameter paramCreateDate = new SqlParameter("@C17", SqlDbType.NVarChar);
                    paramCreateDate.Value = time.ToString("yyyy-MM-dd HH:mm:ss");

                    if (Fucompanylogo.HasFile)
                    {
                        if (IsValidExtension(Fucompanylogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "ImagesProject/" + obj.ToString() + Fucompanylogo.FileName;
                            Fucompanylogo.PostedFile.SaveAs(Server.MapPath("~/ImagesProject/") + obj.ToString() + Fucompanylogo.FileName);

                            isValidToexecute = true;
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please Select .jpg , .png , .jpeg for logo    :( ";
                            lblMsg.CssClass = "alert alert-danger";
                            isValidToexecute = true;
                        }
                    }
                    else
                    {

                        paramcompanylogo.Value = imagePath;
                        isValidToexecute = true;

                    }
                    if (isValidToexecute)
                    {
                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(query, paramTitle, parampostions, paramDescription, paramQualtification, paramExperiance, paramSpecial, paramLastDate, paramSalary, paramJobtype, paramCompanyname, paramcompanylogo, paramwebsite, paramEmail, paramAddress, paramCountry, paramState, paramCreateDate);

                        dr = Sqlconn.DataReader("select  max (jobid) from jobs  where  jobid != 0 ");
                        dr.Read();

                        if (dr.HasRows)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Operation Has been " + type + " Successfull  :) ";
                            lblMsg.CssClass = "alert alert-success";
                            Clear();
                            dr.Dispose();
                            dr.Close();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot " + type + " record right now,Please try again after sometime  :( ";
                            lblMsg.CssClass = "alert alert-danger";

                            dr.Dispose();
                            dr.Close();

                        }
                        dr.Dispose();
                        dr.Close();
                        Sqlconn.CloseConnection();

                    }
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

        private bool IsValidExtension(string fucompanylogo)
        {
            bool isValid = false;
            string[] filextension = { ".jpg",".png",".jpeg"};
            for (int i=0; i<= filextension.Length-1; i++)
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