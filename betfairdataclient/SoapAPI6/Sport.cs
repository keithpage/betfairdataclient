/* Sport.cs
 * 
 * Copyright (c) 2009 © The Sporting Exchange Limited. All rights reserved. http://www.betfair.com.
 * BETFAIR® and the BETFAIR LOGO are registered trade marks of The Sporting Exchange Limited. 
 * Data on Betfair website(s) (including pricing data) is protected by © and database rights. 
 * It may not be used for any purpose without a licence.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *  1.  Redistributions of source code must retain the above copyright notice,
 *		this list of conditions and the following disclaimer.
 *  2.  Redistributions in binary form must reproduce the above copyright 
 *		notice, this list of conditions and the following disclaimer in 
 *		the documentation and/or other materials provided with the distribution.
 *  3.  The names of the authors may not be used to endorse or promote products
 *  	derived from this software without specific prior written permission.
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
 * You should have received a copy of the GNU General Public License. If not, see <http://www.gnu.org/licenses/>.
 **/

using System;
using System.Collections.Generic;
using Betfair.Connection;
using Betfair.DAL;
using Betfair.Facade;

namespace Betfair.DataProvider.SoapAPI6
{
    public class Sport : ISports
    {
        public Sport(IConnectionString connection)
        {
            Connection = connection;
        }

        #region ISports Members

        public IConnectionString Connection { get; set; }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public ConnectionState ConnectionStatus { get; set; }

        public List<IData> GetItem(List<IData> data)
        {
            throw new NotImplementedException();
        }

        public List<IData> Register(List<IData> data)
        {
            throw new NotImplementedException();
        }

        public List<IData> Unregister(List<IData> data)
        {
            throw new NotImplementedException();
        }

        public List<IData> WatchListContains(List<IData> data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}