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
using System.Drawing;


namespace DelmonJob.Admin
{
    public partial class JobList : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        string query = "";
        int jobId;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowJob();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowJob();
        }

        private void ShowJob()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select Row_number() over (Order by (select 1)) as [Sr.No],  JobID, Title, postions, Qualification, Experiance , LastDayToApply, CompanyName, Country, state, CreateDate  from  jobs   where CompanyName=  '" + Session["Department"] + "'"  ;
            cmd = new SqlCommand(query,con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd );
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (Request.QueryString["id"] !=null)
            {
                LinkBack.Visible = true;

            }

            Sqlconn.CloseConnection();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowJob();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {

                    try
                    {
                        SqlParameter paramJobID = new SqlParameter("@ID", SqlDbType.Int);
                       

                        GridViewRow row = GridView1.Rows[e.RowIndex];
                      
                        jobId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                        paramJobID.Value = jobId;
                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(" DELETE from  [Jobs] where jobid = @ID ", paramJobID);

                        dr = Sqlconn.DataReader("select  * from jobs  where  jobid= @ID  ", paramJobID);
                        dr.Read();

                        if (dr.HasRows)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot delete record right now,Please try again after sometime  :( ";
                            lblMsg.CssClass = "alert alert-danger";

                            dr.Dispose();
                            dr.Close();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Operation Has been deleted Successfull  :) ";
                            lblMsg.CssClass = "alert alert-success";

                            dr.Dispose();
                            dr.Close();
                        }
                        dr.Dispose();
                        dr.Close();
                        Sqlconn.CloseConnection();
                        GridView1.EditIndex = -1;
                        ShowJob();



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
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditJob")
            {
                Response.Redirect("NewJob.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ID = e.Row.RowIndex.ToString();
                if (Request.QueryString["id"] !=null)
                  {
                    int jobid = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Values[0]);
                    if (jobid== Convert.ToInt32(Request.QueryString["id"]))
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    }
                }
            }
        }

     
    }
}