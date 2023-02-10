using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechDatabase.Validator;
using HiTechDatabase.DataAccess;
using HiTechDatabase.Business;
using System.Data.SqlClient;

namespace Hi_Tech_Management_Final_Project.GUI
{
    public partial class FormCustomerMaintenance : Form
    {
        public FormCustomerMaintenance()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataSet dsHiTechDB;
        DataTable dtCustomers;
        DataTable dtOrders;
        DataTable dtOrderLines;
        SqlCommandBuilder sqlBuilder;
        DataRelation dr1;
        DataRelation dr2;

        private void FormCustomerMaintenance_Load(object sender, EventArgs e)
        {
            dsHiTechDB = new DataSet("HiTechDB");
            dtCustomers = new DataTable("Customers");
            dtCustomers.Columns.Add("CustomerID", typeof(Int32));
            dtCustomers.Columns.Add("CustomerName", typeof(string));
            dtCustomers.Columns.Add("StreetAddress", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PostalCode", typeof(string));
            dtCustomers.Columns.Add("PhoneNumber", typeof(string));
            dtCustomers.Columns.Add("FaxNumber", typeof(string));
            dtCustomers.Columns.Add("CreditLimit", typeof(Int32));
            dtCustomers.Columns.Add("Email", typeof(string));
            dtCustomers.PrimaryKey = new DataColumn[] { dtCustomers.Columns["CustomerID"] };
            dsHiTechDB.Tables.Add(dtCustomers);

            dtOrders = new DataTable("Orders");
            dtOrders.Columns.Add("OrderID", typeof(Int32));
            dtOrders.Columns.Add("OrderDate", typeof(DateTime));
            dtOrders.Columns.Add("OrderType", typeof(string));
            dtOrders.Columns.Add("RequiredDate", typeof(DateTime));
            dtOrders.Columns.Add("ShippingDate", typeof(DateTime));
            dtOrders.Columns.Add("StatusID", typeof(Int32));
            dtOrders.Columns.Add("EmployeeID", typeof(Int32));
            dtOrders.Columns.Add("CustomerID", typeof(Int32));
            dtOrders.Columns.Add("Payment", typeof(Int32));
            dtOrders.PrimaryKey = new DataColumn[] { dtOrders.Columns["OrderID"] };
            dsHiTechDB.Tables.Add(dtOrders);

            dtOrderLines = new DataTable("OrderDetails");
            dtOrderLines.Columns.Add("OrderID", typeof(Int32));
            dtOrderLines.Columns.Add("ISBN", typeof(string));
            dtOrderLines.Columns.Add("QuantityOrdered", typeof(Int32));
            dsHiTechDB.Tables.Add(dtOrderLines);

            dr1 = new DataRelation("reOsOLs", dtOrders.Columns["OrderID"], dtOrderLines.Columns["OrderID"]);
            dr2 = new DataRelation("reOsCs", dtCustomers.Columns["CustomerID"], dtOrders.Columns["CustomerID"]);

            da = new SqlDataAdapter("SELECT * FROM Orders", UtilityDB.connectDB());
            sqlBuilder = new SqlCommandBuilder(da);
            da.Fill(dsHiTechDB.Tables["Orders"]);

            da = new SqlDataAdapter("SELECT * FROM OrderDetails", UtilityDB.connectDB());
            sqlBuilder = new SqlCommandBuilder(da);
            da.Fill(dsHiTechDB.Tables["OrderDetails"]);

            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.connectDB());
            sqlBuilder = new SqlCommandBuilder(da);
            da.Fill(dsHiTechDB.Tables["Customers"]);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string customerId = textBoxCustomer_Id.Text.Trim();
            string customerName = textBoxCustomer_Name.Text.Trim();
            string streetAddress = textBoxStreet_Name.Text.Trim();
            string faxNumber = textBoxFaxNumber.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string postCode = textBoxPostal_Code.Text.Trim();
            string PhoneNumber = maskedTextBoxPhoneNum.Text.Trim();
            string Email = textBoxContact_Email.Text.Trim();
            string CreditLimit = textBoxCredit_Limit.Text.Trim();
            if (Validator.IsEmpty(customerId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Focus();
                return;
            }

            if (Validator.IsEmpty(customerName))
            {
                MessageBox.Show("Customer Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Name.Focus();
                return;
            }

            if (Validator.IsEmpty(streetAddress))
            {
                MessageBox.Show("Street Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreet_Name.Focus();
                return;
            }

            if (Validator.IsEmpty(faxNumber))
            {
                MessageBox.Show("Province is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFaxNumber.Focus();
                return;
            }

            if (Validator.IsEmpty(city))
            {
                MessageBox.Show("City is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Focus();
                return;
            }

            if (Validator.IsEmpty(postCode))
            {
                MessageBox.Show("Postal Code is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostal_Code.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNum.MaskCompleted)
            {
                MessageBox.Show("Please enter your phone number (e.g (514)-111-1111).", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNum.Clear();
                maskedTextBoxPhoneNum.Focus();
                return;
            }

            if (Validator.IsEmpty(Email))
            {
                MessageBox.Show("Contact Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContact_Email.Focus();
                return;
            }

            if (Validator.IsEmpty(CreditLimit))
            {
                MessageBox.Show("Credit Limit is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFaxNumber.Focus();
                return;
            }

            // Checking Invalid Information
            if (!Validator.IsValidId(customerId, 6))
            {
                MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Clear();
                textBoxCustomer_Id.Focus();
                return;
            }

            if (!Validator.IsValidString(customerName))
            {
                MessageBox.Show("Customer Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Name.Clear();
                textBoxCustomer_Name.Focus();
                return;
            }

            if (!Validator.IsValidString(city))
            {
                MessageBox.Show("City can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }

            if (!Validator.IsValidString(streetAddress))
            {
                MessageBox.Show("Street Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreet_Name.Clear();
                textBoxStreet_Name.Focus();
                return;
            }

            if (!Validator.IsValidEmail(Email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContact_Email.Clear();
                textBoxContact_Email.Focus();
                return;
            }

            if (!Validator.IsValidPostal_Code(postCode))
            {
                MessageBox.Show("Please enter a valid Postal Code (e.g A1A 1A1).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostal_Code.Clear();
                textBoxPostal_Code.Focus();
                return;
            }

            if (!Validator.IsValidNumber(CreditLimit))
            {
                MessageBox.Show("Please enter a valid Credit Limit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCredit_Limit.Clear();
                textBoxCredit_Limit.Focus();
                return;
            }

            // Checking duplicate Customer_Id
            DataRow drCust = dtCustomers.NewRow();
            drCust = dtCustomers.Rows.Find(Convert.ToInt32(customerId));
            if (drCust != null)
            {
                MessageBox.Show("This Customer ID already exist.", "Duplicate Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Clear();
                textBoxCustomer_Id.Focus();
                return;
            }

            //When data is valid this will go
            if (MessageBox.Show("Do you want to save this Customer information? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                DataRow customerSave = dtCustomers.Rows.Add(Convert.ToInt32(customerId), customerName, streetAddress, city, postCode, PhoneNumber, faxNumber , Convert.ToInt32(CreditLimit), Email);
                
                MessageBox.Show("Locally Customer has been saved successfully.", "Save Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer has NOT been saved", "Save Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxCustomer_Id.Clear();
            textBoxCustomer_Name.Clear();
            textBoxFaxNumber.Clear();
            textBoxCity.Clear();
            textBoxStreet_Name.Clear();
            textBoxPostal_Code.Clear();
            textBoxContact_Email.Clear();
            textBoxCredit_Limit.Clear();
            maskedTextBoxPhoneNum.Clear();
            textBoxCustomer_Id.Focus();
        
    }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string customerId = textBoxCustomer_Id.Text.Trim();
            string customerName = textBoxCustomer_Name.Text.Trim();
            string streetAddress = textBoxStreet_Name.Text.Trim();
            string faxNumber = textBoxFaxNumber.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string postCode = textBoxPostal_Code.Text.Trim();
            string PhoneNumber = maskedTextBoxPhoneNum.Text.Trim();
            string Email = textBoxContact_Email.Text.Trim();
            string CreditLimit = textBoxCredit_Limit.Text.Trim();
            if (Validator.IsEmpty(customerId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Focus();
                return;
            }

            if (Validator.IsEmpty(customerName))
            {
                MessageBox.Show("Customer Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Name.Focus();
                return;
            }

            if (Validator.IsEmpty(streetAddress))
            {
                MessageBox.Show("Street Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreet_Name.Focus();
                return;
            }

            if (Validator.IsEmpty(faxNumber))
            {
                MessageBox.Show("Province is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFaxNumber.Focus();
                return;
            }

            if (Validator.IsEmpty(city))
            {
                MessageBox.Show("City is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Focus();
                return;
            }

            if (Validator.IsEmpty(postCode))
            {
                MessageBox.Show("Postal Code is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostal_Code.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNum.MaskCompleted)
            {
                MessageBox.Show("Please enter your phone number (e.g (514)-111-1111).", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNum.Clear();
                maskedTextBoxPhoneNum.Focus();
                return;
            }

            if (Validator.IsEmpty(Email))
            {
                MessageBox.Show("Contact Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContact_Email.Focus();
                return;
            }

            if (Validator.IsEmpty(CreditLimit))
            {
                MessageBox.Show("Credit Limit is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCredit_Limit.Focus();
                return;
            }

            // Checking Invalid Information
            if (!Validator.IsValidId(customerId, 6))
            {
                MessageBox.Show("User ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Clear();
                textBoxCustomer_Id.Focus();
                return;
            }

            if (!Validator.IsValidString(customerName))
            {
                MessageBox.Show("Customer Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Name.Clear();
                textBoxCustomer_Name.Focus();
                return;
            }

            if (!Validator.IsValidString(city))
            {
                MessageBox.Show("City can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }

            if (!Validator.IsValidString(streetAddress))
            {
                MessageBox.Show("Street Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreet_Name.Clear();
                textBoxStreet_Name.Focus();
                return;
            }


            if (!Validator.IsValidEmail(Email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContact_Email.Clear();
                textBoxContact_Email.Focus();
                return;
            }

            if (!Validator.IsValidPostal_Code(postCode))
            {
                MessageBox.Show("Please enter a valid Postal Code (e.g A1A 1A1).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostal_Code.Clear();
                textBoxPostal_Code.Focus();
                return;
            }

            if (!Validator.IsValidNumber(CreditLimit))
            {
                MessageBox.Show("Please enter a valid Credit Limit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCredit_Limit.Clear();
                textBoxCredit_Limit.Focus();
                return;
            }

            // Checking duplicate Customer_Id
            DataRow drCust = dtCustomers.NewRow();
            drCust = dtCustomers.Rows.Find(Convert.ToInt32(customerId));
            if (drCust == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Clear();
                textBoxCustomer_Id.Focus();
                return;
            }

            //When data is valid this will go
            if (MessageBox.Show("Do you want to update this Customer information? ", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
     
                drCust["CustomerName"] = customerName;
                drCust["streetAddress"] = streetAddress;
                drCust["City"] = city;
                drCust["PostalCode"] = postCode;
                drCust["PhoneNumber"] = PhoneNumber;
                drCust["FaxNumber"] = faxNumber;
                drCust["CreditLimit"] = Convert.ToInt32(CreditLimit);
                drCust["Email"] = Email;

                MessageBox.Show("Customer has been updated successfully.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer information has NOT been updated.", "Update Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxCustomer_Id.Clear();
            textBoxCustomer_Name.Clear();
            textBoxFaxNumber.Clear();
            textBoxCity.Clear();
            textBoxStreet_Name.Clear();
            textBoxPostal_Code.Clear();
            textBoxContact_Email.Clear();
            textBoxCredit_Limit.Clear();
            maskedTextBoxPhoneNum.Clear();
            textBoxCustomer_Id.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string customerId = textBoxCustomer_Id.Text.Trim();
            string customerName = textBoxCustomer_Name.Text.Trim();
            string streetAddress = textBoxStreet_Name.Text.Trim();
            string faxNumber = textBoxFaxNumber.Text.Trim();
            string city = textBoxCity.Text.Trim();
            string postCode = textBoxPostal_Code.Text.Trim();
            string PhoneNumber = maskedTextBoxPhoneNum.Text.Trim();
            string Email = textBoxContact_Email.Text.Trim();
            string CreditLimit = textBoxCredit_Limit.Text.Trim();
            if (Validator.IsEmpty(customerId))
            {
                MessageBox.Show("Customer ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Focus();
                return;
            }

            if (Validator.IsEmpty(customerName))
            {
                MessageBox.Show("Customer Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Name.Focus();
                return;
            }

            if (Validator.IsEmpty(streetAddress))
            {
                MessageBox.Show("Street Name is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreet_Name.Focus();
                return;
            }

            if (Validator.IsEmpty(faxNumber))
            {
                MessageBox.Show("Province is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFaxNumber.Focus();
                return;
            }

            if (Validator.IsEmpty(city))
            {
                MessageBox.Show("City is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Focus();
                return;
            }

            if (Validator.IsEmpty(postCode))
            {
                MessageBox.Show("Postal Code is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostal_Code.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNum.MaskCompleted)
            {
                MessageBox.Show("Please enter your phone number (e.g (514)-111-1111).", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNum.Clear();
                maskedTextBoxPhoneNum.Focus();
                return;
            }

            if (Validator.IsEmpty(Email))
            {
                MessageBox.Show("Contact Email is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContact_Email.Focus();
                return;
            }

            if (Validator.IsEmpty(CreditLimit))
            {
                MessageBox.Show("Credit Limit is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCredit_Limit.Focus();
                return;
            }

            // Checking Invalid Information
            if (!Validator.IsValidId(customerId, 6))
            {
                MessageBox.Show("User ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Clear();
                textBoxCustomer_Id.Focus();
                return;
            }

            if (!Validator.IsValidString(customerName))
            {
                MessageBox.Show("Customer Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Name.Clear();
                textBoxCustomer_Name.Focus();
                return;
            }

            if (!Validator.IsValidString(city))
            {
                MessageBox.Show("City can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }

            if (!Validator.IsValidString(streetAddress))
            {
                MessageBox.Show("Street Name can only contain characters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStreet_Name.Clear();
                textBoxStreet_Name.Focus();
                return;
            }

            if (!Validator.IsValidEmail(Email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContact_Email.Clear();
                textBoxContact_Email.Focus();
                return;
            }

            if (!Validator.IsValidPostal_Code(postCode))
            {
                MessageBox.Show("Please enter a valid Postal Code (e.g A1A 1A1).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPostal_Code.Clear();
                textBoxPostal_Code.Focus();
                return;
            }

            if (!Validator.IsValidNumber(CreditLimit))
            {
                MessageBox.Show("Please enter a valid Credit Limit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCredit_Limit.Clear();
                textBoxCredit_Limit.Focus();
                return;
            }

            // Checking duplicate Customer_Id
            DataRow drCust = dtCustomers.NewRow();
            drCust = dtCustomers.Rows.Find(Convert.ToInt32(customerId));
            if (drCust == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomer_Id.Clear();
                textBoxCustomer_Id.Focus();
                return;
            }

            //When data is valid this will go
            if (MessageBox.Show("Do you want to delete this Customer information? ", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                IEnumerable<DataRow> rowOrders = dtOrders.AsEnumerable().Where(r => r.Field<int>("CustomerID") == Convert.ToInt32(customerId));
                DataRow[] orderRows = rowOrders.ToArray();
                DataRow dr = dtOrders.NewRow();
                foreach (DataRow row in orderRows)
                {
                    dr = dtOrders.Rows.Find(row["OrderID"]);
                    dr["OrderStatus"] = 6;
                    da.Update(dtOrders);
                }

                da.Update(dtCustomers);
                MessageBox.Show("Customer's status is set to inactive.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer has NOT been deleted.", "Delete Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxCustomer_Id.Clear();
            textBoxCustomer_Name.Clear();
            textBoxFaxNumber.Clear();
            textBoxCity.Clear();
            textBoxStreet_Name.Clear();
            textBoxPostal_Code.Clear();
            textBoxContact_Email.Clear();
            textBoxCredit_Limit.Clear();
            maskedTextBoxPhoneNum.Clear();
            textBoxCustomer_Id.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult ex = MessageBox.Show("Niravkumar's & Rajdeep's Application ...\n\nDo you really want to exit ? ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ex == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void buttonListAllFromDS_Click(object sender, EventArgs e)
        {
            da.Fill(dsHiTechDB.Tables["Customers"]);
            dataGridViewCustomerDS.DataSource = dsHiTechDB.Tables["Customers"];
        }

        private void buttonListAllFromDB_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();
            List<Customers> listCust = new List<Customers>();
            listCust = cust.ListAllCustomer();
            listViewCustomer.Items.Clear();
            if (listCust.Count != 0)
            {
                foreach (var c in listCust)
                {
                    ListViewItem item = new ListViewItem(c.CustomerId.ToString());
                    item.SubItems.Add(c.CustomerName);
                    item.SubItems.Add(c.StreetAddress);
                    item.SubItems.Add(c.City);
                    item.SubItems.Add(c.PostalCode);
                    item.SubItems.Add(c.PhoneNumber.ToString());
                    item.SubItems.Add(c.FaxNumber.ToString());
                    item.SubItems.Add(c.CreditLimit.ToString());
                    item.SubItems.Add(c.Email);
                    listViewCustomer.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("There is no Customer in the database.", "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!Validator.IsValidId(textBoxCustomerSearch.Text.Trim(), 6))
            {
                MessageBox.Show("Customer Id must be 6 digit number.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBoxCustomerSearch.Clear();
                textBoxCustomerSearch.Focus();
                return;
            }

            int searchId = Convert.ToInt32(textBoxCustomerSearch.Text);
            DataRow dr = dtCustomers.Rows.Find(searchId);
            if (dr != null)
            {
                textBoxCustomer_Id.Text = dr["CustomerID"].ToString();
                textBoxCustomer_Name.Text = dr["CustomerName"].ToString();
                textBoxStreet_Name.Text = dr["StreetAddress"].ToString();
                textBoxCity.Text = dr["City"].ToString();
                textBoxPostal_Code.Text = dr["PostalCode"].ToString();
                maskedTextBoxPhoneNum.Text = dr["PhoneNumber"].ToString();
                textBoxFaxNumber.Text = dr["FaxNumber"].ToString();
                textBoxCredit_Limit.Text = dr["CreditLimit"].ToString();
                textBoxContact_Email.Text = dr["Email"].ToString();
               
            }
            else
            {
                MessageBox.Show("Customer Not found!......", "Error!....", MessageBoxButtons.OK, MessageBoxIcon.Question);
                textBoxCustomerSearch.Clear();
                textBoxCustomerSearch.Focus();
            }
        }

        private void buttonSaveDataInDatabase_Click(object sender, EventArgs e)
        {
            da.Update(dsHiTechDB.Tables["Customers"]);
            MessageBox.Show("database has been updated successfully");
        }

        private void textBoxCustomerSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAllForm_Click(object sender, EventArgs e)
        {
            FormLogin select = new FormLogin();
            this.Hide();
            select.ShowDialog();
        }
    }
}
