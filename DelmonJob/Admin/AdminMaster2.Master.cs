using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonJob.Admin
{
    public partial class AdminMaster2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            //if (Session["admin"] != null)
            //{
            //    if (Session["admin"].ToString().ToLower().Contains("Super Admin"))
            //    {
            //        LISETTING.Visible = true;
            //    }
            //    else
            //    {
            //        LISETTING.Visible = false;
            //    }

            //}
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../User/Login.aspx");
        }
    }
}