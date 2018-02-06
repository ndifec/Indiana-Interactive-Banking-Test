
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianaInteractiveBankTest;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
         
        

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            Checking account = new Checking("Mr. Bryan Walton", beginningBalance);
            CorpInvest corpinvest = new CorpInvest("Mr. Bryan Walton", beginningBalance);
            IndInvest indinvest = new IndInvest("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);
            corpinvest.Debit(debitAmount);
            indinvest.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

             
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            Checking account = new Checking("Mr. Bryan Walton", beginningBalance);
            CorpInvest corpinvest = new CorpInvest("Mr. Bryan Walton", beginningBalance);
            IndInvest indinvest = new IndInvest("Mr. Bryan Walton", beginningBalance);
            // act  
            account.Debit(debitAmount);
            corpinvest.Debit(debitAmount);
            indinvest.Debit(debitAmount);

            // assert is handled by ExpectedException  
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            Checking account = new Checking("Mr. Bryan Walton", beginningBalance);
            CorpInvest corpinvest = new CorpInvest("Mr. Bryan Walton", beginningBalance);
            IndInvest indinvest = new IndInvest("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Debit(debitAmount);
                corpinvest.Debit(debitAmount);
                indinvest.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, Checking.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Debit_WhenDebitFromIndInvestIsMoreThank1k_ThrowArgumentOutOfRange()
        {
            //arrange
            double beginningBalance = 6000.59;
            double debitAmount = 2000.00;
            IndInvest indinvest = new IndInvest("Mr. Bryan Walton", beginningBalance);

            //act
            try
            {
                indinvest.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //assert
                StringAssert.Contains(e.Message, IndInvest.DebitAmountExceedsLimitMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
            

        }

        [TestMethod]
        public void Transfer_AmountDebitedAndCreditedSuccessfully()
        {
            // arrange
            double beginningBalance = 550.22;
            double transferAmount = 52.52;
            string FromAccount = "IndInvest";
            string ToAccount = "checking";

            // act
            transfers transfer = new transfers(FromAccount, ToAccount, transferAmount, beginningBalance);

            // assert is handled by ExpectedException 
        }
    }
}