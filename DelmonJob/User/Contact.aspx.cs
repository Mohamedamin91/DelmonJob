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
    public partial class Contact : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Clear()
        {
            name.Value = string.Empty;
            email.Value = string.Empty;
            subject.Value = string.Empty;
            message.Value = string.Empty;
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            SqlParameter paramContactName = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramContactName.Value = name.Value;
            SqlParameter paramContactEmail = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramContactEmail.Value = email.Value;
            SqlParameter paramcontactSubject = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramcontactSubject.Value = subject.Value;
            SqlParameter paramContactMessage = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramContactMessage.Value = message.Value;
            try
            {
                Sqlconn.OpenConection();
                Sqlconn.ExecuteQueries("insert into Contact (Name,Email,Subject,Message)  values (@C1,@C2,@C3,@C4)", paramContactName, paramContactEmail, paramcontactSubject, paramContactMessage);

                SqlDataReader dr = Sqlconn.DataReader("select  max (contactid) from Contact  where  contactid != 0 ");
                dr.Read();

                if (dr.HasRows)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Thank you for reaching out ,We will look into your query :) ";
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                throw;
            }
            finally
            {
                Sqlconn.CloseConnection();

            }

        }
    }
}