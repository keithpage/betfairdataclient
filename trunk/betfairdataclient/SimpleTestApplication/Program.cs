﻿using Betfair.DAL;
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
            ISports sport = SportFactory.Create(SportFactory.CommonProvider.SoapAPI6);

            IAccount account = AccountFactory.Create(AccountFactory.CommonAccountProviders.SoapAPI6);
        }
    }
}