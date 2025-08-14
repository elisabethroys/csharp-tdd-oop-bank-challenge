using Boolean.CSharp.Main.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        // private members
        private Branch _branch;
        private Transaction _transaction;

        protected Account(Branch branch)
        {
            _branch = branch;
        }

        // public methods
        public virtual void Deposit(decimal amount)
        {
            decimal newBalance = GetCurrentBalance + amount;
            _transaction = new Transaction(TransactionType.credit, amount, newBalance);
            Transactions.Add(_transaction);
        }

        public virtual void Withdraw(decimal amount)
        {
            decimal newBalance = GetCurrentBalance - amount;

            if (newBalance >= 0)
            {
                _transaction = new Transaction(TransactionType.debit, amount, newBalance);
                Transactions.Add(_transaction);
            }
        }

        public virtual bool PrintBankStatement()
        {
            if(Transactions.Count == 0) return false;

            // Do not print inital balance.

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0,-10} || {1,-8} || {2,-8} || {3,-10}", "date", "credit", "debit", "balance"));

            foreach (var t in Transactions.OrderByDescending(t => t.Date))
            {
                string date = t.Date.ToString("dd-MM-yyyy");
                string credit = t.TransactionType == TransactionType.credit ? t.Amount.ToString("0.00", CultureInfo.InvariantCulture) : "";
                string debit = t.TransactionType == TransactionType.debit ? t.Amount.ToString("0.00", CultureInfo.InvariantCulture) : "";
                string balance = t.NewBalance.ToString("0.00", CultureInfo.InvariantCulture);


                sb.AppendLine(string.Format("{0, -10} || {1, -8} || {2,-8} || {3,-10}", date, credit, debit, balance));
            }

            Console.WriteLine(sb.ToString());

            return true;
        }

        // public properties
        public Guid Id { get; set; } = Guid.NewGuid(); // For the developer
        public Guid AccountNumber { get; set; } = Guid.NewGuid(); // For the bank
        public Branch Branch => _branch;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public decimal GetCurrentBalance { get { return Transactions.Count == 0 ? 0 : Transactions.Last().NewBalance; } }

    }
}
