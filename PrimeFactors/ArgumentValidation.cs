using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    using Resources = Properties.Resources;

    /// <summary>
    /// Provide some general methods for "checking" function arguments.  I put checking in
    /// quotes because we are really just kick and scream sooner than later.  Code contracts
    /// would probably be a better route to go.
    /// </summary>
    public static class ArgumentValidation
    {
        /// <summary>
        /// Check an argument to be not null and throw an ArgumentNullException if it is.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="paramName">The name of the parameter for logging purposes.</param>
        public static void NotNullCheck<T>(T value, string paramName)
            where T : class
        {
            if (value == null) 
            {
                var message = string.Format(Resources.ArgumentException_Missing, paramName);

                throw new ArgumentNullException(paramName, message);
            }
        }
    }
}
