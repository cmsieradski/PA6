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
    public partial class FrmCWID : Form
    {
        public FrmCWID()  //cwid entry form
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form
        }

        private void BtnOk_Click(object sender, EventArgs e) //takes cwid and opens main menu
        {
            this.Hide();
            frmMain myForm = new frmMain(txtCWID.Text);
            if(myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                this.Close();
            }
        }
    }
}
