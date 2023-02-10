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
using HiTechDatabase.Business;
using HiTechDatabase.DataAccess;

namespace Hi_Tech_Management_Final_Project.GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }


        public static int userId;
        private void buttonLogIn_Click_1(object sender, EventArgs e)
        {

            UserAccounts user = new UserAccounts();
            user.UserId = Convert.ToInt32(textBoxUserName.Text);
            user.Password = textBoxPassword.Text;
            UserAccounts loginUser = user.IsValidUser(user);



            if(loginUser is null)
            {
                MessageBox.Show("Invalid username or password", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserName.Clear();
                textBoxPassword.Clear();
                textBoxUserName.Focus();
            }
            else
            {
                Employees emp = new Employees();
                emp = emp.SearchEmployee(loginUser.EmployeeId);
                JobPositions job = new JobPositions();

                job = job.SearchJob(emp.JobId);
                if (job is null)
                {
                    MessageBox.Show("Invalid User Job ID", "Invalid Job", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxUserName.Clear();
                    textBoxPassword.Clear();
                    textBoxUserName.Focus();
                }
                else
                {
                    if (job.JobId == 1111)
                    {
                        userId = user.UserId;
                        FormUserEmployee ueForm = new FormUserEmployee();
                        this.Hide();
                        ueForm.ShowDialog();
                    }
                    else if (emp.JobId == 2222)
                    {
                        userId = user.UserId;
                        FormCustomerMaintenance custForm = new FormCustomerMaintenance();
                        this.Hide();
                        custForm.ShowDialog();

                    }
                    else if (emp.JobId == 3333)
                    {
                        userId = user.UserId;
                        FormBook bookForm = new FormBook();
                        this.Hide();
                        bookForm.ShowDialog();
                    }
                    else if (emp.JobId == 4444)
                    {
                        FormCustomerOrder cOrder = new FormCustomerOrder();
                        this.Hide();
                        cOrder.ShowDialog();
                    }
                }
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult ex = MessageBox.Show("Niravkumar's & Rajdeep's Application...\n\nDo you really want to exit ? ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ex == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
    }
}
