using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CS_Project_2
{
    // class is the base class for accounts
    public abstract class BankAccount : ISerializable
    {
        // datafields
        protected int accountNumber;
        protected decimal balance;

        // properties
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                Validator.ValidateAccountNumber(value);
                this.accountNumber = value;
            }
        }
        public virtual decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                Validator.ValidateBalance(value);
                this.balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (balance - amount < Decimal.Zero)
            {
                throw new ArgumentException("Insufficient funds!");
            } else
            {
                balance -= amount;
            }
        }

        public static void Transfer(BankAccount source, BankAccount destination, decimal amount)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentException("Source or destination account not found!");
            }
            else if (source.Balance - amount < Decimal.Zero)
            {
                throw new ArgumentException("Insufficient funds!");
            } else
            {
                source.Balance -= amount;
                destination.Balance += amount;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AccountNumber", accountNumber, typeof(int));
            info.AddValue("Balance", balance, typeof(decimal));
        }


    }
}
