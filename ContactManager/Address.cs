//Julian 131118
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt_5
{
    class Address
    {
        private string m_street;
        private string m_zipCode;
        private string m_city;
        private Countries m_country;

        public string Street { get { return m_street; } }
        public string City { get { return m_city; } }
        public string ZipCode { get { return m_zipCode; } }
        public Countries Country { get { return m_country; } }
        
        public Address(string street, string zip, string city, Countries country) //enum to be written
        {
            m_street = street;
            m_zipCode = zip;
            m_city = city;
            m_country = country;
        }

        /// <summary>
        /// Formats the country names in Enum
        /// </summary>
        /// <returns></returns>
        public string GetCountryString()
        {
            string strCountry = m_country.ToString();
            strCountry = strCountry.Replace("_", " ");
            return strCountry;
        }

        /// <summary>
        /// formats the strings containing city, name, zipcode and Enum
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string strOut = string.Format("{0, -10} \t{1, -10}\t{2, -10}\t{3, 10}", m_street, m_zipCode, m_city, GetCountryString());
            return strOut;
        }
    }
}
