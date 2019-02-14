using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project_2
{
    // class is designed to keep record of customer transactions
    public class Transaction
    {

        private string receiptBody;

        public Transaction(string receiptBody)
        {
            ReceiptBody = receiptBody;
        }

        public string ReceiptBody
        {
            set
            {
                receiptBody = value;
            }
            get
            {
                return receiptBody;
            }
        }

        
        
    }
}
