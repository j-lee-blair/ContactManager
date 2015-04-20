//Julian 131118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt_5
{
    class Contact
    {
        private string m_firstName = string.Empty;
        private string m_LastName = string.Empty;
        private Address m_address;

        public Address AddressData { get { return m_address; } }
        public string FirstName { get { return m_firstName; } }
        public string LastName { get { return m_LastName; } }
        public string FullName { get { return LastName + ", " + FirstName; } }

        public Contact(string firstName, string lastName, Address adr)
        {
            m_firstName = firstName;
            m_LastName = lastName;
            m_address = adr;
        }

        /// <summary>
        /// formats contact details
        /// <returns></returns>
        public override string ToString()
        {
            string strOut = string.Format("{0,-20} {1}", FullName, m_address.ToString());
            return strOut;
        }
    }
}
