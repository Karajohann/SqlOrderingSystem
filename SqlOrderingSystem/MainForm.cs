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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnRefresh, "Ανανέωση");
            SqlCustomerFunctions.Read(this.dataGridView1);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm_Load(this, null);
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm ACF = new AddCustomerForm();
            ACF.Show();
        }
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            UpdateFormCustomer UFC = new UpdateFormCustomer(ParsedCustomer());
            UFC.Show();
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Αν ο πελάτης έχει ενεργές παραγγελίες θα σβηστούν και αυτές.\n Είστε σίγουροι ότι θέλετε αυτήν την διαγραφή;", "Προσοχή!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlOrdersFunctions.Delete(ParsedCustomer());
                SqlCustomerFunctions.Delete(ParsedCustomer());
                MainForm_Load(this, null);
            }
        }
        private void btnOrdersCustomer_Click(object sender, EventArgs e)
        {
            OrdersCustomerForm OF = new OrdersCustomerForm(ParsedCustomer());
            OF.Show();
        }
        private void btnAllOrders_Click(object sender, EventArgs e)
        {
            AllOrdersForm AOF = new AllOrdersForm();
            AOF.Show();
        }
        private Customer ParsedCustomer()
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            int id = Convert.ToInt32(row.Cells[0].Value.ToString());
            string firstname = row.Cells[1].Value.ToString();
            string lastname = row.Cells[2].Value.ToString();
            string telephone = row.Cells[3].Value.ToString();
            string address = row.Cells[4].Value.ToString();
            var Cust = new Customer();
            Cust.ID = id;
            Cust.FirstName = firstname;
            Cust.LastName = lastname;
            Cust.Telephone = telephone;
            Cust.Address = address;
            return Cust;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlConnection.ClearAllPools();
        }








    }

}
