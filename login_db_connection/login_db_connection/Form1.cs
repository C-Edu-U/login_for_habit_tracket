using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace login_db_connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Enter your username");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Enter your password");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-B8A13KT\\SQLEXPRESS;Initial Catalog=habit_tracker_db;Integrated Security=True;Encrypt=False");
                    SqlCommand cmd = new SqlCommand("select * from tbl_user where username = @username and password = @password", conn);
                    cmd.Parameters.AddWithValue("@username",textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login Successfull");
                    }
                    else
                    {
                        MessageBox.Show("Username or password is invalid");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

    }
}
