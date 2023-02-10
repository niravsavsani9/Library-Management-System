using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTechDatabase.Business;
using HiTechDatabase.Validator;

namespace Hi_Tech_Management_Final_Project.GUI
{
    public partial class FormUserEmployee : Form
    {
        public FormUserEmployee()
        {
            InitializeComponent();
        }

        private void buttonSaveUserDetails_Click(object sender, EventArgs e)
        {
            string userId = textBoxUserID.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string employeeId = textBoxEmployeeIDUserForm.Text.Trim();
            if (Validator.IsEmpty(userId))
            {
                MessageBox.Show("User ID is empty.", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(password))
            {
                MessageBox.Show("Password is empty.", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(employeeId))
            {
                MessageBox.Show("Employee ID is empty.", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            if (!Validator.IsValidId(userId, 4))
            {
                MessageBox.Show("User ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (!Validator.IsValidId(employeeId, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Clear();
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            UserAccounts user = new UserAccounts();
            user = user.SearchUserAccount(Convert.ToInt32(userId));
            if (user != null)
            {
                MessageBox.Show("This User ID already exist.", "Duplicate User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(employeeId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Clear();
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            UserAccounts oldUser = new UserAccounts();
            oldUser = oldUser.SearchUserAccountByEmpId(Convert.ToInt32(employeeId));
            if (oldUser != null)
            {
                MessageBox.Show("This Employee ID already has an User Account.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxPassword.Clear();
                textBoxEmployeeIDUserForm.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to save this user? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                UserAccounts userSave = new UserAccounts();
                userSave.EmployeeId = Convert.ToInt32(employeeId);
                userSave.Password = password;
                userSave.UserId = Convert.ToInt32(userId);
                userSave.SaveUser(userSave);
                MessageBox.Show("User has been saved successfully.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User has NOT been saved.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            textBoxEmployeeIDUserForm.Clear();
            textBoxUserID.Focus();
        }


        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            string empId = textBoxEmployeeID.Text.Trim();
            string fName = textBoxFirstName.Text.Trim();
            string lName = textBoxLastName.Text.Trim();
            string pNum = maskedTextBoxPhoneNumber.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Focus();
                return;
            }

            if (Validator.IsEmpty(fName))
            {
                MessageBox.Show("First Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(lName))
            {
                MessageBox.Show("Last Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Email is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNumber.MaskFull)
            {
                MessageBox.Show("Please enter a 10-digit phone number", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNumber.Clear();
                maskedTextBoxPhoneNumber.Focus();
                return;
            }

            if (comboBoxJobId.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a job position", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxJobId.Focus();
                return;
            }

            // Checking Invalid ID
            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Please enter a 4-digit Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            if (!Validator.IsValidString(fName))
            {
                MessageBox.Show("First Name can only contain characters and white spaces", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            if (!Validator.IsValidString(lName))
            {
                MessageBox.Show("Last Name can only contain characters and white spaces", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com)", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp != null)
            {
                MessageBox.Show("This Employee ID already exist", "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            string JobId = comboBoxJobId.SelectedItem.ToString();
            string[] job = JobId.Split(',');

            string StatusId = comboBoxStatusId.SelectedItem.ToString();
            string[] status = StatusId.Split(',');

            if (MessageBox.Show("Do you want to save this employee? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Employees empSave = new Employees();
                empSave.EmployeeId = Convert.ToInt32(empId);
                empSave.FirstName = fName;
                empSave.LastName = lName;
                empSave.PhoneNumber = pNum;
                empSave.Email = email;
                empSave.JobId = Convert.ToInt32(job[0]);
                empSave.StatusId = Convert.ToInt32(status[0]);
                empSave.SaveEmployee(empSave);
                MessageBox.Show("Employee has been saved successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Employee has NOT been saved", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxEmployeeID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxEmail.Clear();
            comboBoxJobId.SelectedIndex = -1;
            comboBoxStatusId.SelectedIndex = -1;
            listViewEmployee.Items.Clear();
            textBoxEmployeeID.Focus();
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            string User_Id = textBoxUserID.Text.Trim();
            string pw = textBoxPassword.Text.Trim();
            string empId = textBoxEmployeeIDUserForm.Text.Trim();
            if (Validator.IsEmpty(User_Id))
            {
                MessageBox.Show("User ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Password is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            UserAccounts user = new UserAccounts();
            user = user.SearchUserAccount(Convert.ToInt32(User_Id));
            if (user == null)
            {
                MessageBox.Show("User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (user.EmployeeId != Convert.ToInt32(empId))
            {
                MessageBox.Show("Employee ID cannot be updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Clear();
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Clear();
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to update this User Information?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                UserAccounts userUpdate = new UserAccounts();
                userUpdate.UserId = Convert.ToInt32(User_Id);
                userUpdate.Password = pw;
                userUpdate.EmployeeId = Convert.ToInt32(empId);
                userUpdate.UpdateUser(userUpdate);
                MessageBox.Show("User has been updated.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nothing has been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxEmployeeIDUserForm.Clear();
            textBoxPassword.Clear();
            textBoxUserID.Focus();
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            string User_Id = textBoxUserID.Text.Trim();
            string pw = textBoxPassword.Text.Trim();
            string empId = textBoxEmployeeIDUserForm.Text.Trim();
            if (Validator.IsEmpty(User_Id))
            {
                MessageBox.Show("User ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Password is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            if (!Validator.IsValidId(User_Id, 4))
            {
                MessageBox.Show("User ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeIDUserForm.Clear();
                textBoxEmployeeIDUserForm.Focus();
                return;
            }

            UserAccounts user = new UserAccounts();
            user = user.SearchUserAccount(Convert.ToInt32(User_Id));
            if (user == null)
            {
                MessageBox.Show("This User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            JobPositions job = new JobPositions();
            job = job.SearchJob(emp.JobId);
            string jobTitle = job.JobTitle;
            if (jobTitle == "MIS Manager")
            {
                MessageBox.Show("Cannot delete a MIS Manager account. You may want to update this user account!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxEmployeeIDUserForm.Clear();
                textBoxPassword.Clear();
                textBoxUserID.Focus();
                return;
            }
            else if (jobTitle == "Order Clerks")
            {
                MessageBox.Show("Cannot delete an Order Clerk account. You may want to update this user account!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxEmployeeIDUserForm.Clear();
                textBoxPassword.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to delete this user? ", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                user.DeleteUser(Convert.ToInt32(User_Id));
                MessageBox.Show("User has been deleted successfully.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User has NOT been deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxEmployeeIDUserForm.Clear();
            textBoxPassword.Clear();
            textBoxUserID.Focus();
        }

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            listViewUsers.Items.Clear();
            List<UserAccounts> listUser = new List<UserAccounts>();
            UserAccounts user = new UserAccounts();
            listUser = user.SearchAllUser();
            if (listUser.Count != 0)
            {
                foreach (UserAccounts uA in listUser)
                {
                    ListViewItem item = new ListViewItem(uA.UserId.ToString());
                    item.SubItems.Add(uA.Password);
                    item.SubItems.Add(uA.EmployeeId.ToString());
                    listViewUsers.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("There is no User to display.", "Empty User Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLogoutUser_Click(object sender, EventArgs e)
        {
            FormLogin select = new FormLogin();
            this.Hide();
            select.ShowDialog();
        }

        private void buttonSearchUser_Click(object sender, EventArgs e)
        {
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            textBoxEmployeeIDUserForm.Clear();
            string input = textBoxSearchByInput.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Input is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchByInput.Focus();
                return;
            }
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Please input a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            //When data is valid
            int select = comboBoxSearchBy.SelectedIndex;
            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose an option.", "Empty Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxSearchBy.Focus();
                    break;
                case 0:
                    int uId = Convert.ToInt32(input);
                    UserAccounts userSearch = new UserAccounts();
                    userSearch = userSearch.SearchUserAccount(uId);
                    if (userSearch == null)
                    {
                        MessageBox.Show("This User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchByInput.Clear();
                        textBoxSearchByInput.Focus();
                        return;
                    }
                    else
                    {
                        textBoxUserID.Text = userSearch.UserId.ToString();
                        textBoxPassword.Text = userSearch.Password;
                        textBoxEmployeeIDUserForm.Text = userSearch.EmployeeId.ToString();
                        textBoxSearchByInput.Clear();
                        comboBoxSearchBy.SelectedIndex = -1;
                    }
                    break;
                case 1:
                    int eId = Convert.ToInt32(input);
                    UserAccounts userSearch1 = new UserAccounts();
                    userSearch1 = userSearch1.SearchUserAccountByEmpId(eId);
                    if (userSearch1 == null)
                    {
                        MessageBox.Show("This Employee ID does not exist or does not has an account.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchByInput.Clear();
                        textBoxSearchByInput.Focus();
                        return;
                    }
                    else
                    {
                        textBoxUserID.Text = userSearch1.UserId.ToString();
                        textBoxPassword.Text = userSearch1.Password;
                        textBoxEmployeeIDUserForm.Text = userSearch1.EmployeeId.ToString();
                        textBoxSearchByInput.Clear();
                        comboBoxSearchBy.SelectedIndex = -1;
                    }
                    break;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult ex = MessageBox.Show("Niravkumar's & Rajdeep's Application ...\n\nDo you really want to exit ? ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ex == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            string empId = textBoxEmployeeID.Text.Trim();
            string fName = textBoxFirstName.Text.Trim();
            string lName = textBoxLastName.Text.Trim();
            string pNum = maskedTextBoxPhoneNumber.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Focus();
                return;
            }

            if (Validator.IsEmpty(fName))
            {
                MessageBox.Show("First Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(lName))
            {
                MessageBox.Show("Last Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Email is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNumber.MaskFull)
            {
                MessageBox.Show("Please enter a 10-digit phone number", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNumber.Clear();
                maskedTextBoxPhoneNumber.Focus();
                return;
            }

            if (comboBoxJobId.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a job position", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxJobId.Focus();
                return;
            }
            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Please enter a 4-digit Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }
            if (!Validator.IsValidString(fName))
            {
                MessageBox.Show("First Name can only contain characters and white spaces", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            if (!Validator.IsValidString(lName))
            {
                MessageBox.Show("Last Name can only contain characters and white spaces", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }
            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com)", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            UserAccounts user = new UserAccounts();
            user = user.SearchUserAccountByEmpId(Convert.ToInt32(empId));
            if (user != null)
            {
                if (MessageBox.Show("This Employee has a User Account. \nDo you want to delete this Employee and User Account Information?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    user.DeleteUser(user.UserId);
                    Employees empDelete = new Employees();
                    empDelete.DeleteEmployee(Convert.ToInt32(empId));
                    MessageBox.Show("Employee has been deleted.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nothing has been deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this Employee Information?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    Employees empDelete = new Employees();
                    empDelete.DeleteEmployee(Convert.ToInt32(empId));
                    MessageBox.Show("Employee has been deleted.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nothing has been deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            textBoxEmployeeID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxEmail.Clear();
            comboBoxJobId.SelectedIndex = -1;
            comboBoxStatusId.SelectedIndex = -1;
            textBoxEmployeeID.Focus();
        }

        private void buttonLogoutEmployee_Click(object sender, EventArgs e)
        {
            FormLogin select = new FormLogin();
            this.Hide();
            select.ShowDialog();
        }

        private void buttonUpdateEmployee_Click(object sender, EventArgs e)
        {
            string empId = textBoxEmployeeID.Text.Trim();
            string fName = textBoxFirstName.Text.Trim();
            string lName = textBoxLastName.Text.Trim();
            string pNum = maskedTextBoxPhoneNumber.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Focus();
                return;
            }

            if (Validator.IsEmpty(fName))
            {
                MessageBox.Show("First Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Focus();
                return;
            }

            if (Validator.IsEmpty(lName))
            {
                MessageBox.Show("Last Name is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
                return;
            }

            if (Validator.IsEmpty(email))
            {
                MessageBox.Show("Email is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
                return;
            }

            if (!maskedTextBoxPhoneNumber.MaskFull)
            {
                MessageBox.Show("Please enter a 10-digit phone number", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxPhoneNumber.Clear();
                maskedTextBoxPhoneNumber.Focus();
                return;
            }

            if (comboBoxJobId.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a job position", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxJobId.Focus();
                return;
            }

            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Please enter a 4-digit Employee ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            if (!Validator.IsValidString(fName))
            {
                MessageBox.Show("First Name can only contain characters and white spaces", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            if (!Validator.IsValidString(lName))
            {
                MessageBox.Show("Last Name can only contain characters and white spaces", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid Email (e.g abc123@gmail.com)", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeID.Clear();
                textBoxEmployeeID.Focus();
                return;
            }

            string JobId = comboBoxJobId.SelectedItem.ToString();
            string[] job = JobId.Split(',');

            string StatusId = comboBoxStatusId.SelectedItem.ToString();
            string[] status = StatusId.Split(',');

            if (MessageBox.Show("Do you want to update this Employee Information?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                Employees empUpdate = new Employees();
                empUpdate.EmployeeId = Convert.ToInt32(empId);
                empUpdate.FirstName = fName;
                empUpdate.LastName = lName;
                empUpdate.PhoneNumber = pNum;
                empUpdate.Email = email;
                empUpdate.JobId = Convert.ToInt32(job[0]);
                empUpdate.StatusId = Convert.ToInt32(status[0]);
                empUpdate.UpdateEmployee(empUpdate);
                MessageBox.Show("Employee has been updated.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nothing has been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxEmployeeID.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxEmail.Clear();
            comboBoxJobId.SelectedIndex = -1;
            comboBoxStatusId.SelectedIndex = -1;
            listViewEmployee.Items.Clear();
            textBoxEmployeeID.Focus();
        }

        private void buttonListEmployee_Click(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();
            List<Employees> listEmp = new List<Employees>();
            Employees emp = new Employees();
            listEmp = emp.SearchAllEmployee();
            if (listEmp.Count != 0)
            {
                foreach (Employees em in listEmp)
                {
                    ListViewItem item = new ListViewItem(em.EmployeeId.ToString());
                    item.SubItems.Add(em.FirstName);
                    item.SubItems.Add(em.LastName);
                    item.SubItems.Add(em.PhoneNumber);
                    item.SubItems.Add(em.Email);
                    item.SubItems.Add(em.JobId.ToString());
                    item.SubItems.Add(em.StatusId.ToString());
                    listViewEmployee.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("There is no Employee to display.", "Empty Employee Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSearchEmployee_Click(object sender, EventArgs e)
        {
            Employees employee = new Employees();

            if (comboBoxSearchEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the search by option.", "Missing search option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string input = "";
            input = textBoxSeachEmployee.Text.Trim();

            if (comboBoxSearchEmployee.SelectedIndex == 0)
            {
                int eId = Convert.ToInt32(input);
                Employees empSearch = new Employees();
                empSearch = empSearch.SearchEmployee(eId);
                if (empSearch == null)
                {
                    MessageBox.Show("This Employee ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSeachEmployee.Clear();
                    textBoxSeachEmployee.Focus();
                    return;
                }
                else
                {
                    textBoxEmployeeID.Text = empSearch.EmployeeId.ToString();
                    textBoxFirstName.Text = empSearch.FirstName;
                    textBoxLastName.Text = empSearch.LastName;
                    maskedTextBoxPhoneNumber.Text = empSearch.PhoneNumber;
                    textBoxEmail.Text = empSearch.Email;
                    comboBoxJobId.Text = empSearch.JobId.ToString();
                    comboBoxStatusId.Text = empSearch.StatusId.ToString();
                    textBoxSeachEmployee.Clear();
                    comboBoxSearchEmployee.SelectedIndex = -1;

                }
            }
            else if (comboBoxSearchEmployee.SelectedIndex == 1)
            {

                List<Employees> listEmployees = employee.SearchEmployeeByName(input, "FirstName");
                listViewEmployee.Items.Clear();
                if (listEmployees.Count == 0)
                {
                    MessageBox.Show("This Last Name does not exist.", "Non-exist Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSeachEmployee.Clear();
                    textBoxSeachEmployee.Focus();
                    return;
                }
                else
                {

                    foreach (Employees emp in listEmployees)
                    {

                        ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                        item.SubItems.Add(emp.FirstName);
                        item.SubItems.Add(emp.LastName);
                        item.SubItems.Add(emp.PhoneNumber);
                        item.SubItems.Add(emp.Email);
                        item.SubItems.Add(emp.JobId.ToString());
                        item.SubItems.Add(emp.StatusId.ToString());
                        listViewEmployee.Items.Add(item);

                        return;
                    }
                }

            }
            else if (comboBoxSearchEmployee.SelectedIndex == 2)
            {

                List<Employees> listEmployees = employee.SearchEmployeeByName(input, "LastName");
                listViewEmployee.Items.Clear();
                if (listEmployees.Count == 0)
                {
                    MessageBox.Show("This Last Name does not exist.", "Non-exist Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSeachEmployee.Clear();
                    textBoxSeachEmployee.Focus();
                    return;
                }
                else
                {

                    foreach (Employees emp in listEmployees)
                    {

                        ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                        item.SubItems.Add(emp.FirstName);
                        item.SubItems.Add(emp.LastName);
                        item.SubItems.Add(emp.PhoneNumber);
                        item.SubItems.Add(emp.Email);
                        item.SubItems.Add(emp.JobId.ToString());
                        item.SubItems.Add(emp.StatusId.ToString());
                        listViewEmployee.Items.Add(item);

                        return;
                    }
                }
            }
        }

        private void buttonExitEmployee_Click(object sender, EventArgs e)
        {
            DialogResult ex = MessageBox.Show("Niravkumar's & Rajdeep's Application ...\n\nDo you really want to exit ? ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ex == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void FormUserEmployee_Load(object sender, EventArgs e)
        {
            JobPositions job = new JobPositions();
            List<JobPositions> listJob = new List<JobPositions>();
            listJob = job.SearchJobList();
            foreach (var j in listJob)
            {
                comboBoxJobId.Items.Add(j.JobId + ", " + j.JobTitle);
            }

            Status status = new Status();
            List<Status> listStatus = status.SearchStatusList("Customer");
            foreach (var item in listStatus)
            {
                comboBoxStatusId.Items.Add(item.StatusId + ", " + item.State);
            }
        }
    }
}
