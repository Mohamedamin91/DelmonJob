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
    public partial class ContactList : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        string query = "";
        string contactid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowContact();
            }
        }
        private void ShowContact()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select Row_number() over (Order by (select 1)) as [Sr.No],  contactid, Name, Email, Subject, message   from  contact ";
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
            ShowContact();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                     
                    try
                    {
                        SqlParameter paramcontactID = new SqlParameter("@ID", SqlDbType.Int);
                        paramcontactID.Value = contactid;

                        GridViewRow row = GridView1.Rows[e.RowIndex];

                        contactid = (GridView1.DataKeys[gvRow.RowIndex].Value.ToString());

                        Response.Write("<script>alert('" + contactid.ToString() + "');</script>");
                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(" DELETE  from  [dbo].[contact] where contactid=  '" + contactid + "'");

                        dr = Sqlconn.DataReader("select  * from contact  where  contactid= '" + contactid + "'");
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
                        ShowContact();



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

        protected void btndelete_Click(object sender, EventArgs e)
        {

        }
    }
}