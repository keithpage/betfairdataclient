/* IConnection.cs
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
using System.Linq;
using System.Text;

namespace Betfair.Facade
{
    public interface IConnection
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        string ConnectionString { get; set;}

        /// <summary>
        /// Opens this connection.
        /// </summary>
        void Open();

        /// <summary>
        /// Closes this connection.
        /// </summary>
        void Close();

        /// <summary>
        /// Current connections status.
        /// </summary>
        /// <returns></returns>
        ConnectionState Status();
    }

    /// <summary>
    /// Describes the current state of the connection to a data provider. 
    /// </summary>
    public enum ConnectionState
    {
        /// <summary>
        /// The connection is closed. 
        /// </summary>
        Closed = 0,
        /// <summary>
        /// The connection is open. 
        /// </summary>
        Open=1,
        /// <summary>
        /// The connection object is connecting to the data provider.
        /// </summary>
        Connecting = 2,
        /// <summary>
        /// The connection object is retrieving data.
        /// </summary>
        Fetching=3
    }
}
