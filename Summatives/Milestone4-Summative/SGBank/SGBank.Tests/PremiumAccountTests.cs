using NUnit.Framework;
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
    public class PremiumAccountTests
    { 
        [Test]
        [TestCase("44444", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 700, true)]
        public void 
            PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
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
        [TestCase("44444", "Basic Account", 1500, AccountType.Basic, -1000, false)]
        [TestCase("44444", "Free Account", 100, AccountType.Premium, -1000, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 100, false)]
        [TestCase("44444", "Premium Account", 150, AccountType.Premium, -50, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
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
