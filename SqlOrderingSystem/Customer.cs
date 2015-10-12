using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOrderingSystem
{
    public class Customer
    {
        int _ID;
        string _firstName;
        string _lastName;
        string _telephone;
        string _address;

        public int ID
        {
            get
            {
                return this._ID;
            }

            set
            {
                _ID = value;
            }

        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                _telephone = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public Customer()
        {
        }

        public override string ToString()
        {
            return ID + "," + FirstName + "," + LastName + "," + Telephone + "," + Address;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Customer))
            {
                return false;
            }

            return this.ID == ((Customer)obj)._ID ^ this.LastName == ((Customer)obj)._lastName;
        }

        public override int GetHashCode()
        {
            return this._ID.GetHashCode() ^ this._firstName.GetHashCode();
        }
    }
}
