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
using Hi_Tech_Management_Final_Project.MODEL;

namespace Hi_Tech_Management_Final_Project.GUI
{
    public partial class FormCustomerOrder : Form
    {
        HiTechDatabaseEntities db = new HiTechDatabaseEntities();
        public FormCustomerOrder()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string orderID = textBoxOrderID.Text.Trim();
            string OrderDate = dateTimePickerOrderDate.Text.Trim();
            string OrderType = textBoxOrderType.Text.Trim();
            string OrderRequiredDate = dateTimePickerRequiredDate.Text.Trim();
            string OrdeShippingDate = dateTimePickerShippingDate.Text.Trim();
            string StatusID = textBoxStatusID.Text.Trim();
            string EmployeeID = textBoxEmployeeID.Text.Trim();
            string CustomerID = textBoxCustomerID.Text.Trim();
            string Payment = textBoxPayment.Text.Trim();
            if (Validator.IsEmpty(orderID))
            {
                MessageBox.Show("Order ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderID.Focus();
                return;
            }

            if (Validator.IsEmpty(OrderDate))
            {
                MessageBox.Show("OrderDate is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerOrderDate.Focus();
                return;
            }

            if (Validator.IsEmpty(OrderType))
            {
                MessageBox.Show("OrderType is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderType.Focus();
                return;
            }

            if (Validator.IsEmpty(OrderRequiredDate))
            {
                MessageBox.Show("OrderRequiredDate empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerRequiredDate.Focus();
                return;
            }

            if (Validator.IsEmpty(OrdeShippingDate))
            {
                MessageBox.Show("OrdeShippingDate empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerShippingDate.Focus();
                return;
            }
            if (Validator.IsEmpty(StatusID))
            {
                MessageBox.Show("StatusID empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStatusID.Focus();
                return;
            }
            if (Validator.IsEmpty(EmployeeID))
            {
                MessageBox.Show("EmployeeID empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Focus();
                return;
            }
            if (Validator.IsEmpty(CustomerID))
            {
                MessageBox.Show("CustomerID empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }
            if (Validator.IsEmpty(Payment))
            {
                MessageBox.Show("Payment empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPayment.Focus();
                return;
            }
            if (!Validator.IsValidNumber(orderID))
            {
                MessageBox.Show("Order ID numeric only...", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderID.Clear();
                textBoxOrderID.Focus();
                return;
            }


            if (!Validator.IsValidId(orderID, 4))
            {
                MessageBox.Show("Order ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStatusID.Clear();
                textBoxStatusID.Focus();
                return;
            }

            if (!Validator.IsValidNumber(StatusID))
            {
                MessageBox.Show("Status ID numeric number only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStatusID.Clear();
                textBoxStatusID.Focus();
                return;
            }


            if (!Validator.IsValidId(StatusID, 4))
            {
                MessageBox.Show("Status ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStatusID.Clear();
                textBoxStatusID.Focus();
                return;
            }
            if (!Validator.IsValidNumber(EmployeeID))
            {
                MessageBox.Show("Employee ID numeric number only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            if (!Validator.IsValidId(EmployeeID, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }
            if (!Validator.IsValidNumber(CustomerID))
            {
                MessageBox.Show("Customer ID numeric number only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            if (!Validator.IsValidId(CustomerID, 6))
            {
                MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            Order order = new Order();
            order = db.Orders.Find(Convert.ToInt32(orderID));
            if (order != null)
            {
                MessageBox.Show("This order ID already exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderID.Clear();
                textBoxOrderID.Focus();
                return;
            }

            Status status = new Status();
            status = db.Status.Find(Convert.ToInt32(StatusID));
            if (status == null)
            {
                MessageBox.Show("This Status ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            Employee emp = new Employee();
            emp = db.Employees.Find(Convert.ToInt32(EmployeeID));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Customer customer = new Customer();
            customer = db.Customers.Find(Convert.ToInt32(CustomerID));
            if (customer == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Order oDetails = new Order();
            oDetails.OrderID = Convert.ToInt32(textBoxOrderID.Text);
            oDetails.OrderDate = DateTime.Parse(dateTimePickerOrderDate.Text);
            oDetails.OrderType = textBoxOrderType.Text;
            oDetails.RequiredDate = DateTime.Parse(dateTimePickerRequiredDate.Text);
            oDetails.ShippingDate = DateTime.Parse(dateTimePickerShippingDate.Text);
            oDetails.StatusID = Convert.ToInt32(textBoxStatusID.Text);
            oDetails.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text);
            oDetails.CustomerID = Convert.ToInt32(textBoxCustomerID.Text);
            oDetails.Payment = Convert.ToInt32(textBoxPayment.Text);
            db.Orders.Add(oDetails);
            db.SaveChanges();
            MessageBox.Show("Ordeer details info has been saved successfully.", "Confirmation");

            textBoxOrderID.Text = "";
            dateTimePickerOrderDate.Text = "";
            textBoxOrderType.Text = "";
            dateTimePickerRequiredDate.Text = "";
            dateTimePickerShippingDate.Text = "";
            textBoxStatusID.Text = "";
            textBoxEmployeeID.Text = "";
            textBoxCustomerID.Text = "";
            textBoxPayment.Text = "";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string orderID = textBoxOrderID.Text.Trim();
            string OrderDate = dateTimePickerOrderDate.Text.Trim();
            string OrderType = textBoxOrderType.Text.Trim();
            string OrderRequiredDate = dateTimePickerRequiredDate.Text.Trim();
            string OrdeShippingDate = dateTimePickerShippingDate.Text.Trim();
            string StatusID = textBoxStatusID.Text.Trim();
            string EmployeeID = textBoxEmployeeID.Text.Trim();
            string CustomerID = textBoxCustomerID.Text.Trim();
            string Payment = textBoxPayment.Text.Trim();
            if (Validator.IsEmpty(orderID))
            {
                MessageBox.Show("Order ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Validator.IsEmpty(OrderDate))
            {
                MessageBox.Show("OrderDate is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerOrderDate.Focus();
                return;
            }

            if (Validator.IsEmpty(OrderType))
            {
                MessageBox.Show("OrderType is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderType.Focus();
                return;
            }

            if (Validator.IsEmpty(OrderRequiredDate))
            {
                MessageBox.Show("OrderRequiredDate empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerRequiredDate.Focus();
                return;
            }

            if (Validator.IsEmpty(OrdeShippingDate))
            {
                MessageBox.Show("OrdeShippingDate empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerShippingDate.Focus();
                return;
            }

            if (Validator.IsEmpty(StatusID))
            {
                MessageBox.Show("StatusID empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStatusID.Focus();
                return;
            }

            if (Validator.IsEmpty(EmployeeID))
            {
                MessageBox.Show("EmployeeID empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Focus();
                return;
            }

            if (Validator.IsEmpty(CustomerID))
            {
                MessageBox.Show("CustomerID empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Focus();
                return;
            }

            if (Validator.IsEmpty(Payment))
            {
                MessageBox.Show("Payment empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPayment.Focus();
                return;
            }

            if (!Validator.IsValidId(StatusID, 4))
            {
                MessageBox.Show("Status ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStatusID.Clear();
                textBoxStatusID.Focus();
                return;
            }

            if (!Validator.IsValidId(EmployeeID, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            if (!Validator.IsValidId(CustomerID, 6))
            {
                MessageBox.Show("Customer ID is a 6-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCustomerID.Clear();
                textBoxCustomerID.Focus();
                return;
            }

            Status status = new Status();
            status = db.Status.Find(Convert.ToInt32(StatusID));
            if (status == null)
            {
                MessageBox.Show("This Status ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            Employee emp = new Employee();
            emp = db.Employees.Find(Convert.ToInt32(EmployeeID));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Customer customer = new Customer();
            customer = db.Customers.Find(Convert.ToInt32(CustomerID));
            if (customer == null)
            {
                MessageBox.Show("This Customer ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Order oDetails = new Order();
            oDetails.OrderID = Convert.ToInt32(textBoxOrderID.Text);
            oDetails.OrderDate = DateTime.Parse(dateTimePickerOrderDate.Text);
            oDetails.OrderType = textBoxOrderType.Text;
            oDetails.RequiredDate = DateTime.Parse(dateTimePickerRequiredDate.Text);
            oDetails.ShippingDate = DateTime.Parse(dateTimePickerShippingDate.Text);
            oDetails.StatusID = Convert.ToInt32(textBoxStatusID.Text);
            oDetails.EmployeeID = Convert.ToInt32(textBoxEmployeeID.Text);
            oDetails.CustomerID = Convert.ToInt32(textBoxCustomerID.Text);
            oDetails.Payment = Convert.ToInt32(textBoxPayment.Text);
            db.SaveChanges();
            MessageBox.Show(oDetails.OrderType);
            MessageBox.Show("Order details info has been Updated successfully.", "Confirmation");

            textBoxOrderID.Text = "";
            dateTimePickerOrderDate.Text = "";
            textBoxOrderType.Text = "";
            dateTimePickerRequiredDate.Text = "";
            dateTimePickerShippingDate.Text = "";
            textBoxStatusID.Text = "";
            textBoxEmployeeID.Text = "";
            textBoxCustomerID.Text = "";
            textBoxPayment.Text = "";
            listView1.Items.Clear();
        }

        private void buttonListAllOrders_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var listE = from oDetails in db.Orders
                        select oDetails;
            foreach (var itemE in listE)
            {
                ListViewItem item = new ListViewItem(itemE.OrderID.ToString());
                item.SubItems.Add(itemE.OrderDate.ToString());
                item.SubItems.Add(itemE.OrderType);
                item.SubItems.Add(itemE.RequiredDate.ToString());
                item.SubItems.Add(itemE.ShippingDate.ToString());
                item.SubItems.Add(itemE.StatusID.ToString());
                item.SubItems.Add(itemE.EmployeeID.ToString());
                item.SubItems.Add(itemE.CustomerID.ToString());
                item.SubItems.Add(itemE.Payment.ToString());
                listView1.Items.Add(item);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            string search = textBoxSearchDetails.Text.Trim();
            Order orderDelete = new Order();
            orderDelete = db.Orders.Find(Convert.ToInt32(search));
            if (orderDelete != null)
            {
                db.Orders.Remove(orderDelete);
                db.SaveChanges();
                MessageBox.Show("Deleted", "Confirmation");
            }

            textBoxOrderID.Text = "";
            dateTimePickerOrderDate.Text = "";
            textBoxOrderType.Text = "";
            dateTimePickerRequiredDate.Text = "";
            dateTimePickerShippingDate.Text = "";
            textBoxStatusID.Text = "";
            textBoxEmployeeID.Text = "";
            textBoxCustomerID.Text = "";
            textBoxPayment.Text = "";
        }

        private void buttonSearchBy_Click(object sender, EventArgs e)
        {
            textBoxOrderID.Clear();
            textBoxOrderType.Clear();
            textBoxStatusID.Clear();
            textBoxEmployeeID.Clear();
            textBoxCustomerID.Clear();
            textBoxPayment.Clear();
            listView1.Items.Clear();
            string search = textBoxSearchDetails.Text.Trim();
            string input = textBoxSearchDetails.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Input is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchDetails.Focus();
                return;
            }

            //When data is valid this code will go
            int select = comboBoxSearchDetails.SelectedIndex;
            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose an option.", "Empty Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxSearchDetails.Focus();
                    break;
                case 0:
                 
                    Order oDetails = new Order();
                    foreach (Order c in db.Orders)
                    {
                        if (db.Orders.Find(Convert.ToInt32(search)) != null)
                        {
                            listView1.Items.Clear();
                            
                            var listE = from oDetails1 in db.Orders
                                        select oDetails1;
                            foreach (var itemE in listE)
                            {
                                textBoxOrderID.Text = itemE.OrderID.ToString();
                                dateTimePickerOrderDate.Text = itemE.OrderDate.ToString();
                                textBoxOrderType.Text = itemE.OrderType;
                                dateTimePickerRequiredDate.Text = itemE.RequiredDate.ToString();
                                dateTimePickerShippingDate.Text = itemE.ShippingDate.ToString();
                                textBoxStatusID.Text = itemE.StatusID.ToString();
                                textBoxEmployeeID.Text = itemE.EmployeeID.ToString();
                                textBoxCustomerID.Text = itemE.CustomerID.ToString();
                                textBoxPayment.Text = itemE.Payment.ToString();

                                ListViewItem item = new ListViewItem(itemE.OrderID.ToString());
                                item.SubItems.Add(itemE.OrderDate.ToString());
                                item.SubItems.Add(itemE.OrderType);
                                item.SubItems.Add(itemE.RequiredDate.ToString());
                                item.SubItems.Add(itemE.ShippingDate.ToString());
                                item.SubItems.Add(itemE.StatusID.ToString());
                                item.SubItems.Add(itemE.EmployeeID.ToString());
                                item.SubItems.Add(itemE.CustomerID.ToString());
                                item.SubItems.Add(itemE.Payment.ToString());
                                listView1.Items.Add(item);

                            }
                            return;
                        }
                    }
                    
                    
                    break;
            }
        }

        private void FormCustomerOrder_Load(object sender, EventArgs e)
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
