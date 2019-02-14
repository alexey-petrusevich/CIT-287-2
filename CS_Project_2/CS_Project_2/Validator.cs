using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project_2
{
    public static class Validator
    {

        public static bool ValidateAccountNumber(int value)
        {
            if (value.ToString().Length != 8)
            {
                throw new ArgumentException("Account Number must be 8 digits long");
            }
            else if (value < 0)
            {
                throw new ArgumentException("Account Number cannot be negative!");
            }
            return true;
        }

        public static bool ValidateBalance(decimal value)
        {
            if (value < Decimal.Zero) throw new ArgumentException("Balance cannot be negative!");
            return true;
        }


        public static bool ValidateUserID(string userID)
        {

            int temp = 0;


            if (userID.Length != 8)
            {
                throw new ArgumentException("User ID must be 8 characters long!");
            }
            else if (!Char.IsLetter(userID[0]))
            {
                throw new ArgumentException("User ID must begin with a letter");
            }
            // try parse will not accept negative numbers unless specifed
            else if (!Int32.TryParse(userID.ToString().Substring(1, 7), out temp))
            {
                throw new ArgumentException("The letter must follow with 7 digits!");
            }
            return true;
        }

        public static bool ValidatePassword(string password)
        {
            int temp = 0;

            if (password.Length != 4)
            {
                throw new ArgumentException("Password must be 4 digits long!");
            }
            else if (!Int32.TryParse(password, out temp))
            {
                throw new ArgumentException("Password must contain digits 0-9 only!");
            }
            return true;
        }

        public static bool ValidateAmount(string value)
        {
            decimal temp = 0m;
            if (!Decimal.TryParse(value, out temp))
            {
                throw new ArgumentException("Invalid amount value!");
            }
            else if(temp < Decimal.Zero)
            {
                throw new ArgumentException("Negative values are not allowed!");
            }
            return true;
        }

        public static bool ValidateAccount(string account)
        {
            int temp = 0;
            if (account.Length != 8)
            {
                throw new ArgumentException("Invalid account length!");
            }
            else if (!Int32.TryParse(account, out temp))
            {
                throw new ArgumentException("Invalid account value!");
            }
            return true;
        }
    }
}
