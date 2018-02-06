using System;

namespace IndianaInteractiveBankTest
{
    class Accounts
    { 
        public static void Main()
        {
            Checking checking = new Checking("Test McGuy", 15.62);
            IndInvest IndInvest = new IndInvest("Test McGuy", 11.99);
            CorpInvest CorpInvest = new CorpInvest("Test McGuy", 3000);

            Console.WriteLine("First Test Bank");
            Console.WriteLine("Checking balance is ${0}", checking.Balance);
            Console.WriteLine("Individual Investment balance is ${0}", IndInvest.Balance);
            Console.WriteLine("Corporate Investment balance is ${0}", CorpInvest.Balance);
        }
    }
}
