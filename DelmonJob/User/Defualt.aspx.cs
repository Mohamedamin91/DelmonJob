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
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showjoblist();
              
            }
        }
        public void showjoblist()
        {
            if (dt == null)
            {
                Sqlconn.OpenConection();
                SqlConnection con = new SqlConnection(Sqlconn.ConnectionString);
                SqlCommand cmd;
                query = "Select   JobID, Title, salary, jobtype, companyname , CompanyLogo, Country, state, CreateDate,Jobcategory  from  jobs where CreateDate >= cast(dateadd(day, -10, getdate()) as date)  and CreateDate<cast(getdate() as date) ";
                cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
          //  lbljobcount.Text = jobCount(dt.Rows.Count);
            Sqlconn.CloseConnection();
        }
        //Setting defualt image if their no image for any job 
        protected string GetimageUrl(Object url)
        {
            string urll = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                urll = "../assets/img/Defualtcompany.png";
            }
            else
            {
                urll = string.Format("~/(0)", url);
            }
            return ResolveUrl(urll);
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