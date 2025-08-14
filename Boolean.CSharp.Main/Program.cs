using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Concrete.Accounts;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

CurrentAccount currentAccount = new CurrentAccount(Branch.Stavanger);
currentAccount.Deposit(1000);
currentAccount.Deposit(2000);
currentAccount.Withdraw(500);
currentAccount.PrintBankStatement();