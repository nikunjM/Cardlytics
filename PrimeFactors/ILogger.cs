using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    /// <summary>
    /// A simple, no non-sense logger.  For something more robust, I would use 
    /// NLog or log4net wrapped with the Castle's core logging abstractions.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log a message to some place fun.
        /// </summary>
        void Log(string message);

        /// <summary>
        /// Format and log a message to somewhere just as fun.
        /// </summary>
        void Log(string format, params object[] args);

        /// <summary>
        /// Log an exception and cry just a little on the inside.
        /// </summary>
        void LogError(Exception ex);

        /// <summary>
        /// Log an exception with some well wishes to make everyone feel a little better.
        /// </summary>
        void LogError(Exception ex, string message);
    }
}
