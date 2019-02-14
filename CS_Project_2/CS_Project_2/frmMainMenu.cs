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

    public enum OptionSelected
    {
        MAKE_DEPOSIT = 1,
        MAKE_WITHDRAWAL = 2,
        CHECK_BALANCE = 3,
        TRANSFER_FUNDS = 4,
        EXIT = 5
    }

    public partial class frmMainMenu : Form
    {

        public static OptionSelected optionSelected;

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            if (rdoMakeDeposit.Checked)
            {
                optionSelected = OptionSelected.MAKE_DEPOSIT;
            }
            else if (rdoMakeWithdrawal.Checked)
            {
                optionSelected = OptionSelected.MAKE_WITHDRAWAL;
            }
            else if (rdoCheckBalance.Checked)
            {
                optionSelected = OptionSelected.CHECK_BALANCE;
            }
            else if (rdoTransferFunds.Checked)
            {
                optionSelected = OptionSelected.TRANSFER_FUNDS;
            }


            if (rdoExit.Checked)
            {
                frmLogIn.resetUser();

                // check if there were any transactions
                if (frmLogIn.getTransaction().Count != 0)
                {
                    // display receipt of there is at least one transaction
                    frmReceipt frmReceipt = new frmReceipt();

                    this.Hide();

                    // save user data to the local file
                    frmLogIn.SaveLocal();

                    frmReceipt.ShowDialog();
                }
                
                // close MainMenu form and return to frmLogin
                this.Close();
            }
            else
            {
                this.Hide();
                frmSelection frmSelection = new frmSelection();
                frmSelection.ShowDialog();
                this.Show();
            }
            
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            rdoMakeDeposit.Select();
        }

        private void rdoMakeDeposit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoExit_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
