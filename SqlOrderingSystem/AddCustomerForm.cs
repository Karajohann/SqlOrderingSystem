using System;
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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCustomerFunctions.Create(ParsedCustomer());
            this.FindForm().Dispose();
        }  
        private Customer ParsedCustomer()
        {
            var cust = new Customer();
            cust.FirstName = textBox1.Text;
            cust.LastName = textBox2.Text;
            cust.Telephone = textBox3.Text;
            cust.Address = textBox4.Text;
            return cust;
        }


    }
}
