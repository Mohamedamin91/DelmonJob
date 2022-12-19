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
    public partial class Defualt : System.Web.UI.Page
    {
        SQLCONNECTION Sqlconn = new SQLCONNECTION();
        string query = "";
        public int jobcount = 0;
        DataTable dt1;
        DataTable dt2;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showjoblist();
                showjobCategorylist();
              
            }
        }
        public void showjoblist()
        {
            if (dt1 == null)
            {
                Sqlconn.OpenConection();
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate,Jobcategory  from  jobs where CreateDate >= cast(dateadd(day, -10, getdate()) as date)  and CreateDate<cast(getdate() as date) ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt1 = new DataTable();
                sda.Fill(dt1);
            }
            DataList1.DataSource = dt1;
            DataList1.DataBind();
          //  lbljobcount.Text = jobCount(dt.Rows.Count);
            Sqlconn.CloseConnection();
        }

        public void showjobCategorylist()
        {
            if (dt2 == null)
            {
                Sqlconn.OpenConection();
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                query = " select Jobcategory, COUNT(Jobcategory) as Count  from Jobs  group by Jobs.Jobcategory ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt2 = new DataTable();
                sda.Fill(dt2);
            }
           
            if (dt2.Rows.Count > 0)
            {
                Session["Jobs"] = dt2.Rows[0][1];
            }
            else
            {
                Session["Jobs"] = 0;

            }
            DataList2.DataSource = dt2;
            DataList2.DataBind();
            //  lbljobcount.Text = jobCount(dt.Rows.Count);
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
    }
}