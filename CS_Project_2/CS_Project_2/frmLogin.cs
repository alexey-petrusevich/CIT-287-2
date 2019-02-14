using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CS_Project_2
{
    public partial class frmLogIn : Form
    {

        private static User currentUser = null;

        private const string MASTER_FILE = "master.dat";
        private const string LOCAL_FILE = "local.dat";

        // attempts counter
        private int numAttempts = 0;

        // create a list of users
        private static List<User> users = new List<User>();

        // list of transactions to keep track of all user transactions
        private static List<Transaction> transactions = new List<Transaction>();

        private const string ADMIN_USER_ID = "ADMIN";
        private const string ADMIN_PASSWORD_RELEASE = "1234";
        private const string ADMIN_PASSWORD_EXIT = "BYE";

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMaster();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (User u in users)
            {
                if (txtUserId.Text.Equals(u.UserID) && txtPassword.Text.Equals(u.Password))
                {
                    currentUser = u;
                    break;
                }
            }
            // check if user exists
            if (numAttempts == 3)
            {
                // dsable buttons
                btnLogin.Enabled = false;
                btnClear.Enabled = false;
                clear();
                rtxtMessage.Text = "PLEASE SEE A BANK OFFICER - NO FURTHER LOGIN ATTEMPTS ALLOWED";

            }
            else if (currentUser == null)
            {
                clear();
                rtxtMessage.Text = "Incorrect User ID or/ and Password!";
                numAttempts++;
                txtUserId.Focus();
            }
            // else user enter correct data, load main menu
            else
            {
                this.Hide();
                frmMainMenu frmMainMenu = new frmMainMenu();
                frmMainMenu.ShowDialog();
                // at this point user has completed performing transactions


                // clear the list of transactions
                transactions.Clear();

                // clear the contents of the form text boxes
                clearAll();
                this.Show();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtPassword.Text = "";
            rtxtMessage.Text = "";
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            checkAdminExit();
            if (btnLogin.Enabled == false)
            {
                checkAdminRelease();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            checkAdminExit();
            if (btnLogin.Enabled == false)
            {
                checkAdminRelease();
            }
        }

        private void checkAdminRelease()
        {
            if (txtUserId.Text.Equals(ADMIN_USER_ID, StringComparison.InvariantCultureIgnoreCase) && txtPassword.Text.Equals(ADMIN_PASSWORD_RELEASE, StringComparison.InvariantCultureIgnoreCase))
            {
                // enable buttons and reset attempts counter
                btnLogin.Enabled = true;
                btnClear.Enabled = true;
                numAttempts = 0;
                clearAll();
                txtUserId.Focus();
            }
            
        }

        private void checkAdminExit()
        {
            if (txtUserId.Text.Equals(ADMIN_USER_ID, StringComparison.InvariantCultureIgnoreCase) && txtPassword.Text.Equals(ADMIN_PASSWORD_EXIT, StringComparison.InvariantCultureIgnoreCase))
            {
                this.Close();
            }
        }

        // method returns a list of users
        public static List<User> getUsers()
        {
            return users;
        }

        public static User getCurrentUser()
        {
            return currentUser;
        }

        public static void resetUser()
        {
            currentUser = null;
        }

        private void clearAll()
        {
            txtUserId.Text = "";
            txtPassword.Text = "";
            rtxtMessage.Text = "";
        }

        private void clear()
        {
            txtUserId.Text = "";
            txtPassword.Text = "";
        }

        private static void Save(string filePath)
        {
            FileStream file = null;
            BinaryWriter writer;

            try
            {
                // if file exists, delete it
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // throws IOException if file exists
                file = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);

                writer = new BinaryWriter(file);

                foreach (User user in users)
                {
                    writer.Write(user.UserID);
                    writer.Write(user.Password);
                    writer.Write(user.CheckingAccount.AccountNumber);
                    writer.Write(user.CheckingAccount.Balance);
                    writer.Write(user.SavingsAccount.AccountNumber);
                    writer.Write(user.SavingsAccount.Balance);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Exception while writing to " + filePath + "!");
            }
            finally
            {
                file.Close();
            }
        }

        public static void SaveLocal()
        {
            // save local copy
            Save(LOCAL_FILE);
        }

        private static void SaveMaster()
        {
            try
            {
                if (!File.Exists(LOCAL_FILE))
                {
                    // if local does not exists, create local
                    SaveLocal();
                }

                // if master exists, delete it
                if (File.Exists(MASTER_FILE))
                {
                    File.Delete(MASTER_FILE);
                }

                // copy local to master (MASTER_FILE must not exist)
                File.Copy(LOCAL_FILE, MASTER_FILE);

                

            }
            catch (IOException)
            {
                MessageBox.Show("Exception while copying local copy to master!");
            }
        }


        private static void LoadMaster()
        {
            FileStream file = null;

            try
            {
                // check if master exists
                // if not, create default array of users
                if (!File.Exists(MASTER_FILE))
                {
                    users = new List<User>
                    {
                        new User("A1111111", "1111", new CheckingAccount(11111111, 5000m), new SavingsAccount(22222222, 12500m)),
                        new User("C3333333", "3333", new CheckingAccount(33333333, 8000m), new SavingsAccount(44444444, 15000m)),
                        new User("E5555555", "5555", new CheckingAccount(55555555, 15000m), new SavingsAccount(55555555, 20000m))
                    };
                }
                // else file exists - read data
                else
                {
                    file = new FileStream(MASTER_FILE, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(file);

                    while (reader.PeekChar() != -1)
                    {
                        User user = new User();
                        user.CheckingAccount = new CheckingAccount();
                        user.SavingsAccount = new SavingsAccount();
                        user.UserID = reader.ReadString();
                        user.Password = reader.ReadString();
                        user.CheckingAccount.AccountNumber = reader.ReadInt32();
                        user.CheckingAccount.Balance = reader.ReadDecimal();
                        user.SavingsAccount.AccountNumber = reader.ReadInt32();
                        user.SavingsAccount.Balance = reader.ReadDecimal();

                        users.Add(user);
                    }
                    file.Close();
                }

                

            }
            catch (IOException)
            {
                // file not found
                MessageBox.Show(MASTER_FILE + " not found!");
            }
            finally
            {
                file.Close();
            }
        }


        private void frmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveMaster();
        }

        public static void AddTransaction(string customerID, string source, string destination, decimal amount, OptionSelected optionSelected)
        {

            switch (optionSelected)
            {
                case OptionSelected.MAKE_DEPOSIT:
                    transactions.Add(
                        new Transaction(
                            customerID + " made deposit of " + 
                            amount.ToString("c") + " to account " +
                            source.Substring(source.Length - 4) + "\n"
                            )
                            );
                    break;
                case OptionSelected.MAKE_WITHDRAWAL:
                    transactions.Add(
                        new Transaction(
                            customerID + " made withdrawal of " +
                            amount.ToString("c") + " from account " +
                            source.Substring(source.Length - 4) + "\n"
                            )
                            );
                    break;
                case OptionSelected.TRANSFER_FUNDS:
                    transactions.Add(
                        new Transaction(
                            customerID + " transfered " + 
                            amount.ToString("c") + 
                            " from account " + source.Substring(source.Length - 4) + 
                            " to account " + destination.Substring(source.Length - 4) + "\n"
                            )
                            );
                    break;
            }
            
        }

        public static List<Transaction> getTransaction()
        {
            return transactions;
        }

    }
}
