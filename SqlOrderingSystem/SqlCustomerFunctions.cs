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
    static class SqlCustomerFunctions
    {
        static private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Giannis\Documents\GitHub\SqlOrderingSystem\SqlOrderingSystem\CustomersDB.mdf;Integrated Security=True");

        static public void Read(DataGridView _datagridview)
        {
            connection.Open();
            try
            {
                SqlDataAdapter DA = new SqlDataAdapter(@"SELECT * FROM [Customers]", connection);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                _datagridview.DataSource = DT;
                _datagridview.Columns[1].HeaderText = "Όνομα";
                _datagridview.Columns[2].HeaderText = "Επώνυμο";
                _datagridview.Columns[3].HeaderText = "Τηλέφωνο";
                _datagridview.Columns[4].HeaderText = "Διεύθυνση";

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

        static public void Create(Customer _customer)
        {
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Customers (FIRSTNAME, LASTNAME, TELEPHONE, ADDRESS) VALUES (@fname, @lname, @tel, @address)", connection);
                cmd.Parameters.AddWithValue("@fname", _customer.FirstName);
                cmd.Parameters.AddWithValue("@lname", _customer.LastName);
                cmd.Parameters.AddWithValue("@tel", _customer.Telephone);
                cmd.Parameters.AddWithValue("@address", _customer.Address);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        static public void Update(Customer _customer)
        {
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE Customers SET FIRSTNAME = @fname, LASTNAME = @lname, TELEPHONE = @telephone, ADDRESS = @address WHERE ID LIKE @ID", connection);
                cmd.Parameters.AddWithValue("@ID", _customer.ID);
                cmd.Parameters.AddWithValue("@fname", _customer.FirstName);
                cmd.Parameters.AddWithValue("@lname", _customer.LastName);
                cmd.Parameters.AddWithValue("@telephone", _customer.Telephone);
                cmd.Parameters.AddWithValue("@address", _customer.Address);
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

        static public void Delete(Customer _customer)
        {
            connection.Open();
            try
            {
                string query = "DELETE FROM Customers where ID LIKE @CODE";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CODE", _customer.ID);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
