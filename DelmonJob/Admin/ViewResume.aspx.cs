using DelmonJob.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
namespace DelmonJob.Admin
{
    public partial class ViewResume : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        string query = "";
        int appliedjob;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowAppliedJob();
            }

        }
        private void ShowAppliedJob()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = " Select Row_number() over (Order by (select 1)) as [Sr.No] ,aj.AppliedJobID,j.CompanyName,aj.JobID,j.Title,u.Mobile, CONCAT(FirstName , ' ' , SecondName , ' ' ,ThirdName , ' ', Lastname) as FullName,u.Email,u.Resume from AppliedJobs aj inner join[Users] u on aj.UserID = u.UserID  inner join[jobs] j on aj.JobID = j.JobID and j.CompanyName=  '" + Session["Department"] + "' or u.usertype= '"  +Session["Admin"] + "'";
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
            ShowAppliedJob();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlParameter paramappliedjob = new SqlParameter("@ID", SqlDbType.Int);
                paramappliedjob.Value = appliedjob;

                GridViewRow row = GridView1.Rows[e.RowIndex];


                appliedjob = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                Response.Write("<script>alert('" + appliedjob.ToString() + "');</script>");
                Sqlconn.OpenConection();
                Sqlconn.ExecuteQueries(" DELETE from  [dbo].[AppliedJobs] where AppliedJobID = '" + appliedjob + "'");

                dr = Sqlconn.DataReader("select  * from AppliedJobs  where  AppliedJobID= @ID   = '" + appliedjob + "'");
                dr.Read();
          

                if (dr.HasRows)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot delete Resume right now,Please try again after sometime  :( ";
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
                ShowAppliedJob();



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

        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    HiddenField jobID = (HiddenField)row.FindControl("hdnJob");
                    Response.Redirect("Joblist.aspx/id=" + jobID.Value);
                }
                else 
                {

                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to view Job detials";
                    
                }
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1,"Select$"+ e.Row.RowIndex);
            e.Row.ToolTip = "Click to view Job detials";
        }
    }
}