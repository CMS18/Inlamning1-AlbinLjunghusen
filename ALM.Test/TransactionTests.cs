//strut
using ALM.Web;
using ALM.Web.Models;
using Shouldly;
using System;
using Xunit;

namespace ALM.Test
{
    //public class Fixture
    //{
    //    public BankRepository Repository { get; set; }
    //    public Transactioner TransactionManager { get; set; }

    //    public Fixture()
    //    {
    //       Repository =  new BankRepository();
    //        Repository.Initialize();
    //        TransactionManager = new Transactioner(Repository);
    //    }
    //}

    public class TransactionTests
    {
        [Theory]
        [InlineData(1337)]
        [InlineData(9000)]
        [InlineData(80085)]
        public void DepositTest(decimal amount)
        {
            var account = new Account();
            var transactioner = new Transactioner();
            decimal originalBalance = account.Balance;

            transactioner.Deposit(account, amount);

            account.Balance.ShouldBe(originalBalance + amount);
        }

        [Theory]
        [InlineData(1337, 500)]
        [InlineData(9000, 100)]
        [InlineData(80085, 80085)]
        public void WithdrawTest(decimal initial, decimal amount)
        {
            var account = new Account();
            account.Credit(initial);
            var transactioner = new Transactioner();
            decimal originalBalance = account.Balance;

            transactioner.Deposit(account, amount);

            account.Balance.ShouldBe(originalBalance + amount);
        }

        [Theory]
        [InlineData(1337, 1338)]
        [InlineData(1111.111, 9999.999)]
        [InlineData(1, 1.000000001)]
        [InlineData(0, 1)]
        public void WithdrawMoreThanBalance(decimal initial, decimal amount)
        {
            var account = new Account();
            account.Credit(initial);
            var transactioner = new Transactioner();
            decimal originalBalance = account.Balance;

            Should.Throw<InvalidTransactionException>(() => transactioner.Withdraw(account, amount));
        }
    }
}
