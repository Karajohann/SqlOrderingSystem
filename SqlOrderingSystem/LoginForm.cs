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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }  

        //Εδώ ξέρω ότι την όλη διαδικασία την κάνω στο κουμπί αλλά θέλω να μελετήσω ακόμα το GetHasCode και να το φτιάξω μετά
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string Password = textBox2.Text;
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Τα πεδία δεν μπορεί να είναι κενά");
            }
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Giannis\Documents\GitHub\SqlOrderingSystem\SqlOrderingSystem\Logger.mdf;Integrated Security=True");
                try
                {
                    string query = @"SELECT Count(*) FROM LOGINFOS WHERE USERNAME = @Username AND PASSWORD = @Password";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ο χρήστης δεν υπάρχει");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.ToString());
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
    }
}
