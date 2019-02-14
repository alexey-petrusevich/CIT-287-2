using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project_2
{
    // checking account
    public sealed class CheckingAccount : BankAccount
    {
        // contructors
        public CheckingAccount()
        {

        }

        public CheckingAccount(int accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        
    }
}
