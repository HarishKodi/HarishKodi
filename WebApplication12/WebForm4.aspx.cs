using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication12
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            a.Open();
            string q = "select cid, sqst, ans from cust_details where accountno ='"+TextBox1.Text+"';";
            SqlCommand b = new SqlCommand(q, a);
            SqlDataReader c = b.ExecuteReader();
            string f = " ";
            string g = " ";
            int d = 0;
            while (c.Read())
            {
                d = Convert.ToInt32(c["cid"]);
                f = c["sqst"].ToString();
                g = c["ans"].ToString();
            }
            c.Close();
            string r = "update usercredits set pwd = '" + TextBox2.Text + "'where cid = '" + d + "';";
            if(f == DropDownList1.SelectedValue && g == TextBox4.Text) 
            {
                SqlCommand h = new SqlCommand(r, a);
                int i = h.ExecuteNonQuery();
                if (i != 0)
                {
                    Server.Transfer("WebForm1.aspx");
                }

                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Please Try Again!";
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please Try Again!";
            }
            a.Close();
        }
    }
}