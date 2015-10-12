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
    public partial class UpdateFormCustomer : Form
    {
        public UpdateFormCustomer(Customer _existcustomer)
        {
            InitializeComponent();
            IdLabel.Text = "ID Πελάτη : ";
            IDBox.Text = _existcustomer.ID.ToString();
            ExistFNameBox.Text = _existcustomer.FirstName;
            ExistLNameBox.Text = _existcustomer.LastName;
            ExistTelBox.Text = _existcustomer.Telephone;
            ExistAddressBox.Text = _existcustomer.Address;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.ID = Convert.ToInt32(IDBox.Text);
            if (ReplaceFNameBox.Text == string.Empty || ReplaceFNameBox == null)
            {
                ReplaceFNameBox.Text = ExistFNameBox.Text;
                cust.FirstName = ReplaceFNameBox.Text;
            }
            else
            {
                cust.FirstName = ReplaceFNameBox.Text;
            }
            if (ReplaceLNameBox.Text == string.Empty || ReplaceLNameBox == null)
            {
                ReplaceLNameBox.Text = ExistLNameBox.Text;
                cust.LastName = ReplaceLNameBox.Text;
            }
            else
            {
                cust.LastName = ReplaceLNameBox.Text;
            }
            if (ReplaceTelBox.Text == string.Empty || ReplaceTelBox == null)
            {
                ReplaceTelBox.Text = ExistTelBox.Text;
                cust.Telephone = ReplaceTelBox.Text;
            }
            else
            {
                cust.Telephone = ReplaceTelBox.Text;
            }
            if (ReplaceAddressBox.Text == string.Empty || ReplaceAddressBox == null)
            {
                ReplaceAddressBox.Text = ExistAddressBox.Text;
                cust.Address = ReplaceAddressBox.Text;
            }
            else
            {
                cust.Address = ReplaceAddressBox.Text;
            }

            SqlCustomerFunctions.Update(cust);
            this.FindForm().Dispose();
        }
    }
}
