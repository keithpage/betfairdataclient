using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betfair.Data.DataProviders.Sports
{
    public class BetfairAPI6 : Betfair.Data.Sports.Interfaces.ISports
    {
        #region ISports Members

        public List<Betfair.Data.Sports.Views.EventBase> GetEventTree(object[] args)
        {
            throw new NotImplementedException();
        }

        public Betfair.Data.Sports.Views.MarketBase GetMarket(object[] args)
        {
            throw new NotImplementedException();
        }

        public bool RegisterMarket(object[] args)
        {
            throw new NotImplementedException();
        }

        public bool UnregisterMarket(object[] args)
        {
            throw new NotImplementedException();
        }

        public bool MarketWatchListContains(object args)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
