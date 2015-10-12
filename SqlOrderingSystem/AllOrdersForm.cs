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
    public partial class AllOrdersForm : Form
    {
        public AllOrdersForm()
        {
            InitializeComponent();
        }

        private void AllOrdersForm_Load(object sender, EventArgs e)
        {
            SqlOrdersFunctions.Read(this.dataGridView1);
        }
    }
}
