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
    public partial class Setting : System.Web.UI.Page
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
            query = "  Select Row_number() over (Order by (select 1)) as [Sr.No],  userid, Name, Email, mobile, country , UserType,CompanyName   from  users ";
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

       


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    string Userid = GridView1.DataKeys[gvRow.RowIndex].Value.ToString();
                    try
                    {
                        SqlParameter paramuserID = new SqlParameter("@ID", SqlDbType.Int);
                        paramuserID.Value = Userid;

                        SqlParameter paramusertype = new SqlParameter("@C1", SqlDbType.NVarChar);
                        paramusertype.Value = DDUsertype.SelectedValue;

                        SqlParameter paramDepartment = new SqlParameter("@C2", SqlDbType.NVarChar);
                        paramDepartment.Value = DDepartment.SelectedValue;

                        //SqlParameter paramuserID = new SqlParameter("@ID", SqlDbType.Int);
                        //paramuserID.Value = Userid;



                        Response.Write("<script>alert('" + Userid.ToString() + "');</script>");
                        Sqlconn.OpenConection();
                        Sqlconn.ExecuteQueries(" update  [dbo].[users] set usertype=@C1 , CompanyName=@C2 where userid = @ID ", paramuserID, paramusertype, paramDepartment);
                        Sqlconn.CloseConnection();
                        lblMsg.Visible = true;
                        lblMsg.Text = "Operation Has been done Successfull  :) ";
                        lblMsg.CssClass = "alert alert-success";
                        Clear();
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
        private void Clear()
        {
           
            DDUsertype.ClearSelection();
            DDepartment.ClearSelection();


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
       
      
        }
    }
    }
