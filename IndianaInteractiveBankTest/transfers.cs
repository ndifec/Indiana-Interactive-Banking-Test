using System;
using System.Collections.Generic;
using System.Text;

namespace IndianaInteractiveBankTest
{
    public class transfers
    {
        public string FromAccount;

        public string ToAccount;

        private string m_customerName;

        private double m_balance;

        private transfers()
        {

        }

        public transfers(string FromAccount, string ToAccount, double TranAmount, double beginningBalance)
        {
            m_balance = beginningBalance;

            if(FromAccount == "checking")
            {
                Checking checking = new Checking(m_customerName, m_balance);
                checking.Debit(TranAmount);
            }

            else if (FromAccount == "CorpInvest")
            {
                CorpInvest corpinvest = new CorpInvest(m_customerName, m_balance);
                corpinvest.Debit(TranAmount);
            }

            else if (FromAccount == "IndInvest")
            {
                IndInvest indinvest = new IndInvest(m_customerName, m_balance);
                indinvest.Debit(TranAmount);
            }


            if (ToAccount == "checking")
            {
                Checking checking = new Checking(m_customerName, m_balance);
                checking.Credit(TranAmount);
            }

            else if (ToAccount == "CorpInvest")
            {
                CorpInvest corpinvest = new CorpInvest(m_customerName, m_balance);
                corpinvest.Credit(TranAmount);
            }

            else if (ToAccount == "IndInvest")
            {
                IndInvest indinvest = new IndInvest(m_customerName, m_balance);
                indinvest.Credit(TranAmount);
            }
        }
    }
}
