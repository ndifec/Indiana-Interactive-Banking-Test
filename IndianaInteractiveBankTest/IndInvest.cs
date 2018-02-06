using System;

namespace IndianaInteractiveBankTest
{


    public class IndInvest
    {
        private string m_customerName;

        private double m_balance;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";

        public const string DebitAmountExceedsLimitMessage = "Individual Investment accounts can only withdraw up to $1,000 at a time";

        private IndInvest()
        {
        }


        public IndInvest(string customerName, double balance)
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

            if (amount > 1000)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsLimitMessage);
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