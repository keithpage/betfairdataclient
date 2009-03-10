/* Broker.cs
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
using System.Windows.Forms;

namespace Betfair.EventBroker
{
    public sealed class Broker
    {
        private static readonly object syncRoot = new Object();
        private static volatile Broker instance;
        private static Dictionary<string, List<Delegate>> subscriptions;


        /// <summary>
        /// Initializes a new instance of the <see cref="Broker"/> class.
        /// </summary>
        private Broker()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static Broker Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Broker();
                            subscriptions = new Dictionary<string, List<Delegate>>();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>The subscriptions.</value>
        private static Dictionary<string, List<Delegate>> Subscriptions
        {
            get { return subscriptions; }
            set
            {
                lock (syncRoot)
                {
                    subscriptions = value;
                }
            }
        }

        public static event EventHandler SubscriptionAdded;
        public static event EventHandler SubscriptionRemoved;

        /// <summary>
        /// Raises the <see cref="SubscriptionAdded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private static void OnSubscriptionAdded(EventArgs e)
        {
            if (SubscriptionAdded != null)
                SubscriptionAdded(instance, e);
        }

        /// <summary>
        /// Raises the subscription removed event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private static void OnSubscriptionRemoved(EventArgs e)
        {
            if (SubscriptionRemoved != null)
                SubscriptionRemoved(instance, e);
        }


        /// <summary>
        /// Subscribe method to the specified event.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="method">The method Delegate to be invoked when Event fires.</param>
        public static void Subscribe(string id, Delegate method)
        {
            //Check if there is a existing event
            List<Delegate> delegates = null;

            if (Subscriptions == null)
                Subscriptions = new Dictionary<string, List<Delegate>>();

            if (Subscriptions.ContainsKey(id))
            {
                delegates = subscriptions[id];
            }
            else
            {
                delegates = new List<Delegate>();
                Subscriptions.Add(id, delegates);
            }


            delegates.Add(method);
            OnSubscriptionAdded(new EventArgs());
        }


        /// <summary>
        /// Unsubscribe method from event notifications
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="method">The method.</param>
        public static void Unsubscribe(string id, Delegate method)
        {
            if (Subscriptions.ContainsKey(id))
            {
                if (Subscriptions[id].Contains(method))
                {
                    Subscriptions[id].Remove(method);
                    OnSubscriptionRemoved(new EventArgs());
                }

                if (Subscriptions[id].Count == 0)
                    Subscriptions.Remove(id);
            }
        }

        /// <summary>
        /// Unsubscribes all.
        /// </summary>
        public static void UnsubscribeAll()
        {
            if (subscriptions != null)
            {
                lock (subscriptions)
                {
                    subscriptions.Clear();
                }
            }
        }


        /// <summary>
        /// Executes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public static void Execute(string id, object sender, EventArgs e)
        {
            if (!Subscriptions.ContainsKey(id)) return;
            for (var i = 0; i < Subscriptions[id].Count; i++)
            {
                var x = Subscriptions[id][i];
                DynamicInvoke(id, x, sender, e);

                if (!Subscriptions.ContainsKey(id))
                    break;
            }
        }


        /// <summary>
        /// Dynamicly invoke.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="x">The x.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private static void DynamicInvoke(string id, Delegate x, object sender, EventArgs e)
        {
            if (x.Target is Control)
            {
                var ctl = (Control) x.Target;

                if (ctl.IsDisposed)
                {
                    Unsubscribe(id, x);
                    return;
                }
            }

            if (x.Target == null)
            {
                Unsubscribe(id, x);
                return;
            }

            x.DynamicInvoke(sender, e);
        }
    }
}