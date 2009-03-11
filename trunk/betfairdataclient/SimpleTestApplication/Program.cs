using System;
using Betfair.Connection;
using Betfair.DAL;
using Betfair.Factory;

namespace SimpleTestApplication
{
    internal class Program
    {
        /// <summary>
        /// Mains the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        private static void Main(string[] args)
        {
            var sb = new BetfairConnectionStringBuilder();
            sb.MaxConnections = 20;
            sb.Password = "MyPassword";
            sb.ProductId = 82;
            sb.Provider = "SoapAPI6";
            sb.SoftwareId = 0;
            sb.Username = "MyUsername";
            Console.WriteLine(sb.ConnectionString);

            sb.Username = null;
            Console.WriteLine(sb.ConnectionString);

            sb.ConnectionString = "Username = MyUsername2; Provider = SoapAPI6; ProductId = 82; Password=MyPassword; MaxConnections = 20; CustomValue = 23456";
            Console.WriteLine(sb.ConnectionString);

            ISports sport = SportFactory.Create(sb);
            //ISports sport = SportFactory.Create(SportFactory.CommonProvider.SoapAPI6);
            //sport.Open(sb.ConnectionString);

            IAccount account = AccountFactory.Create(sb);
            //account.Open(sb.ConnectionString);

            Console.WriteLine(account.ConnectionStatus.ToString());
        }
    }
}