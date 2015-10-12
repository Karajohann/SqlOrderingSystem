using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOrderingSystem
{
    class Order
    {
        int _orderno;
        public int Orderno
        {
            get { return _orderno; }
            set { _orderno = value; }
        }

        int _idcustomer;
        public int Idcustomer
        {
            get { return _idcustomer; }
            set { _idcustomer = value; }
        }

        string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public override string ToString()
        {
            return _orderno.ToString() + "," + _idcustomer.ToString() + "," + _description.ToString();
        }
    }
}
