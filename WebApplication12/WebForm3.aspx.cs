using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication12
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = TextBox1.Text;
            string s2 = TextBox2.Text;
            string s3 = TextBox4.Text +" " +TextBox3.Text;
            char gender;
            int cid;
            if (RadioButtonList1.SelectedIndex == 0)
            {
                gender = 'M';
            }
            else
            {
                gender = 'F';
            }
            string s4 = TextBox6.Text;
            string s5 = TextBox7.Text;
            SqlConnection a = new SqlConnection("Integrated Security = yes; database = infosys; data source = .");
            a.Open();
            String s7 = "select distinct cid from(select cid,DENSE_RANK() over(order by cid desc) as drk from usercredits)a where a.drk =1;";
            SqlCommand b = new SqlCommand(s7, a);
            object c = b.ExecuteScalar();
            int ci = Convert.ToInt32(c);
            cid = ci + 1;
            string s6 = "insert into usercredits values('" + cid + "','" + s1 + "','" + s2 + "')";

            SqlCommand d = new SqlCommand(s6, a);
            int f = d.ExecuteNonQuery();
            string s8 = "";
            if (f != 0)
            {
                s8 = "hai";
            }
            else
            {
                s8 = "check";
            }

            string s9 = "select distinct accountno from(select accountno,DENSE_RANK() over(order by accountno desc) as drk from cust_details)a where a.drk =1;";
            SqlCommand g = new SqlCommand(s9, a);
            object h = g.ExecuteScalar();
            long i = Convert.ToInt64(h);
            i = i + 1;

            string s11 = DropDownList1.SelectedValue;
            string s12 = TextBox9.Text;
            string s13 = TextBox5.Text;
            string s10 = "insert into cust_details values('" + cid + "','" + i + "','" + s3 + "','" + gender + "','" + TextBox8.Text + "' ,'" + s4 + "','" + s13 + "','" + s11 + "','" + s12 + "')";
            SqlCommand j = new SqlCommand(s10, a);
            int k = j.ExecuteNonQuery();
            string s14 = "insert into acc_details values('" + i + "','" + DropDownList2.SelectedValue + "','" + 0 + "','" + cid + "');";
            SqlCommand l = new SqlCommand(s14, a);
            int m = l.ExecuteNonQuery();
            Label1.Visible = true;

            if (k != 0)
            {
                if (s8 == "hai"&&m!=0)
                {
                    Label1.Text = "Sucessfully open bank account no " + i;
                }
            }
            else
            {
                Label1.Text = "Invalid credits";
            }
            a.Close();
        }
    }
}
