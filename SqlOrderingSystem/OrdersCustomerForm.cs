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
    public partial class OrdersCustomerForm : Form
    {
        public OrdersCustomerForm(Customer _customer)
        {
            InitializeComponent();
            label1.Text = _customer.ID.ToString();
            label2.Text = _customer.FirstName;
            label2.Dock = DockStyle.Left | DockStyle.Top;
            label3.Text = _customer.LastName;
            label3.Dock = DockStyle.Left | DockStyle.Top;
            label4.Text = _customer.Telephone;
            label6.Text = _customer.Address;
        }    
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            SqlOrdersFunctions.Read(this.dataGridView1, ParsedCustomer());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlOrdersFunctions.Create(ParsedCustomer(), ParsedOrder());
            textBox1.Clear();
            OrdersForm_Load(this, null);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlOrdersFunctions.Update(ParsedOrder());
            textBox1.Clear();
            OrdersForm_Load(this, null);
        } 
        private void button3_Click(object sender, EventArgs e)
        {
            SqlOrdersFunctions.Delete(ParsedOrder());
            OrdersForm_Load(this, null);
        }
        private Customer ParsedCustomer()
        {
            int id = Convert.ToInt32(label1.Text);
            string firstname = label2.Text;
            string lastname = label3.Text;
            string telephone = label4.Text;
            string address = label6.Text;
            var Cust = new Customer();
            Cust.ID = id;
            Cust.FirstName = firstname;
            Cust.LastName = lastname;
            Cust.Telephone = telephone;
            Cust.Address = address;
            return Cust;
        }  
        private Order ParsedOrder()
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            var order1 = new Order();
            order1.Description = textBox1.Text;
            order1.Orderno = Convert.ToInt32(row.Cells[0].Value.ToString());
            return order1;
        }



    }
}
