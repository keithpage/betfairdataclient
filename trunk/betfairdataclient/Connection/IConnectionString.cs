/* IConnectionString.cs
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

using System.Collections.Generic;

namespace Betfair.Connection
{
    public interface IConnectionString
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>The provider.</value>
        string Provider { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The product id.</value>
        int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the software id.
        /// </summary>
        /// <value>The software id.</value>
        int SoftwareId { get; set; }

        /// <summary>
        /// Gets or sets the max connections.
        /// </summary>
        /// <value>The max connections.</value>
        int MaxConnections { get; set; }

        /// <summary>
        /// Gets or sets the connection items.
        /// </summary>
        /// <value>The connection items.</value>
        Dictionary<string, object> ConnectionItems { get; set; }

        /// <summary>
        /// parse connection string to a dcitionary of values.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        Dictionary<string, object> ConnectionStringParser(string connectionString);
    }
}