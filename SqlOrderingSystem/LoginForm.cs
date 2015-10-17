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

namespace SqlOrderingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string Password = textBox2.Text;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Giannis\Documents\GitHub\SqlOrderingSystem\SqlOrderingSystem\Logger.mdf;Integrated Security=True");
                try
                {
                    string queryText = @"SELECT Count(*) FROM LOGINFOS 
                             WHERE username = @Username AND password = @Password";
                    SqlCommand cmd = new SqlCommand(queryText, cn);
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        MessageBox.Show("Loggen In!");
                        DialogResult = DialogResult.OK;
                        cn.Close();
                    }
                    else
                    {
                        MessageBox.Show("User Not Found!");
                        SqlConnection.ClearAllPools();
                    }
                }
                catch(SqlException exception)
                {
                    MessageBox.Show(exception.ToString());
                }
                finally
                {
                    if(cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                }

            }
            SqlConnection.ClearAllPools();
            textBox1.Clear();
            textBox2.Clear();

        }
    }
}
