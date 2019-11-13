using ALM.Web;
using Xunit;

namespace ALM.Test
{
    public class TransferTests
    {
        [Theory]
        [InlineData(50)]
        [InlineData(40)]
        [InlineData(30)]
        public void TransferTests_CorrectBalance(decimal amount)
        {
            var repo = new BankRepository();
            var _transactioner = new Transactioner(repo);

            var fromacc = (repo.GetAccount(1).Balance) - amount;
            var toacc = (repo.GetAccount(2).Balance) + amount;

            _transactioner.Transfer(1, 2, amount);

            Assert.Equal(fromacc, repo.GetAccount(1).Balance);
            Assert.Equal(toacc, repo.GetAccount(2).Balance);

            
        }

        [Theory]
        [InlineData(100000)]
        [InlineData(200000)]
        public void TransferTests_AmountToHigh(decimal amount)
        {
            var repo = new BankRepository();
            var _transactioner = new Transactioner(repo);

            Assert.Throws<InvalidTransactionException>(() => _transactioner.Transfer(1, 2, amount));
        }
    }
}
