using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication12
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source=.");
            a.Open();
            string s1 = "select count(*) from admin1 where a_id = '"+TextBox1.Text+"' and a_pass = '"+TextBox2.Text+"';";
            SqlCommand b = new SqlCommand(s1, a);
            object c = b.ExecuteScalar();
            if ((int)c != 0)
            {
                Server.Transfer("Admin.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid Admin";
            }
        }
    }
}