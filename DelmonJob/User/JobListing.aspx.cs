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
    public partial class JobListing : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        string query = "";
        public int jobcount = 0;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showjoblist();
                RBSelectedColorChange();
            }
        }

        public void showjoblist()
        {
            if (dt == null)
            {
                Sqlconn.OpenConection();
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate,Jobcategory  from  jobs ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
            lbljobcount.Text = jobCount(dt.Rows.Count);
            Sqlconn.CloseConnection();
        }

        string jobCount(int count)
        {
            if (count > 1)
            {
                return " Total <b>" + count + "</b> jobs found";
            }
            else if (count == 1)
            {
                return " Total <b>" + count + "</b> jobs found";
            }
            else
            {
                return "No Job Found";

            }
        }



       

        //Setting defualt image if their no image for any job 
        protected string GetimageUrl(Object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1= "../assets/img/Defualtcompany.png";
            }
            else
            {
                url1= string.Format("~/{0}", url);
            }
            return ResolveUrl(url1);
        }

        //Getting Relative For given data like i month ago
        public static string Relativedata(DateTime TheDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "{0} seconds ago");
            thresholds.Add(minute * 2, "a minutes ago");
            thresholds.Add(minute * 45, "{0} minutes ago");
            thresholds.Add(minute * 120, "an hour ago");
            thresholds.Add(day, "{0} hours ago");
            thresholds.Add(day * 2, "yesterday");
            thresholds.Add(day * 30, "{0} days ago");
            thresholds.Add(day * 365, "{0} months ago");
            thresholds.Add(long.MaxValue, "{0} years ago");

            long since = (DateTime.Now.Ticks - TheDate.Ticks) / 10000000;

            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - TheDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))));
                }
            }
            return "";
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string jobtype = string.Empty;
            jobtype = selectedCheckbox();
            if (jobtype != "")
            { 
            Sqlconn.OpenConection();
            SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
            SqlCommand cmd;
            query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate ,Jobcategory  from  jobs " +
                " where  jobtype IN (" + jobtype +  ") ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            showjoblist();
            RBSelectedColorChange();

        }
        else
        {
                showjoblist();

        }


        }
        string selectedCheckbox()
        {
            string jobtype = string.Empty;

            for (int i = 0; i<CheckBoxList1.Items.Count;i++)
            { 
                if(CheckBoxList1.Items[i].Selected)
                {
                    jobtype += "'" + CheckBoxList1.Items[i].Text + "',";
                }
            }
            return jobtype = jobtype.TrimEnd(',');
        }

        protected void DDJobCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDJobCategory.SelectedValue != "0")
            {
                Sqlconn.OpenConection();
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate ,Jobcategory  from  jobs " +
                    " where  Jobcategory ='" + DDJobCategory.SelectedValue + "' ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showjoblist();
            }
            else 
            {
                showjoblist();
            }

           
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (RadioButtonList1.SelectedValue != "0")
            {
                string posteddate = string.Empty;
                posteddate = selectedRadoiButton();
                Sqlconn.OpenConection();
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate ,Jobcategory  from  jobs " +
                    " where  convert  (DATE,CreateDate) " + posteddate + " ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showjoblist();
                RBSelectedColorChange();

            }
            else
            {
                showjoblist();
                RBSelectedColorChange();

            }

        }

         string selectedRadoiButton()
        {
            string posteddate = string.Empty;
            DateTime date = DateTime.Today;
            if (RadioButtonList1.SelectedValue == "1")
            {
                posteddate = " = Convert ( DATE,'" + date.ToString("yyyy/MM/dd") + "') "; 
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                posteddate = "  between Convert ( DATE,'" + DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd") + "') and Convert( DATE,'" + date.ToString("yyyy/MM/dd") + "') ";

            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                posteddate = "  between Convert ( DATE,'" + DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd") + "') and Convert ( DATE,'" + date.ToString("yyyy/MM/dd") + "') ";

            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                posteddate = "  between Convert ( DATE,'" + DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd") + "') and Convert ( DATE,'" + date.ToString("yyyy/MM/dd") + "') ";

            }
            else  
            {
                posteddate = "  between Convert ( DATE,'" + DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd") + "') and Convert ( DATE,'" + date.ToString("yyyy/MM/dd") + "') ";

            }
            return posteddate;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            DDCity.ClearSelection();
            DDJobCategory.ClearSelection();
            RadioButtonList1.SelectedValue = "0";
            RBSelectedColorChange();
            showjoblist();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                bool  isCondition = false;
                string subquery = string.Empty;
                string jobtype = string.Empty;
                string posteddate = string.Empty;
                string addAnd = string.Empty;
                string query = string.Empty;
                List<string> querylist = new List<string>();
                Sqlconn.OpenConection();
                if (DDCity.SelectedValue !="0")
                {
                    querylist.Add(" state ='" + DDCity.SelectedValue + "' ");
                    isCondition = true;
              }
                jobtype = selectedCheckbox();
                if (jobtype != "")
                {
                    querylist.Add(" jobtype IN  (" + jobtype + " ) ");
                    isCondition = true;
                }
                if (RadioButtonList1.SelectedValue != "0")
                {
                    posteddate = selectedRadoiButton();
                    querylist.Add(" Convert(DATE,CreateDate)  " + posteddate);
                    isCondition = true;
                }
                if (isCondition)
                {
                    foreach (string a in querylist)
                    {
                        subquery += a + " and ";
                    }
                    subquery = subquery.Remove(subquery.LastIndexOf("and"), 3);
                    query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate ,Jobcategory  from  jobs where " + subquery + " ";
                }
                else 
                {
                    query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate ,Jobcategory  from  jobs  ";

                }
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showjoblist();
                RBSelectedColorChange();
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

        void RBSelectedColorChange()
        {
            if (RadioButtonList1.SelectedItem.Selected == true)
            {
                RadioButtonList1.SelectedItem.Attributes.Add("class","selectedradio");
            }
        }
    }
}