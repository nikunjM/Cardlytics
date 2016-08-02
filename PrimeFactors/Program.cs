using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    using Resources = Properties.Resources;

    /// <summary>
    /// This program processes a file of integers line by line and ouputs the prime factors to the output window.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point.  We are expecting a path to the input file as the first argument.
        /// </summary>
        /// <param name="args">This is where we get the input file from.</param>
        static void Main(string[] args)
        {
            // Per the requirements, we are going to be dumping everything to the console.
            ILogger logger = new ConsoleLogger(Console.Out, Console.Error);

            // Build the processing pipeline that will handle the file entries.
            // In this case, because the input/output is so simple, we are just going to use 
            // the decorator pattern 
            IPrimeFactorCalculator calculator = new PrimeFactorCalculator(); // The main calculator.
            calculator = new PrimeFactorOutputWriter(calculator, logger);    // Our formatter for dumping to the console
            calculator = new PrimeFactorExceptionLogger(calculator, logger); // An exception handler that can log errors for us.

            // Grab the reader that will handling the reading of the file.  Args should never be null so 
            // it's safe to just send in the first one and deal with the blow back when we go to try and
            // read something.
            IIntegerReader reader = new IntegerFileReader(args.FirstOrDefault());

            try
            {
                // Simple simple, use our reader to roll through the input and pass it 
                // off to the processing pipeline that we built up.
                int? number;
                while ((number = reader.ReadNext()) != null)
                {
                    calculator.Execute(number.Value);
                }
            }
            catch (Exception ex)
            {
                // Since we have the PrimeFactorExceptionLogger in our processing pipeline, 
                // this was more than likely an issue with the IO. Log it and lets go home 
                // for the day.
                logger.LogError(ex);
            }
            finally
            {
                // Yeah, the application is about to terminate, but just to be tiddy
                if (reader != null) reader.Dispose();
            }

            Console.WriteLine(Resources.PressToContinueMessage);
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
