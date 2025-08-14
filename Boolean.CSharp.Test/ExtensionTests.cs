using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Concrete.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }

        //1. As an engineer, So I don't need to keep track of state, I want account balances to be calculated based on transaction history instead of stored in memory.
        [Test]
        public void CalculateBalanceBasedOnTransactionHistory()
        {
            CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);
            currentAccount.Deposit(1000);
            currentAccount.Withdraw(200);

            var result = currentAccount.GetCurrentBalance;

            Assert.That(result, Is.EqualTo(800));
        }

        // 2. As a bank manager, So I can expand, I want accounts to be associated with specific branches.
        [Test]
        public void AccountsAssociatedWithSpecificBranch()
        {
            CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);

            var result = currentAccount.Branch;

            Assert.That(result, Is.EqualTo(Branch.Stavanger));
        }

        // 3. As a customer, So I have an emergency fund, I want to be able to request an overdraft on my account.
        [Test]
        public void OverdraftAccount()
        {
            CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);
            currentAccount.RequestOverdraft(-2000);
            currentAccount.Deposit(1000);

            currentAccount.Withdraw(1500);

            Assert.That(currentAccount.GetCurrentBalance, Is.EqualTo(1000));
            Assert.That(currentAccount.OverdraftRequests.Count, Is.EqualTo(1));
        }

        // 4. As a bank manager, So I can safeguard our funds, I want to approve or reject overdraft requests.
        [Test]
        public void ApproveOrRejectOverdraftRequests()
        {
            CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);
            currentAccount.RequestOverdraft(-2000);
            currentAccount.Deposit(1000);

            currentAccount.ApproveOrRejectOverdraftRequest();
            currentAccount.Withdraw(1500);
            currentAccount.Withdraw(2000);

            Assert.That(currentAccount.GetCurrentBalance, Is.EqualTo(-500));
            Assert.That(currentAccount.OverdraftRequests.Count, Is.EqualTo(0));
        }
    }
}
