using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Concrete.Accounts;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        // 1. As a customer, So I can safely store use my money, I want to create a current account.
        [Test]
        public void CreateCurrentAccount()
        {
            CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);

            Assert.IsNotNull(currentAccount);
            Assert.That(currentAccount.GetCurrentBalance, Is.EqualTo(0));
        }

        // 2. As a customer, So I can save for a rainy day, I want to create a savings account.
        [Test]
        public void CreateSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount(Branch.Stavanger);

            Assert.IsNotNull(savingsAccount);
            Assert.That(savingsAccount.GetCurrentBalance, Is.EqualTo(0));
        }

        //3. As a customer, So I can keep a record of my finances, I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
        [Test]
        public void GenerateBankStatements()
        {
            CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);
            currentAccount.Deposit(1000);
            currentAccount.Deposit(2000);
            currentAccount.Withdraw(500);

            SavingsAccount savingsAccount = new SavingsAccount(Branch.Stavanger);

            var result1 = currentAccount.PrintBankStatement();
            var result2 = savingsAccount.PrintBankStatement();

            Assert.That(result1, Is.EqualTo(true));
            Assert.That(result2, Is.EqualTo(false));
        }


        // 4. As a customer, So I can use my account, I want to deposit and withdraw funds.
        [Test]
        public void DepositMoneyToAccount()
        {
            CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);

            currentAccount.Deposit(500);

            Assert.That(currentAccount.GetCurrentBalance, Is.EqualTo(500));
        }

        [Test]
        public void WithdrawMoneyFromAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount(Branch.Stavanger);

            savingsAccount.Deposit(2000);
            savingsAccount.Withdraw(500);
            savingsAccount.Withdraw(10000);

            Assert.That(savingsAccount.GetCurrentBalance, Is.EqualTo(1500));
        }

    }
}