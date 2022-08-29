using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication12
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(Session["cid"]);
            
            //create connection using Sqlconnection class
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            //open Connection 
            a.Open();
            string p = "select bal from acc_details where cid = '"+cid+"';";
            SqlCommand b = new SqlCommand(p, a);
            object c = b.ExecuteScalar();
           
            double d = Convert.ToDouble(c);
            double f = 0;
            if (RadioButtonList1.SelectedIndex == 0)
            {
                f = Convert.ToDouble(TextBox1.Text);
                d = d + f;
            }
            else
            {
                f = Convert.ToDouble(TextBox1.Text);
                d = d - f;
            }
            p = "insert into trans values ('" + cid + "','" + RadioButtonList1.SelectedValue + "','" + TextBox2.Text + "','" + f + "','" + d + "');";
            SqlCommand g = new SqlCommand(p, a);
            int h = g.ExecuteNonQuery();
            if (RadioButtonList1.SelectedIndex == 0)
            {
                p = "update acc_details set bal = bal + '" + f + "' where cid ='" + cid + "';";
            }
            else
            {
                p = "update acc_details set bal = bal - '" + f + "' where cid ='" + cid + "';";
            }
            SqlCommand i = new SqlCommand(p, a);
            int k = i.ExecuteNonQuery();
            if (RadioButtonList1.SelectedIndex == 0)
            {
                p = "update bank_acc set bank_bal = bank_bal + '" + f + "';";
            }
            else
            {
                p = "update bank_acc set bank_bal = bank_bal - '" + f + "';";
            }
            SqlCommand l = new SqlCommand(p, a);
            int m = l.ExecuteNonQuery();
            
           
            
            p = "select bal from acc_details where cid ='" + cid + "';";
            SqlCommand n = new SqlCommand(p, a);
            object o = n.ExecuteScalar();
            Label1.Visible = true;
            if (h!=0 && k!=0 && m !=0)
            {
                Label1.Text = "Transaction Sucessfull Updated Balance is " + Convert.ToDouble(o);
            }
            else
            {
                Label1.Text = "Technical Error please try again";
            }
            a.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            a.Open();
            int cid = Convert.ToInt32(Session["cid"]);
            string p = "select bal from acc_details where cid ='" + cid + "';";
            SqlCommand n = new SqlCommand(p, a);
            object o = n.ExecuteScalar();
            double c = Convert.ToDouble(o);
            string b = c.ToString();
            Label1.Visible = true;
            Label1.Text = "account balance is " + c;
            a.Close();

        }
    }
}