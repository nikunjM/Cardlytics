using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    using Resources = Properties.Resources;

    /// <summary>
    /// A decorator class to output the result of our prime factor calculation.
    /// </summary>
    public class PrimeFactorOutputWriter : IPrimeFactorCalculator
    {
        private IPrimeFactorCalculator _calculator;
        private ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the PrimeFactorOutputWriter class.
        /// </summary>
        /// <param name="calculator"></param>
        /// <param name="logger"></param>
        public PrimeFactorOutputWriter(IPrimeFactorCalculator calculator, ILogger logger)
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
            var result = _calculator.Execute(number);

            // Make sure that we have something to format.
            if (result == null || !result.Any())
            {
                result = new List<int>() { 1 };
            }

            // Combine the list of factors.
            var combined = string.Join
            (
                Resources.PrimeFactorOutputWriter_OutputSeparator, 
                result
            );

            // Now combine the input with the output.  I know it wasn't part of
            // the requirements to put the input in the output, but thought it 
            // would be easier to troubleshoot.  Should look like "6:2,3"
            var message = string.Concat
            (
                number, 
                Resources.PrimeFactorOutputWriter_InputOutputSeparator,
                combined
            );

            _logger.Log(message);

            return result;
        }
    }
}
