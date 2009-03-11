/* BetfairConnectionStringBuilder.cs
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
using System.Text.RegularExpressions;

namespace Betfair.Connection
{
    public class BetfairConnectionStringBuilder : IConnectionString
    {
        public BetfairConnectionStringBuilder()
        {
            ConnectionItems = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public BetfairConnectionStringBuilder(string connectionString)
            : this()
        {
            ConnectionItems = ConnectionStringParser(connectionString);
        }

        #region IConnectionString Members

        public string ConnectionString
        {
            get
            {
                string response = "";

                foreach (var item in ConnectionItems)
                {
                    response = String.Format("{0}={1};{2}", item.Key, item.Value, response);
                }
                return response;
            }
            set { ConnectionItems = ConnectionStringParser(value); }
        }

        public string Provider
        {
            get
            {
                if (ConnectionItems.ContainsKey("Provider"))
                {
                    return (String) ConnectionItems["Provider"];
                }
                return null;
            }
            set
            {
                if (ConnectionItems.ContainsKey("Provider"))
                {
                    ConnectionItems["Provider"] = value;
                }
                else
                {
                    ConnectionItems.Add("Provider", value);
                }
            }
        }

        public string Username
        {
            get
            {
                if (ConnectionItems.ContainsKey("Username"))
                {
                    return (String) ConnectionItems["Username"];
                }
                return null;
            }
            set
            {
                if (ConnectionItems.ContainsKey("Username"))
                {
                    ConnectionItems["Username"] = value;
                }
                else
                {
                    ConnectionItems.Add("Username", value);
                }
            }
        }

        public string Password
        {
            get
            {
                if (ConnectionItems.ContainsKey("Password"))
                {
                    return (String) ConnectionItems["Password"];
                }
                return null;
            }
            set
            {
                if (ConnectionItems.ContainsKey("Password"))
                {
                    ConnectionItems["Password"] = value;
                }
                else
                {
                    ConnectionItems.Add("Password", value);
                }
            }
        }

        public int ProductId
        {
            get
            {
                if (ConnectionItems.ContainsKey("ProductId"))
                {
                    return Convert.ToInt32(ConnectionItems["ProductId"]);
                }
                return 0;
            }
            set
            {
                if (ConnectionItems.ContainsKey("ProductId"))
                {
                    ConnectionItems["ProductId"] = value;
                }
                else
                {
                    ConnectionItems.Add("ProductId", value);
                }
            }
        }

        public int SoftwareId
        {
            get
            {
                if (ConnectionItems.ContainsKey("SoftwareId"))
                {
                    return Convert.ToInt32(ConnectionItems["SoftwareId"]);
                }
                return 0;
            }
            set
            {
                if (ConnectionItems.ContainsKey("SoftwareId"))
                {
                    ConnectionItems["SoftwareId"] = value;
                }
                else
                {
                    ConnectionItems.Add("SoftwareId", value);
                }
            }
        }

        public int MaxConnections
        {
            get
            {
                if (ConnectionItems.ContainsKey("MaxConnections"))
                {
                    return (int) ConnectionItems["MaxConnections"];
                }
                return 0;
            }
            set
            {
                if (ConnectionItems.ContainsKey("MaxConnections"))
                {
                    ConnectionItems["MaxConnections"] = value;
                }
                else
                {
                    ConnectionItems.Add("MaxConnections", value);
                }
            }
        }

        public Dictionary<string, object> ConnectionItems { get; set; }

        public Dictionary<string, object> ConnectionStringParser(string connectionString)
        {
            // Create the response object
            var result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            // if an invalid string was submitted return an empty result
            if (String.IsNullOrEmpty(connectionString))
            {
                return result;
            }

            // Remove whitspace from the string
            connectionString = new Regex(@"\s*").Replace(connectionString, string.Empty);

            // Create an array of items
            string[] itemArray = connectionString.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);

            // Add the items to the list
            foreach (string stringResult in itemArray)
            {
                if (stringResult.Contains("="))
                {
                    string[] elementArray = stringResult.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);

                    if (elementArray.Length > 2)
                    {
                        throw new Exception(String.Format("Too many items found in the connection string element {0}.",
                                                          elementArray[0]));
                    }
                    if (elementArray.Length == 1)
                        result.Add(elementArray[0].ToLower(), null);
                    else if (elementArray.Length == 2)
                        result.Add(elementArray[0].ToLower(), elementArray[1]);
                }
            }

            return result;
        }

        #endregion
    }
}