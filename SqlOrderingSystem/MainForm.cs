﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlOrderingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SqlCustomerFunctions.Read(this.dataGridView1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlCustomerFunctions.Read(this.dataGridView1);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm ACF = new AddCustomerForm();
            ACF.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCustomerFunctions.Delete(ParsedCustomer());
            MainForm_Load(this, null);
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            UpdateFormCustomer UFC = new UpdateFormCustomer(ParsedCustomer());
            UFC.Show();
        }
        public Customer ParsedCustomer()
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

        private void button4_Click(object sender, EventArgs e)
        {
            OrdersForm OF = new OrdersForm();
            OF.Show();
        }
    }
}
