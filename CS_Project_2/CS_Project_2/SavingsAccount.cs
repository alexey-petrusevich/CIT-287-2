using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project_2
{
    // savings account
    public sealed class SavingsAccount : BankAccount
    {
        // datafields
        private const decimal INTEREST_RATE = 0.05m; // 5% by default


        // constructors
        public SavingsAccount()
        {

        }


        public SavingsAccount(int accountNumber, decimal balance){
            AccountNumber = accountNumber;
            Balance = balance;
        }

        // read only property
        public decimal Interest_Rate
        {
            get
            {
                return INTEREST_RATE;
            }
        }

        
    }
}
