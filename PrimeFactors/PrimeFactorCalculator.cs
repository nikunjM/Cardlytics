using System.Collections.Generic;

namespace PrimeFactors
{
    /// <summary>
    /// A calculator that finds the prime factors for any integer
    /// </summary>
    /// <remarks>
    /// Built this by going through the kata found here: http://craftsmanship.sv.cmu.edu/katas/prime-factors-kata
    /// </remarks>
    public class PrimeFactorCalculator : IPrimeFactorCalculator
    {
        /// <summary>
        /// Take a number and get the list of prime factors. 
        /// </summary>
        /// <param name="number">Expects a positive 32 bit integers.</param>
        /// <returns>List of prime factors.</returns>
        public IList<int> Execute(int number)
        {
            var primes = new List<int>();

            // Go up through the candidates, while reducing the number we are finding prime factors for. 
            // Worst case will be a large prime, but even in this case it shouldn't be worse than O(n)
            for (var candidate = 2; candidate <= number && candidate > 0; candidate++)
            {
                while (number % candidate == 0)
                {
                    primes.Add(candidate);
                    number = number / candidate;
                }
            }

            return primes;
        }
    }
}
