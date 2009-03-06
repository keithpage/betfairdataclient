using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betfair.Data.Sports.Views
{
    public sealed class MarketBase
    {
        public MarketBase() { }
        public MarketBase(object internalReferenceId)
        {
            this.internalReferenceId = internalReferenceId;
        }

        /// <summary>
        /// The unique identifier for this object in this instance
        /// </summary>
        public  readonly object internalReferenceId;

        /// <summary>
        /// Data store for this element
        /// </summary>
        public Dictionary<object, object> values;

        /// <summary>
        /// The fine grained internal type of this objects values
        /// eg. istypeof = Betfair.Data.Sports.Market.HorseRacing
        /// or istypeof = Betfair.Data.Sports.Market.IrishTote
        /// or istypeof = Betfair.Data.Sports.Market.AsianHandicap
        /// </summary>
        public readonly string isTypeOf;
    }
}
