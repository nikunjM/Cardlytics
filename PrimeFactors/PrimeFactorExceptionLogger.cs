using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    /// <summary>
    /// A decorator class to send any calculation exceptions to the logger.
    /// </summary>
    public class PrimeFactorExceptionLogger : IPrimeFactorCalculator
    {
        IPrimeFactorCalculator _calculator;
        ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the PrimeFactorExceptionLogger class.
        /// </summary>
        /// <param name="calculator"></param>
        /// <param name="logger"></param>
        public PrimeFactorExceptionLogger(IPrimeFactorCalculator calculator, ILogger logger)
        {
            ArgumentValidation.NotNullCheck(calculator, "calculator");
            ArgumentValidation.NotNullCheck(logger, "logger");

            _calculator = calculator;
            _logger = logger;
        }

        /// <summary>
        /// Take a number and get the list of prime factors. 
        /// </summary>
        public IList<int> Execute(int number)
        {
            try
            {
                return _calculator.Execute(number);
            }
            catch (Exception ex)
            {
                string message = string.Format("Error calculating the prime factors for {0}.", number);
                _logger.LogError(ex, message);
            }

            return new List<int>();
        }
    }
}
