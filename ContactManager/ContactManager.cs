//Julian 13111
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnt_5
{
     class ContactManager
    {
        private List<Contact> m_contactRegistry;

        public ContactManager()
        {
            m_contactRegistry = new List<Contact>();
        }

        /// <summary>
        /// Add a contact
        /// </summary>
        /// <param name="ContactIn"></param>
        /// <returns></returns>
        public bool AddContact(Contact ContactIn)
        {
            m_contactRegistry.Add(ContactIn);
            return true;
        }

        /// <summary>
        /// Edits existing Conctact
        /// </summary>
        /// <param name="contactIn"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ChangeContact(Contact contactIn, int index)
        {
            m_contactRegistry.RemoveAt(index);
            m_contactRegistry.Insert(index, contactIn);
            return true;
        }

        /// <summary>
        /// deletes contact
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteContact(int index)
        {
            m_contactRegistry.RemoveAt(index);
            return true;
        
        }

        /// <summary>
        /// validity check 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Contact ValidateContactEntry(int index)
        {
            if (index < 0 || index >= m_contactRegistry.Count)
            {
                return null;
            }
            else return m_contactRegistry[index];
        }

        /// <summary>
        /// add to array of contacts
        /// </summary>
        /// <returns></returns>
        public string[] GetContactInfo()
        {
            string[] strInfoStrings = new string[m_contactRegistry.Count];

            int i = 0;
            foreach (Contact contactObj in m_contactRegistry)
            {
                strInfoStrings[i++] = contactObj.ToString();
            }
            return strInfoStrings;
        }
     }
}
