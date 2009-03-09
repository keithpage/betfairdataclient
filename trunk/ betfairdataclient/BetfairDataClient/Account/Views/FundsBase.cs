/* 
 * FundsBase.cs
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

namespace Betfair.Data.Account.Views
{
	/// <summary>
	/// Class that holds all user account fund information
	/// </summary>
    public sealed class FundsBase
    {
		// standard type name
        private const String c_EventBase = "FundsBase";

		#region Ctor

		/// <summary>
        /// Initializes a new instance of the <see cref="FundsBase"/> class.
		/// </summary>
		public FundsBase() 
		{
			// create value dictionary
			this.Values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

			// set standard type name
			this.TypeName = c_EventBase;
		}

		/// <summary>
        /// Initializes a new instance of the <see cref="FundsBase"/> class.
		/// </summary>
		/// <param name="internalReferenceId">The internal reference id.</param>
        public FundsBase(object internalReferenceId)
			: this()
		{
			// set internal id
			this.InternalReferenceId = internalReferenceId;
		}

		#endregion

		#region Properties

		private object _InternalReferenceId;

		/// <summary>
		/// Gets or sets the internal reference id.
		/// </summary>
		/// <value>The internal reference id.</value>
		public object InternalReferenceId
		{
			get { return _InternalReferenceId; }
			internal set { _InternalReferenceId = value; }
		}

		private string _TypeName;

		/// <summary>
		/// Gets or sets the name of the type.
		/// The type name represents the  fine grained internal type of this objects values
		/// </summary>
		/// <value>The name of the type.</value>
		public string TypeName
		{
			get { return _TypeName; }
			set { _TypeName = value; }
		}

		private Dictionary<String, object> _Values;

		/// <summary>
		/// Gets or sets the values.
		/// </summary>
		/// <value>The values.</value>
		public Dictionary<String, object> Values
		{
			get { return _Values; }
			private set { _Values = value; }
		}

		#endregion

    }
}
