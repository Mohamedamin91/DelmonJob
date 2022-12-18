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
    public partial class JobDetails : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        string query = "";
        public int jobcount = 0;
        DataTable dt,dt1;
        SqlDataReader dr;
       public  string jobTitle = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {

                showjobDetails();
                DataBind();
            }
            else 
            {
                Response.Redirect("JobListing.aspx");
            }

         
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void showjobDetails()
        {
            
                Sqlconn.OpenConection();
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                query = "Select *  from  jobs where jobid ='" + Request.QueryString["id"] + "' ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                DataList1.DataSource = dt;
                DataList1.DataBind();
                jobTitle = dt.Rows[0]["Title"].ToString();
                Sqlconn.CloseConnection();

        }



        //Setting defualt image if their no image for any job 
        protected string GetimageUrl(Object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "../assets/img/Defualtcompany.png";
            }
            else
            {
                url1 = string.Format("~/{0}", url);
            }
            return ResolveUrl(url1);
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "ApplyJob")
            {
                if (Session["user"] !=null)
                {
                    try
                    {
                        

                        SqlParameter paramJobID = new SqlParameter("@C1", SqlDbType.Int);
                        paramJobID.Value = Request.QueryString["id"];
                        SqlParameter paramUserID = new SqlParameter("@C2", SqlDbType.Int);
                        paramUserID.Value = Session["userid"];
                       
                        SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                        SqlCommand cmd;
                        query = "insert into AppliedJobs values (@C1,@C2) ";
                        cmd = new SqlCommand(query, con);
                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(query, paramJobID, paramUserID);
                        dr = Sqlconn.DataReader("select  max (AppliedJobID) from  AppliedJobs  where  AppliedJobID != 0 and jobid =@C1 and user=@C2 ", paramJobID,paramUserID);
                        dr.Read();

                        if (dr.HasRows)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Job applied Successfull  :) ";
                            lblMsg.CssClass = "alert alert-success";
                           
                            dr.Dispose();
                            dr.Close();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot  apply   right now,Please try again after sometime  :( ";
                            lblMsg.CssClass = "alert alert-danger";

                            dr.Dispose();
                            dr.Close();

                        }
                        dr.Dispose();
                        dr.Close();
                        Sqlconn.CloseConnection();



                    }
                    catch (SqlException exx)
                    {
                        Response.Write("<script>alert('" + exx.Message.ToString() + "');</script>");
                        lblMsg.Visible = true;
                        lblMsg.CssClass = "alert alert-danger";
                        lblMsg.Text = exx.Message;

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
                else
                {
                    Response.Redirect("Login.aspx");

                }
            }
        

        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["user"] != null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("lbApplyjob") as LinkButton;
                if (isApplied())
                {
                    btnApplyJob.Enabled = false;
                    btnApplyJob.Text = "Applied";
                }
                else
                {
                    btnApplyJob.Enabled = true;
                    btnApplyJob.Text = "Apply Now";
                }

            }
            }

        bool isApplied()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select *  from  AppliedJobs  where jobid ='" + Request.QueryString["id"] + "' and userid ='" + Session["userid"] + "' ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            sda.Fill(dt1);
            if (dt1.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

          

        }
       
    }
}