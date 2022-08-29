using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication12
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            a.Open();
            
            string p = "select bal from acc_details where accountno ='" + TextBox1.Text + "';";
            SqlCommand n = new SqlCommand(p, a);
            
            object o = n.ExecuteScalar();
            double c = Convert.ToDouble(o);
            string b = c.ToString();
            Label1.Visible = true;
            Label1.Text = "account balance is " + c;
            a.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            a.Open();
            string p = "select cid, bal from acc_details where accountno = '"+TextBox1.Text+"';";
            SqlCommand i = new SqlCommand(p, a);
            SqlDataReader o = i.ExecuteReader();
            string s1 = " ";
            string s2 = " ";
            if(o.Read())
            {
                
                s1 = o[0].ToString();
                s2 = o[1].ToString();
            }
            o.Close();
            double y = Convert.ToDouble(s2);
            double z=Convert.ToDouble(TextBox3.Text);
            double w = y + z;
            string s4 = "Deposit";
            p = "insert into trans values ('" + s1 + "', '"+s4+"' ,'" + TextBox4.Text + "','" + TextBox3.Text + "','" + w + "');";
            SqlCommand g = new SqlCommand(p, a);
            int h = g.ExecuteNonQuery();
            p = "update acc_details set bal = bal + '" + TextBox3.Text + "' where cid ='" + s1 + "';";
            SqlCommand k = new SqlCommand(p, a);
            int f = k.ExecuteNonQuery();
            p = "update bank_acc set bank_bal = bal + '" + TextBox3.Text + "';";
            SqlCommand n = new SqlCommand(p, a);
            int x = k.ExecuteNonQuery();
            Label1.Visible = true;
            if(h!=0 && f!=0 && x != 0)
            {
                Label1.Text = "Sucesfully transfered amount";
            }
            else
            {
                Label1.Text = "Invaid Input";
            }
            a.Close();

            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            a.Open();
            string p = "select cid, bal from acc_details where accountno = '" + TextBox1.Text + "';";
            SqlCommand i = new SqlCommand(p, a);
            SqlDataReader o = i.ExecuteReader();
            string s1 = " ";
            string s2 = " ";
            if (o.Read())
            {
                s1 = o[0].ToString();
                s2 = o[1].ToString();
            }
            o.Close();
            double y = Convert.ToDouble(s2);
            double z = Convert.ToDouble(TextBox3.Text);
            double w = y + z;
            string s4 = "Withdraw";
            p = "insert into trans values ('" + s1 + "', '"+s4+"' ,'" + TextBox4.Text + "','" + TextBox3.Text + "','" + w + "');";
            SqlCommand g = new SqlCommand(p, a);
            int h = g.ExecuteNonQuery();
            p = "update acc_details set bal = bal - '" + TextBox3.Text + "' where cid ='" + s1 + "';";
            SqlCommand k = new SqlCommand(p, a);
            int f = k.ExecuteNonQuery();
            p = "update bank_acc set bank_bal = bal - '" + TextBox3.Text + "';";
            SqlCommand n = new SqlCommand(p, a);
            int x = k.ExecuteNonQuery();
            Label1.Visible = true;
            if (h != 0 && f != 0 && x != 0)
            {
                Label1.Text = "Sucesfully transfered amount";
            }
            else
            {
                Label1.Text = "Invaid Input";
            }
            a.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            a.Open();
            string p = "select cid, bal from acc_details where accountno = '" + TextBox1.Text + "';";
            SqlCommand i = new SqlCommand(p, a);
            SqlDataReader o = i.ExecuteReader();
            string s3 = " ";
            string s2 = " ";
            if (o.Read())
            {
                s3 = o[0].ToString();
                s2 = o[1].ToString();
            }
            o.Close();

            p = "select * from trans where cid = '"+s3+"'";
            SqlCommand q = new SqlCommand(p, a);
            SqlDataReader r = q.ExecuteReader();
            Label1.Text = " ";
            string s1;
            if (r.Read())
            {
                while (r.Read())
                {
                    Label1.Visible = true;
                    s1 = r[0].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[1].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[2].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[3].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[4].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                }
                r.Close();
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid credits";
            }
            a.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection a = new SqlConnection("integrated Security = yes; database = infosys; data source = .");
            a.Open();
            string p = "select accountno, cname,gender,odt,dob,adrs from cust_details where accountno ='"+TextBox1.Text+"'";
            SqlCommand q = new SqlCommand(p, a);
            SqlDataReader r = q.ExecuteReader();
            Label1.Text = " ";
            string s1;
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Label1.Visible = true;
                    s1 = r[0].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[1].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[2].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[3].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    s1 = r[4].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                    
                    s1 = r[5].ToString();
                    Label1.Text = Label1.Text + s1 + "\n";
                }
                r.Close();
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Invalid credits";
            }
            a.Close();
        }
    }
}