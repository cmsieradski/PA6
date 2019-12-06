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
        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Book)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void TxtLengthData_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblLength_Click(object sender, EventArgs e)
        {

        }

        private void TxtIsbnData_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblIsbn_Click(object sender, EventArgs e)
        {

        }

        private void TxtCopiesData_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblCopies_Click(object sender, EventArgs e)
        {

        }

        private void TxtGenreData_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblGenre_Click(object sender, EventArgs e)
        {

        }

        private void TxtAuthorData_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblAuthor_Click(object sender, EventArgs e)
        {

        }

        private void TxtTitleData_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblTitle_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            if(mode == "edit")
            {
                txtTitleData.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtIsbnData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;
                txtLengthData.Text = myBook.len.ToString();

                pbCover.Load(myBook.cover);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
