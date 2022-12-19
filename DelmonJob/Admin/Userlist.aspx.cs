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
    public partial class Userlist : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        SqlDataReader dr;
        string query = "";
        int Userid;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowUser();
            }
        }
        private void ShowUser()
        {
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select Row_number() over (Order by (select 1)) as [Sr.No],  userid, CONCAT(FirstName , ' ' , SecondName , ' ' ,ThirdName , ' ', Lastname) as FullName, Email, mobile, country   from  users ";
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
            ShowUser();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        SqlParameter paramuserID = new SqlParameter("@ID", SqlDbType.Int);
                       
                        GridViewRow row = GridView1.Rows[e.RowIndex];


                        Userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                        paramuserID.Value = Userid;

                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(" DELETE  from  [dbo].[users] where userid = @ID ", paramuserID);

                        dr = Sqlconn.DataReader("select  * from  users  where  userid= @ID  ", paramuserID);
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
                        ShowUser();



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
    }
}