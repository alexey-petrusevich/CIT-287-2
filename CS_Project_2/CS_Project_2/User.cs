using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CS_Project_2
{
    public class User : ISerializable
    {
        // datafields
        private string userID;
        private string password;
        private CheckingAccount checkingAccount;
        private SavingsAccount savingsAccount;

        // constructors
        public User()
        {

        }


        // full constructor
        public User(string userID, string password, CheckingAccount checkingAccount, SavingsAccount savingsAccount)
        {
            UserID = userID;
            Password = password;
            CheckingAccount = checkingAccount;
            SavingsAccount = savingsAccount;
        }

        // properties
        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                Validator.ValidateUserID(value);
                this.userID = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                Validator.ValidatePassword(value);
                this.password = value;
            }
        }
        
        public CheckingAccount CheckingAccount
        {
            get
            {
                return checkingAccount;
            }
            set
            {
                // no check if null
                this.checkingAccount = value;
            }
        }

        public SavingsAccount SavingsAccount
        {
            get
            {
                return savingsAccount;
            }
            set
            {
                // no check if null
                this.savingsAccount = value;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("UserID", userID, typeof(string));
            info.AddValue("Password", password, typeof(string));
            info.AddValue("CheckingAccount", checkingAccount, typeof(CheckingAccount));
            info.AddValue("SavingsAccount", savingsAccount, typeof(SavingsAccount));
        }
    }
}
