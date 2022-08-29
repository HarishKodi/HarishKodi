using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication12
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = TextBox1.Text;
            string s2 = TextBox2.Text;
            SqlConnection a = new SqlConnection("Integrated Security = yes; database = infosys; data source = .");
            a.Open();

            string s3 = "select count(*) from usercredits where usid ='" + s1 + "' and pwd ='" + s2 + "';";
            SqlCommand b = new SqlCommand(s3, a);
            object i = b.ExecuteScalar();
            string ci = "select cid from usercredits where usid = '" + s1 + "';";
            SqlCommand j = new SqlCommand(ci, a);
            object k = j.ExecuteScalar();
            string cid = k.ToString();
            if ((int)i != 0)
            {
                Session["cid"] = cid;
                Server.Transfer("WebForm2.aspx");

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid Credits";
            }
            a.Close();
           

            
        }
    }
}