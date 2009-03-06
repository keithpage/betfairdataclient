using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betfair.Data.Sports.Interfaces
{
    public interface ISports
    {
        /*** Events ***/

        /// <summary>
        /// Returns a list of Betfair events, if eventParentId value is set to 0 the root level events will be returned
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        List<Betfair.Data.Sports.Views.EventBase> GetEventTree(object[] args);

        /*** Market Data Operations ***/

        /// <summary>
        /// Returns a single instance of the market
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Betfair.Data.Sports.Views.MarketBase GetMarket(object[] args);

        /// <summary>
        /// This initiates the market object creation and adds the market to an internal watchlist
        /// or in the case of push services it will subscribe to a market feed
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Boolean RegisterMarket(object[] args);

        /// <summary>
        /// Remove the market from the watchlist
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Boolean UnregisterMarket(object[] args);

        /// <summary>
        /// Returns true if the market is in the market watch list
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Boolean MarketWatchListContains(object args);
    }
}
