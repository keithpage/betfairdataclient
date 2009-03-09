/* 
 * ISports.cs
 * 
 * Copyright (c) 2009 © The Sporting Exchange Limited. All rights reserved. http://www.betfair.com.
 * BETFAIR® and the BETFAIR LOGO are registered trade marks of The Sporting Exchange Limited. 
 * Data on Betfair website(s) (including pricing data) is protected by © and database rights. 
 * It may not be used for any purpose without a licence.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 *  	1. Redistributions of source code must retain the above copyright notice,
 *		this list of conditions and the following disclaimer.
 *
 *	    2. Redistributions in binary form must reproduce the above copyright 
 *		notice, this list of conditions and the following disclaimer in 
 *		the documentation and/or other materials provided with the distribution.
 *
 *	    3. The names of the authors may not be used to endorse or promote products
 *		derived from this software without specific prior written permission.
 * 
 * The BetfairDataClient project is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The work is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 *
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR
 * OR ANY CONTRIBUTORS TO THIS SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT,
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * You should have received a copy of the GNU General Public License. If not, see <http://www.gnu.org/licenses/>.
 * 
 **/

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

        /*** Selection Data Operations ***/

        /// <summary>
        /// Get the selections in a market.
        /// We use the term selection rather than runner because selections is more generic.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        List<Betfair.Data.Sports.Views.SelectionBase> GetSelections(object args);
    }
}
