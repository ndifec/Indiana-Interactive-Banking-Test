using System;

namespace IndianaInteractiveBankTest
{


    public class CorpInvest
    {
        private string m_customerName;

        private double m_balance;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";

        

        private CorpInvest()
        {
        }


        public CorpInvest(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }


        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {


            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

           

            m_balance -= amount;
        }

        public void Credit(double amount)
        {

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        
    }
}