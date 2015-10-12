﻿using System;
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
        static private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\CustomersDB.mdf;Integrated Security=True");
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
                string query = "SELECT * FROM Orders WHERE IDCUSTOMER =" + _customer.ID.ToString();
                SqlDataAdapter DA = new SqlDataAdapter(query, connection);
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

        static public void Create(Customer _customer, Order _order)
        {
            connection.Open();
            try
            {
                string query = "INSERT INTO Orders (IDCUSTOMER, DΕSCRIPTION) VALUES (@idcustomer,@description)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idcustomer", _customer.ID);
                cmd.Parameters.AddWithValue("@description", _order.Description);
                cmd.ExecuteNonQuery();

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

        static public void Update(Order _order)
        {
            connection.Open();
            try
            {
                string query = "UPDATE Orders SET DΕSCRIPTION = @description WHERE ORDERNO LIKE @orderno";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@description", _order.Description);
                cmd.Parameters.AddWithValue("@orderno", _order.Orderno);
                cmd.ExecuteNonQuery();
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
             /// <summary>
             /// Διαγράφη όλες τις παραγγελίες του Πελάτη
             /// </summary>
             /// <param name="_customer"></param>
        static public void Delete(Customer _customer)
        {
            connection.Open();
            try
            {
                string query = "DELETE FROM Orders where IDCUSTOMER = @idcustomer";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idcustomer", _customer.ID);
                cmd.ExecuteNonQuery();
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

        /// <summary>
        /// Διαγράφει μόνο μία παραγγελία
        /// </summary>
        /// <param name="_order"></param>
        static public void Delete(Order _order)
        {
            connection.Open();
            try
            {
                string query = "DELETE FROM Orders where ORDERNO = @orderno";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@orderno", _order.Orderno);
                cmd.ExecuteNonQuery();
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
    }
}
