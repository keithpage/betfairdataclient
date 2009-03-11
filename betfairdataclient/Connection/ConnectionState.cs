namespace Betfair.Connection
{
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