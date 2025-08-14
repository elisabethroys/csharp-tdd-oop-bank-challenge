using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Boolean.CSharp.Main.Concrete
{

    public class Transaction
    {
        // private members
        private DateTime _date = DateTime.Now;
        private decimal _amount;
        private TransactionType _transactionType;
        private decimal _newBalance;


        // constructor
        public Transaction(TransactionType transactionType, decimal amount, decimal newBalance)
        {
            _transactionType = transactionType;
            _amount = amount;
            _newBalance = newBalance;
        }

        // public properties
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date => _date;
        public decimal Amount => _amount;
        public TransactionType TransactionType => _transactionType;
        public decimal NewBalance => _newBalance;
    }
}
