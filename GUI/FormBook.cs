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

namespace Hi_Tech_Management_Final_Project.GUI
{
    public partial class FormBook : Form
    {
        public FormBook()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string ISBN = textBoxISBN.Text.Trim();
            string title = textBoxBookTitle.Text.Trim();
            string price = textBoxPrice.Text.Trim();
            decimal uPrice = 0;
            string publishedYear = textBoxPublishedYear.Text.Trim();
            string QOH = textBoxQOH.Text.Trim();
            string PublisherId = textBoxPublisherID.Text.Trim();
            string CategoryId = textBoxCategoryID.Text.Trim();
            if (Validator.IsEmpty(textBoxISBN.Text.Trim()))
            {
                MessageBox.Show("ISBN is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(title))
            {
                MessageBox.Show("Book Title is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxBookTitle.Focus();
                return;
            }

            if (Validator.IsEmpty(publishedYear))
            {
                MessageBox.Show("Published Year is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Focus();
                return;
            }

            if (Validator.IsEmpty(price))
            {
                MessageBox.Show("Unit Price is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Focus();
                return;
            }

            if (Validator.IsEmpty(QOH))
            {
                MessageBox.Show("Quantity On Hand is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Focus();
                return;
            }

            if (Validator.IsEmpty(PublisherId))
            {
                MessageBox.Show("Publisher ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherID.Focus();
                return;
            }

            if (Validator.IsEmpty(CategoryId))
            {
                MessageBox.Show("Category ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryID.Focus();
                return;
            }

            if (!Validator.IsValidId(textBoxISBN.Text.Trim(), 6))
            {
                MessageBox.Show("Please enter a 6-digit ISBN.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            if (!Validator.IsValidId(PublisherId, 1))
            {
                MessageBox.Show("Please enter a 1-digit Publisher ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherID.Clear();
                textBoxPublisherID.Focus();
                return;
            }

            if (!Validator.IsValidId(CategoryId, 2))
            {
                MessageBox.Show("Please enter a 2-digit Category ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryID.Clear();
                textBoxCategoryID.Focus();
                return;
            }

            try
            {
                uPrice = Convert.ToDecimal(price);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Unit Price.", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Clear();
                textBoxPrice.Focus();
                return;
            }

            // Checking duplicate ISBN 
            Books book = new Books();
            book = book.SearchBook(ISBN);
            if (book != null)
            {
                MessageBox.Show("This ISBN already exist", "Duplicate ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Clear();
                textBoxISBN.Focus();
                return;
            }

            Publishers pub = new Publishers();
            pub = pub.SearchPublisher(Convert.ToInt32(PublisherId));
            if (pub == null)
            {
                MessageBox.Show("This Publisher ID does not exist", "Non-exist Publisher ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherID.Clear();
                textBoxPublisherID.Focus();
                return;
            }

            Categories cat = new Categories();
            cat = cat.SearchCategory(Convert.ToInt32(CategoryId));
            if (cat == null)
            {
                MessageBox.Show("This Category ID does not exist", "Non-exist Category ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryID.Clear();
                textBoxCategoryID.Focus();
                return;
            }
            //When data is valid this code will go
            if (MessageBox.Show("Do you want to save this Book? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                
                Books bookSave = new Books();
                bookSave.ISBN = ISBN;
                bookSave.BookTitle = title;
                bookSave.UnitPrice = uPrice;
                bookSave.YearPublished = publishedYear;
                bookSave.Qoh = Convert.ToInt32(QOH);
                bookSave.PublisherID = Convert.ToInt32(PublisherId);
                bookSave.CategoryID = Convert.ToInt32(CategoryId);
                bookSave.SaveBook(bookSave);
                MessageBox.Show("Book has been saved successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Book has NOT been saved", "Save Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxPrice.Clear();
            textBoxPublishedYear.Clear();
            textBoxQOH.Clear();
            textBoxPublisherID.Clear();
            textBoxCategoryID.Clear();
            listViewBook.Items.Clear();
            textBoxISBN.Focus();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string ISBN = textBoxISBN.Text.Trim();
            string title = textBoxBookTitle.Text.Trim();
            string price = textBoxPrice.Text.Trim();
            decimal uPrice = 0;
            string publishedYear = textBoxPublishedYear.Text.Trim();
            string QOH = textBoxQOH.Text.Trim();
            string PublisherId = textBoxPublisherID.Text.Trim();
            string CategoryId = textBoxCategoryID.Text.Trim();
            if (Validator.IsEmpty(ISBN))
            {
                MessageBox.Show("ISBN is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxISBN.Focus();
                return;
            }

            if (Validator.IsEmpty(title))
            {
                MessageBox.Show("Book Title is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxBookTitle.Focus();
                return;
            }

            if (Validator.IsEmpty(publishedYear))
            {
                MessageBox.Show("year published is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Focus();
                return;
            }

            if (Validator.IsEmpty(price))
            {
                MessageBox.Show("Unit Price is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Focus();
                return;
            }

            if (Validator.IsEmpty(QOH))
            {
                MessageBox.Show("Quantity On Hand is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQOH.Focus();
                return;
            }

            if (Validator.IsEmpty(PublisherId))
            {
                MessageBox.Show("Publisher ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherID.Focus();
                return;
            }

            if (Validator.IsEmpty(CategoryId))
            {
                MessageBox.Show("Category ID is empty", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryID.Focus();
                return;
            }

            if (!Validator.IsValidId(CategoryId, 2))
            {
                MessageBox.Show("Please enter a 2-digit Category ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryID.Clear();
                textBoxCategoryID.Focus();
                return;
            }


            if (!Validator.IsValidId(PublisherId, 1))
            {
                MessageBox.Show("Please enter a 1-digit Publisher ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherID.Clear();
                textBoxPublisherID.Focus();
                return;
            }


            try
            {
                uPrice = Convert.ToDecimal(price);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Unit Price.", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPrice.Clear();
                textBoxPrice.Focus();
                return;
            }

            // Checking duplicate ISBN
            Books book = new Books();
            book = book.SearchBook(ISBN);

            Publishers pub = new Publishers();
            pub = pub.SearchPublisher(Convert.ToInt32(PublisherId));
            if (pub == null)
            {
                MessageBox.Show("This Publisher ID does not exist", "Non-exist Publisher ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPublisherID.Clear();
                textBoxPublisherID.Focus();
                return;
            }

            Categories cat = new Categories();
            cat = cat.SearchCategory(Convert.ToInt32(CategoryId));
            if (cat == null)
            {
                MessageBox.Show("This Category ID does not exist", "Non-exist Category ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCategoryID.Clear();
                textBoxCategoryID.Focus();
                return;
            }
            //When data is valid this code will go
            if (MessageBox.Show("Do you want to update this Book? ", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                
                if (book.ISBN != ISBN)
                {
                    MessageBox.Show("You can not change the ISBN again");
                    ISBN = book.ISBN;
                    return;
                }
                else
                {
                    book.BookTitle = title;
                    book.UnitPrice = uPrice;
                    book.YearPublished = publishedYear;
                    book.Qoh = Convert.ToInt32(QOH);
                    book.CategoryID = Convert.ToInt32(CategoryId);
                    book.PublisherID = Convert.ToInt32(PublisherId);
                    book.UpdateBook(book);
                    MessageBox.Show("Book has been upadted successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Book has NOT been updated", "Update Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxPrice.Clear();
            textBoxPublishedYear.Clear();
            textBoxQOH.Clear();
            textBoxPublisherID.Clear();
            textBoxCategoryID.Clear();
            listViewBook.Items.Clear();
            textBoxISBN.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            string ISBN = textBoxISBN.Text.Trim();
            Books book = new Books();
            if (MessageBox.Show("Do you want to delete this Book information? ", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                book.DeleteEmployee(ISBN);
                MessageBox.Show("Book has been set to inactive successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Book has NOT been deleted.", "Delete Unsuccessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxPrice.Clear();
            textBoxPublishedYear.Clear();
            textBoxQOH.Clear();
            textBoxPublisherID.Clear();
            textBoxCategoryID.Clear();
            listViewBook.Items.Clear();
            textBoxISBN.Focus();
        }

        private void buttonSearchBy_Click(object sender, EventArgs e)
        {
            textBoxISBN.Clear();
            textBoxBookTitle.Clear();
            textBoxPrice.Clear();
            textBoxPublishedYear.Clear();
            textBoxQOH.Clear();
            textBoxPublisherID.Clear();
            textBoxCategoryID.Clear();
            listViewBook.Items.Clear();
            string input = textBoxSearchBy.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Input is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchBy.Focus();
                return;
            }

            //When data is valid this code will go
            int select = comboBoxSearchBy.SelectedIndex;
            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose an option.", "Empty Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxSearchBy.Focus();
                    break;
                case 0:
                    if (!Validator.IsValidId(input, 6))
                    {
                        MessageBox.Show("Please input a 13-digit ISBN.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchBy.Clear();
                        textBoxSearchBy.Focus();
                        return;
                    }
                    Books book = new Books();
                    book = book.SearchBook(input);
                    if (book == null)
                    {
                        MessageBox.Show("This ISBN does not exist.", "Non-exist ISBN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchBy.Clear();
                        textBoxSearchBy.Focus();
                        return;
                    }
                    else
                    {
                        textBoxISBN.Text = book.ISBN;
                        textBoxBookTitle.Text = book.BookTitle;
                        textBoxPrice.Text = book.UnitPrice.ToString();
                        textBoxPublishedYear.Text = book.YearPublished;
                        textBoxQOH.Text = book.Qoh.ToString();
                        textBoxPublisherID.Text = book.PublisherID.ToString();
                        textBoxCategoryID.Text = book.CategoryID.ToString();
                    }
                    textBoxSearchBy.Clear();
                    comboBoxSearchBy.SelectedIndex = -1;
                    break;
                case 1:
                    Books book1 = new Books();
                    List<Books> listTitle_book = new List<Books>();
                    listTitle_book = book1.SearchBookByTitle(input);
                    if (listTitle_book.Count != 0)
                    {
                        foreach (var b in listTitle_book)
                        {
                            ListViewItem item = new ListViewItem(b.ISBN.ToString());
                            item.SubItems.Add(b.BookTitle.ToString());
                            item.SubItems.Add(b.UnitPrice.ToString());
                            item.SubItems.Add(b.YearPublished);
                            item.SubItems.Add(b.Qoh.ToString());
                            item.SubItems.Add(b.PublisherID.ToString());
                            item.SubItems.Add(b.CategoryID.ToString());
                            listViewBook.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Book Title does not exist.", "Non-exist Book Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBoxSearchBy.Clear();
                    comboBoxSearchBy.SelectedIndex = -1;
                    break;
                case 2:
                    if (!Validator.IsValidId(input, 1))
                    {
                        MessageBox.Show("Please input a 1-digit Publisher ID.", "Invalid Publisher ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchBy.Clear();
                        textBoxSearchBy.Focus();
                        return;
                    }
                    int pId = Convert.ToInt32(input);
                    Books book2 = new Books();
                    List<Books> listBookPub = new List<Books>();
                    listBookPub = book2.SearchBook(pId, "PublisherID");
                    if (listBookPub.Count != 0)
                    {
                        foreach (var b in listBookPub)
                        {
                            ListViewItem item = new ListViewItem(b.ISBN.ToString());
                            item.SubItems.Add(b.BookTitle.ToString());
                            item.SubItems.Add(b.UnitPrice.ToString());
                            textBoxPublishedYear.Text = b.YearPublished;
                            item.SubItems.Add(b.Qoh.ToString());
                            item.SubItems.Add(b.PublisherID.ToString());
                            item.SubItems.Add(b.CategoryID.ToString());
                            listViewBook.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found.", "Empty Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBoxSearchBy.Clear();
                    comboBoxSearchBy.SelectedIndex = -1;
                    break;
                case 3:
                    if (!Validator.IsValidId(input, 2))
                    {
                        MessageBox.Show("Please input a 2-digit Category ID.", "Invalid Category ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchBy.Clear();
                        textBoxSearchBy.Focus();
                        return;
                    }
                    int cId = Convert.ToInt32(input);
                    Books book3 = new Books();
                    List<Books> listBookCat = new List<Books>();
                    listBookCat = book3.SearchBook(cId, "CategoryID");
                    if (listBookCat.Count != 0)
                    {
                        foreach (var b in listBookCat)
                        {
                            ListViewItem item = new ListViewItem(b.ISBN.ToString());
                            item.SubItems.Add(b.BookTitle.ToString());
                            item.SubItems.Add(b.UnitPrice.ToString());
                            textBoxPublishedYear.Text = b.YearPublished;
                            item.SubItems.Add(b.Qoh.ToString());
                            item.SubItems.Add(b.PublisherID.ToString());
                            item.SubItems.Add(b.CategoryID.ToString());
                            listViewBook.Items.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found.", "Empty Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBoxSearchBy.Clear();
                    comboBoxSearchBy.SelectedIndex = -1;
                    break;
            }
        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            List<Books> listBook = new List<Books>();
            Books book = new Books();
            listBook = book.SearchAllBook();
            listViewBook.Items.Clear();
            if (listBook.Count == 0)
            {
                MessageBox.Show("There is no book in the database.", "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var b in listBook)
                {
                    ListViewItem item = new ListViewItem(b.ISBN.ToString());
                    item.SubItems.Add(b.BookTitle.ToString());
                    item.SubItems.Add(b.UnitPrice.ToString());
                    item.SubItems.Add(b.YearPublished.ToString());
                    item.SubItems.Add(b.Qoh.ToString());
                    item.SubItems.Add(b.PublisherID.ToString());
                    item.SubItems.Add(b.CategoryID.ToString());
                    listViewBook.Items.Add(item);
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult ex = MessageBox.Show("Niravkumar's & Rajdeep's Application...\n\nDo you really want to exit ? ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ex == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void buttonAllForm_Click(object sender, EventArgs e)
        {
            FormLogin select = new FormLogin();
            this.Hide();
            select.ShowDialog();
        }
    }
}
