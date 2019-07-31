using NUnit.Framework;
using SGBank.BLL.DepositRules;
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
    public class BasicAccountTests
    {
        [Test]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, 0, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 150, 250, true)]
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            NoLimitDepositRule noLimitDepositRule = new NoLimitDepositRule();
            Account account = new Account();

            IDeposit deposit = noLimitDepositRule;
            AccountType type = account.Type;

            account.AccountNumber = accountNumber;
            account.Type = accountType;
            account.Name = name;
            account.Balance = balance;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [Test]
        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)]
        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new BasicAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Type = accountType;
            account.Name = name;
            account.Balance = balance;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
