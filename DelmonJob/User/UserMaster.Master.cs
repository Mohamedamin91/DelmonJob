using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonJob.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                LbRegisterOrProfile.Text = "Profile";
                LbLoginOrLogout.Text = "Logout";
            }
            else
            {
                LbRegisterOrProfile.Text = "Register";
                LbLoginOrLogout.Text = "Login";

            }
        }

        protected void LbRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if (LbRegisterOrProfile.Text == "Profile")
            {
                Response.Redirect("Profile.aspx");

            }
            else
            {
                Response.Redirect("Register.aspx");


            }
        }

        protected void LbLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (LbLoginOrLogout.Text == "Login")
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                Session.Abandon();
                Session["User"] = string.Empty;
                Response.Redirect("Login.aspx");


            }
        }
    }
}