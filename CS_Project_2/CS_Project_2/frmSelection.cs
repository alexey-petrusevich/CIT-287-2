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
    public partial class frmSelection : Form
    {

        public frmSelection()
        {
            InitializeComponent();
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
            switch (frmMainMenu.optionSelected)
            {
                case OptionSelected.MAKE_DEPOSIT:
                    lblTransactionType.Text = "Make a Deposit";
                    lblSourceAccount.Text = "Account Number";
                    lblAmount.Show();
                    txtAmount.Show();
                    lblDestinationAccount.Hide();
                    txtDestinationAccount.Hide();
                    break;

                case OptionSelected.MAKE_WITHDRAWAL:
                    lblTransactionType.Text = "Make a Withdrawal";
                    lblSourceAccount.Text = "Account Number";
                    lblAmount.Show();
                    txtAmount.Show();
                    lblDestinationAccount.Hide();
                    txtDestinationAccount.Hide();
                    break;

                case OptionSelected.CHECK_BALANCE:
                    lblTransactionType.Text = "Check Balance";
                    lblSourceAccount.Text = "Account Number";
                    lblAmount.Hide();
                    txtAmount.Hide();
                    lblDestinationAccount.Hide();
                    txtDestinationAccount.Hide();
                    break;

                case OptionSelected.TRANSFER_FUNDS:
                    lblTransactionType.Text = "Transfer Funds";
                    lblSourceAccount.Text = "Account (source)";
                    lblSourceAccount.Show();
                    lblAmount.Show();
                    txtAmount.Show();
                    lblDestinationAccount.Text = "Account (destination)";
                    lblDestinationAccount.Show();
                    txtDestinationAccount.Show();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            List<User> users = frmLogIn.getUsers();

            try
            {

                // validate textfield data
                // source account
                Validator.ValidateAccount(txtSourceAccount.Text);

                if (frmMainMenu.optionSelected != OptionSelected.CHECK_BALANCE)
                {
                    // amount
                    Validator.ValidateAmount(txtAmount.Text);
                    if (frmMainMenu.optionSelected == OptionSelected.TRANSFER_FUNDS)
                    {
                        // destination account
                        Validator.ValidateAccount(txtDestinationAccount.Text);
                    }
                }

                // textfield data validated here if no excepions were thrown

                // validate if source is the address of current user
                int source = Int32.Parse(txtSourceAccount.Text);

                BankAccount sourceAccount = null;

                if (frmLogIn.getCurrentUser().CheckingAccount != null && frmLogIn.getCurrentUser().CheckingAccount.AccountNumber == source)
                {
                    sourceAccount = frmLogIn.getCurrentUser().CheckingAccount;
                }
                else if(frmLogIn.getCurrentUser().SavingsAccount != null && frmLogIn.getCurrentUser().SavingsAccount.AccountNumber == source)
                {
                    sourceAccount = frmLogIn.getCurrentUser().SavingsAccount;
                }


                if (source != frmLogIn.getCurrentUser().CheckingAccount.AccountNumber &&
                    source != frmLogIn.getCurrentUser().SavingsAccount.AccountNumber)
                {
                    throw new ArgumentException("Source account does not match accounts available to you!");
                }

                int destination = 0;
                BankAccount destinationAccount = null;
                if (frmMainMenu.optionSelected == OptionSelected.TRANSFER_FUNDS)
                {
                    destination = Int32.Parse(txtDestinationAccount.Text);
                }

                // search for destination account if aplicable

                // check if destination is user's checking or savings account
                if (frmLogIn.getCurrentUser().CheckingAccount.AccountNumber == destination)
                {
                    destinationAccount = frmLogIn.getCurrentUser().CheckingAccount;
                }
                else if(frmLogIn.getCurrentUser().SavingsAccount.AccountNumber == destination)
                {
                    destinationAccount = frmLogIn.getCurrentUser().SavingsAccount;
                }
                else // else search for account in the array
                {
                    foreach (User user in users)
                    {
                        if (user.CheckingAccount.AccountNumber == destination)
                        {
                            destinationAccount = user.CheckingAccount;
                            break;
                        }
                        else if (user.SavingsAccount.AccountNumber == destination)
                        {
                            destinationAccount = user.SavingsAccount;
                            break;
                        }
                    }
                }

                

                // check if destination account is null
                if (frmMainMenu.optionSelected == OptionSelected.TRANSFER_FUNDS &&
                    destinationAccount == null)
                {
                    throw new ArgumentException("Destination account not found!");
                }

                // source validated, destination validated

                switch (frmMainMenu.optionSelected)
                {
                    case OptionSelected.MAKE_DEPOSIT:
                        sourceAccount.Deposit(Decimal.Parse(txtAmount.Text));
                        frmLogIn.AddTransaction(
                            frmLogIn.getCurrentUser().UserID, 
                            sourceAccount.AccountNumber.ToString(), 
                            null,
                            Decimal.Parse(txtAmount.Text),
                            OptionSelected.MAKE_DEPOSIT
                            );
                        MessageBox.Show("$" + txtAmount.Text + " has been successfully deposited!");
                        break;

                    case OptionSelected.MAKE_WITHDRAWAL:
                        sourceAccount.Withdraw(Decimal.Parse(txtAmount.Text));
                        frmLogIn.AddTransaction(
                            frmLogIn.getCurrentUser().UserID, 
                            sourceAccount.AccountNumber.ToString(),
                            null, 
                            Decimal.Parse(txtAmount.Text),
                            OptionSelected.MAKE_WITHDRAWAL
                            );
                        MessageBox.Show("$" + txtAmount.Text + " has been successfully withdrawn!");
                        break;

                    case OptionSelected.CHECK_BALANCE:
                        MessageBox.Show("Your balance: " + sourceAccount.Balance.ToString("c"), "Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case OptionSelected.TRANSFER_FUNDS:
                        BankAccount.Transfer(sourceAccount, destinationAccount, Decimal.Parse(txtAmount.Text));
                        frmLogIn.AddTransaction(
                            frmLogIn.getCurrentUser().UserID,
                            sourceAccount.AccountNumber.ToString(),
                            destinationAccount.AccountNumber.ToString(),
                            Decimal.Parse(txtAmount.Text),
                            OptionSelected.TRANSFER_FUNDS
                            );
                        MessageBox.Show("$" + txtAmount.Text + " has been successfully transferred!");
                        break;

                }

                this.Close();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                // clear all textboxes
                txtSourceAccount.Clear();
                txtDestinationAccount.Clear();
                txtAmount.Clear();
                // move focus to accounf number
                txtSourceAccount.Focus();
            }


        }


    }
}
