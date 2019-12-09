using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class frmMain : Form
    {
        string cwid;
        List<Book> myBooks;

        public frmMain(string tempCwid) //main menu that lists the books and relevant information
        {
            this.cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()  //method to keep the list up to date
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); //closes out the menu (and the entire program)
        }

        private void LstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; //changes selected book

            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtIsbnData.Text = myBook.isbn;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();

            try
            {
                pbCover.Load(myBook.cover);
            }
            catch
            {

            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; //rents the book

            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; //returns the book

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem; //deletes the book

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo); //confirms deletion

            if(dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                LoadList();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e) //opens the edit menu
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook, "edit", cwid);
            if(myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e) //also opens the edit menu, but in the new configuration
        {
            Book myBook = new Book();
            frmEdit myForm = new frmEdit(myBook, "new", cwid);
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }
    }
}
