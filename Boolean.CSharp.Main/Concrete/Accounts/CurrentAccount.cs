using Boolean.CSharp.Main.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete.Accounts
{
    public class CurrentAccount : Account
    {
        // private members
        private bool _overdraftApproved = false;
        private decimal _overdraftLimit = -2000;

        // constructor
        public CurrentAccount(Branch branch) : base(branch)
        {
        }

        // private methods
        private void ApproveOverdraft()
        {
            _overdraftApproved = true;
        }

        private void ChangeOverdraftLimit(decimal limit)
        {
            _overdraftLimit = limit;
        }

        // public methods
        public override void Withdraw(decimal amount)
        {
            if (_overdraftApproved)
            {
                decimal newBalance = GetCurrentBalance - amount;

                if (newBalance >= _overdraftLimit)
                {
                    var transaction = new Transaction(TransactionType.debit, amount, newBalance);
                    Transactions.Add(transaction);
                }
            }
            else
            {
                base.Withdraw(amount);
            }
        }
        public void RequestOverdraft(decimal limit)
        {
            OverdraftRequests overdraftRequest = new OverdraftRequests(this, limit);
            OverdraftRequests.Add(overdraftRequest);
        }

        public void ApproveOrRejectOverdraftRequest()
        {
            foreach (var request in OverdraftRequests)
            {
                Console.WriteLine($"AccountNumber: {request.CurrentAccount.AccountNumber} requests overdraft. New overdraft limit: {request.LimitRequest}");
                Console.WriteLine($"Would you like to approve this request? y/n");

                //string? ans = Console.ReadLine().ToLower();
                string ans = "y";

                // No check for invalid input
                if (ans == "y")
                {
                    request.CurrentAccount.ApproveOverdraft();
                    request.CurrentAccount.ChangeOverdraftLimit(request.LimitRequest);

                    Console.WriteLine("Overdraft request approved.");
                }
                else if (ans == "n")
                {
                    Console.WriteLine("Overdraft request denied.");
                }

                Console.WriteLine("");
            }

            OverdraftRequests.Clear();
        }

        // public properties
        public bool OverDraftApproved { get { return _overdraftApproved; } set { _overdraftApproved = value; } }
        public decimal OverdraftLimit { get { return _overdraftLimit; } set { _overdraftLimit = value; } }

        public List<OverdraftRequests> OverdraftRequests { get; } = new List<OverdraftRequests>();
    }
}
