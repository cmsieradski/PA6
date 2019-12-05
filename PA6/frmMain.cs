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

        public frmMain(string tempCwid)
        {
            this.cwid = tempCwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtIsbnData.Text = myBook.isbn;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.len.ToString();

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
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                LoadList();
            }
        }
    }
}
