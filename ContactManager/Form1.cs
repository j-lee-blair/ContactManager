//Julian 131118
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignemnt_5
{
    public partial class MainForm : Form
    {
        private ContactManager contactMgr;

        public MainForm()
        {
            InitializeComponent();
            cmbCountries.DataSource = Enum.GetValues(typeof(Countries));
            contactMgr = new ContactManager();
        }

        private bool ValidateInput()
        {
            if (txtNameFirst.Text == string.Empty)
            {
                MessageBox.Show("Enter First Name", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            else if (txtNameLast.Text == string.Empty)
            {
                MessageBox.Show("Enter Last Name", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            else if (txtCity.Text == string.Empty)
            {
                MessageBox.Show("Enter City", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            else if (txtStreet.Text == string.Empty)
            {
                MessageBox.Show("Enter Street Name", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            else if (txtZipCode.Text == string.Empty)
            {
                MessageBox.Show("Enter ZipCode", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            else if (cmbCountries.SelectedIndex == -1)
            {
                MessageBox.Show("Select Country!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }

        private Address AddContact()
        {
            Address a = new Address(txtStreet.Text.Trim(), txtZipCode.Text.Trim(), txtCity.Text.Trim(), (Countries)cmbCountries.SelectedIndex);
            return a;
        }

        private void UpdateGUI()
        {
            lstResults.Items.Clear();
            lstResults.Items.AddRange(contactMgr.GetContactInfo());
            lblCount.Text = lstResults.Items.Count.ToString();
        }

        /// <summary>
        /// updates contacts using registry array
        /// </summary>
        private void UpdateContactInfoFromRegistry() //what ever you select gets put back into the textboxes
        {
            Contact contact = contactMgr.ValidateContactEntry(lstResults.SelectedIndex);

            cmbCountries.SelectedIndex = (int)contact.AddressData.Country;
            txtNameFirst.Text = contact.FirstName;
            txtNameLast.Text = contact.LastName;
            txtCity.Text = contact.AddressData.City;
            txtStreet.Text = contact.AddressData.Street;
            txtZipCode.Text = contact.AddressData.ZipCode;
        }
        /// <summary>
        /// updates fields with data at selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContactInfoFromRegistry();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                contactMgr.AddContact(new Contact(txtNameFirst.Text, txtNameLast.Text, AddContact()));
                UpdateGUI();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex == -1)
            {
                MessageBox.Show("Select position in list!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
            if (lstResults.SelectedIndex != -1)
            {
                if (ValidateInput())
                {
                    contactMgr.ChangeContact(new Contact(txtNameFirst.Text, txtNameLast.Text, AddContact()), lstResults.SelectedIndex);
                    UpdateGUI();
                }
            }
        }
        /// <summary>
        /// Handles button event delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex == -1)
            {
                MessageBox.Show("Select position in list!");
            }

            if (lstResults.SelectedIndex != -1)
            {
                contactMgr.DeleteContact(lstResults.SelectedIndex);
                UpdateGUI();
            }
        }
    }
}
