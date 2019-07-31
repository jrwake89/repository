using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("11111");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("11111", response.Account.AccountNumber);
        }

        [Test]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            FreeAccountDepositRule DepositRule = new FreeAccountDepositRule();
            Account account = new Account();

            IDeposit deposit = DepositRule;
            AccountType type = account.Type;

            account.AccountNumber = accountNumber;
            account.Type = accountType;
            account.Name = name;
            account.Balance = balance;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }

        [Test]

        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -100, false)]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -75, false)]
        [TestCase("12345", "Free Account", 80, AccountType.Free, -75, true)]

        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            FreeAccountWithdrawRule WithdrawRule = new FreeAccountWithdrawRule();
            Account account = new Account();

            IWithdraw withdraw = WithdrawRule;
            AccountType type = account.Type;

            account.AccountNumber = accountNumber;
            account.Type = accountType;
            account.Name = name;
            account.Balance = balance;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }




    }
    
}
