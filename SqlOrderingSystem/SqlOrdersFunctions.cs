using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace SqlOrderingSystem
{
    class SqlOrdersFunctions
    {
        static private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Giannis\Dropbox\GitHub\SqlOrderingSystem\SqlOrderingSystem\CustomersDB.mdf;Integrated Security=True");
        static public void Read(DataGridView _datagridview)
        {
            try
            {
                connection.Open();
                SqlDataAdapter DA = new SqlDataAdapter(@"SELECT * FROM [Orders]", connection);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                _datagridview.DataSource = DT;

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        static public void Read(DataGridView _datagridview, Customer _customer)
        {
            connection.Open();
            try
            {
                string query = "SELECT * FROM [Orders] WHERE ID LIKE " + _customer.ID.ToString();
                SqlDataAdapter DA = new SqlDataAdapter(query,connection);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                _datagridview.DataSource = DT;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        static public void Create()
        {

        }

        static public void Update()
        {

        }

        static public void Delete()
        {

        }
    }
}
