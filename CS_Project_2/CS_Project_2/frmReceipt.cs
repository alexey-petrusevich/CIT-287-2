using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Project_2
{
    public partial class frmReceipt : Form
    {
        public frmReceipt()
        {
            InitializeComponent();
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {

            string rtxtBody = "";

            foreach(Transaction transaction in frmLogIn.getTransaction())
            {
                rtxtBody += transaction.ReceiptBody;
            }

            rtxtReceiptBody.Text = rtxtBody;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // close receipt form
            this.Close();
        }
    }
}
