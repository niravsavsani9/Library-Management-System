using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTechDatabase.Business;
using HiTechDatabase.DataAccess;
using HiTechDatabase.Validator;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace HiTechDatabase.Business
{
    public class Books
    {
        private string iSBN;
        private string bookTitle;
        private decimal unitPrice;
        private String yearPublished;
        private int qoh;
        private int categoryID;
        private int publisherID;
        private int status;

        public string ISBN { get => iSBN; set => iSBN = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public string YearPublished { get => yearPublished; set => yearPublished = value; }
        public int Qoh { get => qoh; set => qoh = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int PublisherID { get => publisherID; set => publisherID = value; }
        public int Status { get => status; set => status = value; }

        public List<Books> SearchAllBook()
        {
            return BookDB.SearchRecord();
        }

        public void SaveBook(Books book)
        {
            BookDB.SaveRecord(book);
        }

        public void UpdateBook(Books book)
        {
            BookDB.UpdateRecord(book);
        }

        public void DeleteEmployee(string ISBN)
        {
            BookDB.DeleteRecord(ISBN);
        }

        public Books SearchBook(string ISBN)
        {
            return BookDB.GetRecord(ISBN);
        }

        public List<Books> SearchBookByTitle(string title)
        {
            return BookDB.GetRecordByTitle(title);
        }

        public List<Books> SearchBook(int id, string select)
        {
            return BookDB.GetRecord(id, select);
        }
    }

    public class Categories
    {
        private int categoryID;
        private string categoryName;

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public Categories SearchCategory(int catId)
        {
            return CategoryDB.SearchRecord(catId);
        }
    }

    public class Customers
    {
        private int customerId;
        private string customerName;
        private string streetAddress;
        private string city;
        private string postalCode;
        private string phoneNumber;
        private string faxNumber;
        private int creditLimit;
        private string email;
        private int status;

        public int CustomerId { get => customerId; set => customerId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }
        public string Email { get => email; set => email = value; }
        public int Status { get => status; set => status = value; }

        public Customers SearchCustomer(int custId)
        {
            return CustomerDB.GetRecord(custId);
        }
        public List<Customers> ListAllCustomer()
        {
            return CustomerDB.GetRecordList();
        }
    }

    public class Employees
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        private int jobId;
        private int statusId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public int StatusId { get => statusId; set => statusId = value; }

        public Employees()
        {
            EmployeeId = 0;
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            email = "";
        }

        public void SaveEmployee(Employees saveEmployee)
        {
            EmployeeDB.SaveRecord(saveEmployee);
        }
        public void UpdateEmployee(Employees updateEmployee)
        {
            EmployeeDB.UpdateRecord(updateEmployee);
        }
        public void DeleteEmployee(int deleteEmployeeId)
        {
            EmployeeDB.DeleteRecord(deleteEmployeeId);
        }
        public Employees SearchEmployee(int searchEmployeeId)
        {
            return EmployeeDB.GetRecord(searchEmployeeId);
        }
        public List<Employees> SearchAllEmployee()
        {
            return EmployeeDB.GetRecordList();
        }

        public List<Employees> SearchEmployeeByName(string name, string select)
        {
            return EmployeeDB.GetRecordListbyName(name, select);
        }


    }

    public class JobPositions
    {
        private int jobId;
        private string jobTitle;

        public int JobId { get => jobId; set => jobId = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }


        public JobPositions SearchJob(int getDataByJobId)
        {
            return JobPositionDB.GetRecord(getDataByJobId);
        }

        public List<JobPositions> SearchJobList()
        {
            return JobPositionDB.GetRecordList();
        }
        
    }

    public class Publishers
    {
        private int publisherID;
        private string publisherName;
        private string webAddress;

        public int PublisherID { get => publisherID; set => publisherID = value; }
        public string PublisherName { get => publisherName; set => publisherName = value; }
        public string WebAddress { get => webAddress; set => webAddress = value; }

        public Publishers SearchPublisher(int pubId)
        {
            return PublisherDB.SearchRecord(pubId);
        }
    }

    public class Status
    {
        private int statusId;
        private string state;

        public int StatusId { get => statusId; set => statusId = value; }
        public string State { get => state; set => state = value; }

        public List<Status> SearchStatusList(string select)
        {
            return StatusDB.GetRecordList(select);
        }
    }

    public class UserAccounts
    {
        private int userId;
        private string password;
        private int employeeId;

        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }


        public UserAccounts SearchUserAccount(int UserId, string password)
        {
            return userAccountDB.SearchRecord(UserId, password);
        }
        public UserAccounts SearchUserAccount(int searchByUserId)
        {
            return userAccountDB.SearchRecord(searchByUserId);
        }
        public UserAccounts SearchUserAccountByEmpId(int searchByEmployeeId)
        {
            return userAccountDB.SearchRecordByEmpId(searchByEmployeeId);
        }
        public void SaveUser(UserAccounts saveUser)
        {
            userAccountDB.SaveRecord(saveUser);
        }
        public void UpdateUser(UserAccounts updateUser)
        {
            userAccountDB.UpdateRecord(updateUser);
        }
        public void DeleteUser(int deleteUserByID)
        {
            userAccountDB.DeleteRecord(deleteUserByID);
        }
        public List<UserAccounts> SearchAllUser()
        {
            return userAccountDB.GetRecordList();
        }

        public UserAccounts IsValidUser(UserAccounts user)
        {
            return LoginDB.VerifyLogIn(user);
        }
    }
}

namespace HiTechDatabase.DataAccess
{
    public static class BookDB
    {
        public static void SaveRecord(Books book)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Books VALUES(@ISBN,@BookTitle,@UnitPrice,@YearPublished,@QOH,@CategoryID,@PublisherID);", connDB);
            cmdInsert.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmdInsert.Parameters.AddWithValue("@BookTitle", book.BookTitle);
            cmdInsert.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
            cmdInsert.Parameters.AddWithValue("@YearPublished", book.YearPublished);
            cmdInsert.Parameters.AddWithValue("@QOH", book.Qoh);
            cmdInsert.Parameters.AddWithValue("@CategoryID", book.CategoryID);
            cmdInsert.Parameters.AddWithValue("@PublisherID", book.PublisherID);
            //cmdInsert.Parameters.AddWithValue("@Status", book.Status);
            cmdInsert.ExecuteNonQuery();

            connDB.Close();
        }
        public static void UpdateRecord(Books book)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Books SET BookTitle = @BookTitle, UnitPrice = @UnitPrice, YearPublished = @YearPublished , Qoh = @QOH, CategoryID = @CategoryID, PublisherID = @PublisherID WHERE ISBN = @ISBN", connDB);
            cmdUpdate.Parameters.AddWithValue("@ISBN", book.ISBN);
            cmdUpdate.Parameters.AddWithValue("@BookTitle", book.BookTitle);
            cmdUpdate.Parameters.AddWithValue("@UnitPrice", book.UnitPrice);
            cmdUpdate.Parameters.AddWithValue("@YearPublished", book.YearPublished);
            cmdUpdate.Parameters.AddWithValue("@QOH", book.Qoh);
            cmdUpdate.Parameters.AddWithValue("@CategoryID", book.CategoryID);
            cmdUpdate.Parameters.AddWithValue("@PublisherID", book.PublisherID);
            //cmdUpdate.Parameters.AddWithValue("@Status", book.Status);
            cmdUpdate.ExecuteNonQuery();
            connDB.Close();
        }
        public static void DeleteRecord(string ISBN)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Books WHERE ISBN = @ISBN", connDB);
            cmdDelete.Parameters.AddWithValue("@ISBN", ISBN);
            cmdDelete.ExecuteNonQuery();
            connDB.Close();
        }
        public static Books GetRecord(string ISBN)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Books WHERE ISBN = @ISBN", connDB);
            cmdSelect.Parameters.AddWithValue("@ISBN", ISBN);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Books book = new Books();
            if (sqlReader.Read())
            {
                book.ISBN = sqlReader["ISBN"].ToString();
                book.BookTitle = sqlReader["BookTitle"].ToString();
                book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"]);
                book.YearPublished = sqlReader["yearPublished"].ToString();
                book.Qoh = Convert.ToInt32(sqlReader["QOH"]);
                book.CategoryID = Convert.ToInt32(sqlReader["CategoryID"]);
                book.PublisherID = Convert.ToInt32(sqlReader["PublisherID"]);
            }
            else
            {
                book = null;
            }
            connDB.Close();
            return book;
        }
        public static List<Books> GetRecordByTitle(string title)
        {
            List<Books> listBook = new List<Books>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectTitle = new SqlCommand("SELECT * FROM Books " + "WHERE BookTitle = @BookTitle ", connDB);
            cmdSelectTitle.Parameters.AddWithValue("@BookTitle", title);
            SqlDataReader sqlReader = cmdSelectTitle.ExecuteReader();
            Books book;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    book = new Books();
                    book.ISBN = sqlReader["ISBN"].ToString();
                    book.BookTitle = sqlReader["BookTitle"].ToString();
                    book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"]);
                    book.YearPublished = sqlReader["yearPublished"].ToString();
                    book.Qoh = Convert.ToInt32(sqlReader["QOH"]);
                    book.CategoryID = Convert.ToInt32(sqlReader["CategoryID"]);
                    book.PublisherID = Convert.ToInt32(sqlReader["PublisherID"]);
                    listBook.Add(book);
                }
            }
            else
            {
                listBook = null;
            }
            connDB.Close();
            return listBook;
        }
        public static List<Books> SearchRecord()
        {
            List<Books> listBook = new List<Books>();
            Books book;
            SqlConnection conn = UtilityDB.connectDB();
            SqlCommand cmdSearchAll = new SqlCommand("SELECT * FROM Books", conn);
            SqlDataReader sqlReader = cmdSearchAll.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    book = new Books();
                    book.ISBN = sqlReader["ISBN"].ToString();
                    book.BookTitle = sqlReader["BookTitle"].ToString();
                    book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"]);
                    book.YearPublished = sqlReader["yearPublished"].ToString();
                    book.Qoh = Convert.ToInt32(sqlReader["QOH"]);
                    book.CategoryID = Convert.ToInt32(sqlReader["CategoryID"]);
                    book.PublisherID = Convert.ToInt32(sqlReader["PublisherID"]);
                    //book.Status = Convert.ToInt32(sqlReader["Status"].ToString());
                    listBook.Add(book);
                }
            }
            else
            {
                listBook = null;
            }
            return listBook;
        }
        public static List<Books> GetRecord(int id, string select)
        {
            List<Books> listBook = new List<Books>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectTitle = new SqlCommand("SELECT * FROM Books " + "WHERE " + select + " = @id ", connDB);
            cmdSelectTitle.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlReader = cmdSelectTitle.ExecuteReader();
            Books book;
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    book = new Books();
                    book.ISBN = sqlReader["ISBN"].ToString();
                    book.BookTitle = sqlReader["BookTitle"].ToString();
                    book.UnitPrice = Convert.ToDecimal(sqlReader["UnitPrice"]);
                    book.YearPublished = sqlReader["yearPublished"].ToString();
                    book.Qoh = Convert.ToInt32(sqlReader["QOH"]);
                    book.CategoryID = Convert.ToInt32(sqlReader["CategoryID"]);
                    book.PublisherID = Convert.ToInt32(sqlReader["PublisherID"]);
                    listBook.Add(book);
                }
            }
            else
            {
                listBook = null;
            }
            connDB.Close();
            return listBook;
        }
    }

    public static class CategoryDB
    {
        public static Categories SearchRecord(int catId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            Categories cate = new Categories();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM Categories WHERE CategoryID = @CategoryID", connectDB);
            cmdSearch.Parameters.AddWithValue("@CategoryID", catId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                cate.CategoryID = Convert.ToInt32(sqlRead["CategoryID"]);
                cate.CategoryName = sqlRead["CategoryName"].ToString();
            }
            else
            {
                cate = null;
            }

            return cate;
        }
    }

    public static class CustomerDB
    {
        public static Customers GetRecord(int custId)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Customers WHERE CustomerId = @CustomerId", connDB);
            cmdSelect.Parameters.AddWithValue("@CustomerId", custId);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Customers cust = new Customers();
            if (!sqlReader.Read())
            {
                cust = null;
            }
            connDB.Close();
            return cust;
        }

        public static List<Customers> GetRecordList()
        {
            List<Customers> listCust = new List<Customers>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Customers", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Customers cust;
            while (sqlReader.Read())
            {
                cust = new Customers();
                cust.CustomerId = Convert.ToInt32(sqlReader["CustomerId"]);
                cust.CustomerName = sqlReader["CustomerName"].ToString();
                cust.StreetAddress = sqlReader["StreetAddress"].ToString();
                cust.City = sqlReader["City"].ToString();
                cust.PostalCode = sqlReader["PostalCode"].ToString();
                cust.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                cust.FaxNumber = sqlReader["FaxNumber"].ToString();
                cust.CreditLimit = Convert.ToInt32(sqlReader["CreditLimit"]);
                cust.Email = sqlReader["Email"].ToString();
                listCust.Add(cust);
            }
            connDB.Close();
            return listCust;
        }
    }

    public static class EmployeeDB
    {
        public static void SaveRecord(Employees saveEmployee)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Employees(EmployeeID,FirstName,LastName,PhoneNumber,Email,JobID,StatusID) VALUES(@EmployeeId,@FirstName,@LastName,@PhoneNumber,@Email,@JobId,@StatusId);", connDB);
            cmdInsert.Parameters.AddWithValue("@EmployeeID", saveEmployee.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", saveEmployee.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", saveEmployee.LastName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", saveEmployee.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", saveEmployee.Email);
            cmdInsert.Parameters.AddWithValue("@JobID", saveEmployee.JobId);
            cmdInsert.Parameters.AddWithValue("@StatusID", saveEmployee.StatusId);
            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }

        public static void UpdateRecord(Employees updateEmployee)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Employees SET FirstName = @FirstName, LastName = @LastName,PhoneNumber = @PhoneNumber, Email = @Email, JobID = @JobID WHERE EmployeeID = @EmployeeID", connDB);
            cmdUpdate.Parameters.AddWithValue("@EmployeeID", updateEmployee.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", updateEmployee.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", updateEmployee.LastName);
            cmdUpdate.Parameters.AddWithValue("@PhoneNumber", updateEmployee.PhoneNumber);
            cmdUpdate.Parameters.AddWithValue("@Email", updateEmployee.Email);
            cmdUpdate.Parameters.AddWithValue("@JobID", updateEmployee.JobId);
            cmdUpdate.Parameters.AddWithValue("@StatusID", updateEmployee.StatusId);
            cmdUpdate.ExecuteNonQuery();
            connDB.Close();

        }

        public static void DeleteRecord(int deleteEmployeeId)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", connDB);
            cmdDelete.Parameters.AddWithValue("@EmployeeID", deleteEmployeeId);
            cmdDelete.ExecuteNonQuery();
            connDB.Close();
        }

        public static Employees GetRecord(int searchEmployeeId)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", connDB);
            cmdSelect.Parameters.AddWithValue("@EmployeeID", searchEmployeeId);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Employees getEmployee = new Employees();
            if (sqlReader.Read())
            {
                getEmployee.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                getEmployee.FirstName = sqlReader["FirstName"].ToString();
                getEmployee.LastName = sqlReader["LastName"].ToString();
                getEmployee.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                getEmployee.Email = sqlReader["Email"].ToString();
                getEmployee.JobId = Convert.ToInt32(sqlReader["JobID"]);
                getEmployee.StatusId = Convert.ToInt32(sqlReader["StatusId"]);
            }
            else
            {
                getEmployee = null;

            }
            connDB.Close();
            return getEmployee;
        }

        public static List<Employees> GetRecordList()
        {
            List<Employees> listEmployee = new List<Employees>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Employees getEmployee;
            while (sqlReader.Read())
            {
                getEmployee = new Employees();
                getEmployee.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                getEmployee.FirstName = sqlReader["FirstName"].ToString();
                getEmployee.LastName = sqlReader["LastName"].ToString();
                getEmployee.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                getEmployee.Email = sqlReader["Email"].ToString();
                getEmployee.JobId = Convert.ToInt32(sqlReader["JobID"]);
                getEmployee.StatusId = Convert.ToInt32(sqlReader["StatusID"]);
                listEmployee.Add(getEmployee);

            }
            connDB.Close();
            return listEmployee;
        }


        public static Employees SearchRecord(int id)
        {
            List<Employees> listE = GetRecordList();
            Employees emp = new Employees();

            foreach (var item in listE)
            {
                if (item.EmployeeId == id)
                {
                    emp.EmployeeId = item.EmployeeId;
                    emp.FirstName = item.FirstName;
                    emp.LastName = item.LastName;
                    emp.JobId = item.JobId;
                    return emp;
                }
            }
            return null;
        }


        public static List<Employees> GetRecordListbyName(string employeeName, string select)
        {
            List<Employees> listEmp = new List<Employees>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectName = new SqlCommand("SELECT * FROM Employees " + "WHERE " + select + " = @Name ", connDB);
            cmdSelectName.Parameters.AddWithValue("@Name", employeeName);
            SqlDataReader sqlReader = cmdSelectName.ExecuteReader();
            Employees getEmployeeByName;
            while (sqlReader.Read())
            {
                getEmployeeByName = new Employees();
                getEmployeeByName.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                getEmployeeByName.FirstName = sqlReader["FirstName"].ToString();
                getEmployeeByName.LastName = sqlReader["LastName"].ToString();
                getEmployeeByName.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                getEmployeeByName.Email = sqlReader["Email"].ToString();
                getEmployeeByName.JobId = Convert.ToInt32(sqlReader["JobID"]);
                getEmployeeByName.StatusId = Convert.ToInt32(sqlReader["StatusID"]);
                listEmp.Add(getEmployeeByName);

            }
            connDB.Close();
            return listEmp;
        }
    }

    public static class JobPositionDB
    {
        public static JobPositions GetRecord(int getDataByJobId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            JobPositions job = new JobPositions();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM JobPositions WHERE JobID = @JobId", connectDB);
            cmdSearch.Parameters.AddWithValue("@JobId", getDataByJobId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                job.JobId = Convert.ToInt32(sqlRead["JobID"]);
                job.JobTitle = sqlRead["JobTitle"].ToString();
            }
            else
            {
                job = null;
            }

            return job;
        }
        public static List<JobPositions> GetRecordList()
        {
            List<JobPositions> listJob = new List<JobPositions>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM JobPositions", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            JobPositions job;
            while (sqlReader.Read())
            {
                job = new JobPositions();
                job.JobId = Convert.ToInt32(sqlReader["JobID"]);
                job.JobTitle = sqlReader["JobTitle"].ToString();
                listJob.Add(job);

            }
            connDB.Close();
            return listJob;
        }
    }

    public static class PublisherDB
    {
        public static Publishers SearchRecord(int pubId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            Publishers pub = new Publishers();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM Publishers WHERE PublisherID = @PublisherID", connectDB);
            cmdSearch.Parameters.AddWithValue("@PublisherID", pubId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                pub.PublisherID = Convert.ToInt32(sqlRead["PublisherID"]);
                pub.PublisherName = sqlRead["PublisherName"].ToString();
                pub.WebAddress = sqlRead["WebAddress"].ToString();
            }
            else
            {
                pub = null;
            }
            return pub;
        }
    }

    public static class StatusDB
    {
        public static List<Status> GetRecordList(string select)
        {
            List<Status> listStatus = new List<Status>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll;
            SqlDataReader sqlReader;
            if (select == "Order")
            {
                cmdSelectAll = new SqlCommand("SELECT * FROM Status", connDB);
                sqlReader = cmdSelectAll.ExecuteReader();
                Status status;
                while (sqlReader.Read())
                {
                    status = new Status();
                    status.StatusId = Convert.ToInt32(sqlReader["StatusId"]);
                    status.State = sqlReader["State"].ToString();
                    listStatus.Add(status);
                }
            }
            else if (select == "Customer" || select == "Book" || select == "UserAccount")
            {
                cmdSelectAll = new SqlCommand("SELECT * FROM Status", connDB);
                sqlReader = cmdSelectAll.ExecuteReader();
                Status status;
                while (sqlReader.Read())
                {
                    status = new Status();
                    status.StatusId = Convert.ToInt32(sqlReader["StatusId"]);
                    status.State = sqlReader["State"].ToString();
                    listStatus.Add(status);
                }
            }
            connDB.Close();
            return listStatus;
        }
    }

    public static class userAccountDB
    {
        public static UserAccounts SearchRecord(int UserId, string password)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            UserAccounts searchUserByUserIdPassword = new UserAccounts();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE UserID = @UserID AND Password = @Password", connectDB);
            cmdSearch.Parameters.AddWithValue("@UserID", UserId);
            cmdSearch.Parameters.AddWithValue("@Password", password);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                searchUserByUserIdPassword.UserId = Convert.ToInt32(sqlRead["UserID"]);
                searchUserByUserIdPassword.Password = sqlRead["Password"].ToString();
                searchUserByUserIdPassword.EmployeeId = Convert.ToInt32(sqlRead["EmployeeID"]);
            }
            else
            {
                searchUserByUserIdPassword = null;
            }

            return searchUserByUserIdPassword;
        }


        public static UserAccounts SearchRecord(int searchByUserId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            UserAccounts searchUserByUserId = new UserAccounts();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE UserID = @UserID", connectDB);
            cmdSearch.Parameters.AddWithValue("@UserID", searchByUserId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                searchUserByUserId.UserId = Convert.ToInt32(sqlRead["UserID"]);
                searchUserByUserId.Password = sqlRead["Password"].ToString();
                searchUserByUserId.EmployeeId = Convert.ToInt32(sqlRead["EmployeeID"]);
            }
            else
            {
                searchUserByUserId = null;
            }

            return searchUserByUserId;
        }

        public static UserAccounts SearchRecordByEmpId(int searchByEmployeeId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            UserAccounts searchUserByEmployeeId = new UserAccounts();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE EmployeeID = @EmployeeID", connectDB);
            cmdSearch.Parameters.AddWithValue("@EmployeeID", searchByEmployeeId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                searchUserByEmployeeId.UserId = Convert.ToInt32(sqlRead["UserID"]);
                searchUserByEmployeeId.Password = sqlRead["Password"].ToString();
                searchUserByEmployeeId.EmployeeId = Convert.ToInt32(sqlRead["EmployeeID"]);

            }
            else
            {
                searchUserByEmployeeId = null;
            }

            return searchUserByEmployeeId;
        }

        public static void SaveRecord(UserAccounts saveUser)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO UserAccounts (UserId,Password,EmployeeID) VALUES(@UserID,@Password,@EmployeeID);", connDB);
            cmdInsert.Parameters.AddWithValue("@UserID", saveUser.UserId);
            cmdInsert.Parameters.AddWithValue("@Password", saveUser.Password);
            cmdInsert.Parameters.AddWithValue("@EmployeeID", saveUser.EmployeeId);
            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }
        public static void UpdateRecord(UserAccounts updateUser)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE UserAccounts SET Password = @Password, EmployeeID = @EmployeeID WHERE UserID = @UserID", connDB);
            cmdUpdate.Parameters.AddWithValue("@UserID", updateUser.UserId);
            cmdUpdate.Parameters.AddWithValue("@Password", updateUser.Password);
            cmdUpdate.Parameters.AddWithValue("@EmployeeID", updateUser.EmployeeId);
            cmdUpdate.ExecuteNonQuery();
            connDB.Close();
        }

        public static void DeleteRecord(int deleteUserByID)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM UserAccounts WHERE UserID = @UserID", connDB);
            cmdDelete.Parameters.AddWithValue("@UserID", deleteUserByID);
            cmdDelete.ExecuteNonQuery();
            connDB.Close();
        }
        public static List<UserAccounts> GetRecordList()
        {
            List<UserAccounts> listUser = new List<UserAccounts>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM UserAccounts", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            UserAccounts getAllUser;
            while (sqlReader.Read())
            {
                getAllUser = new UserAccounts();
                getAllUser.UserId = Convert.ToInt32(sqlReader["UserID"]);
                getAllUser.Password = sqlReader["Password"].ToString();
                getAllUser.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                listUser.Add(getAllUser);

            }
            connDB.Close();
            return listUser;
        }

    }

    public static class LoginDB
    {

        public static UserAccounts VerifyLogIn(UserAccounts user)
        {

            using (SqlConnection conn = UtilityDB.connectDB())
            {
             
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.CommandText = "SELECT * FROM UserAccounts " +
                                        " WHERE UserID = @UserID " +
                                        " and Password = @Password";
                cmdSelect.Connection = conn;
                cmdSelect.Parameters.AddWithValue("@UserID", user.UserId);
                cmdSelect.Parameters.AddWithValue("@Password", user.Password);
                SqlDataReader reader = cmdSelect.ExecuteReader();
                if (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader["UserID"]);
                    user.Password = reader["Password"].ToString();
                    user.EmployeeId = Convert.ToInt32(reader["EmployeeID"]);
                    return user;
                   
                }

                else
                {
                    user = null;
                    return user;
                }

            }

        }

    }

    public static class UtilityDB
    {
        public static SqlConnection connectDB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}

namespace HiTechDatabase.Validator
{
    public class Validator
    {
        //To check entered field is empty or not
        public static bool IsEmpty(string input)
        {
            if (input == "")
            {
                return true;
            }
            return false;
        }

        public static bool IsEmpty1(int input)
        {
            if (input == 0)
            {
                return true;
            }
            return false;
        }

        //Set validation for data enter leght
        public static bool IsValidId(string input, int length)
        {
            if (!Regex.IsMatch(input, @"^\d{" + length + "}$"))
            {
                return false;
            }
            return true;
        }

        //firstname lastname validation
        public static bool IsValidString(string input)
        {
            foreach (char i in input)
            {
                if (!Char.IsWhiteSpace(i) && !Char.IsLetter(i))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidDate(string input)
        {
            if (!Regex.IsMatch(input, @"^(0[1-9]|1[0-2])/(0[1-9]|[1-2][0-9]|3[0-1])/(20[0-2][0-9])$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string input)
        {
            if (!Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidPostal_Code(string input)
        {
            if (!Regex.IsMatch(input, @"^[A-Z]{1}\d{1}[A-Z]{1}[- ]{0,1}\d{1}[A-Z]{1}\d{1}$"))
            {
                return false;
            }
            return true;
        }

        public static bool IsValidNumber(string input)
        {
            foreach (char i in input)
            {
                if (!Char.IsDigit(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
