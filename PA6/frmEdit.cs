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
    public partial class frmEdit : Form
    {
        private Book myBook;
        private string cwid;
        private string mode;
        public frmEdit(Object tempBook, string tempMode, string tempCwid) //edit form (for editing or creating books)
        {
            myBook = (Book)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage; 
        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            if(mode == "edit") //This will populate the form with the data from the selected book if editing 
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtLengthData.Text = myBook.length.ToString();
                txtCoverData.Text = myBook.cover;

                pbCover.Load(myBook.cover); //if creating a new book this will be blank
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form, making no changes
        }

        private void BtnSave_Click(object sender, EventArgs e) //closes the form, saving all data that was changed 
        {
            myBook.title = txtTitleData.Text;
            myBook.author = txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.isbn = txtIsbnData.Text;
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.cover = txtCoverData.Text;
            //Console.WriteLine(cwid);
            //Console.ReadKey();
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);

            MessageBox.Show("Content was saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information); //saved message
            this.Close(); 
        }
    }
}
