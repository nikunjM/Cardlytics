using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    /// <summary>
    /// An abstraction of our prime factor calculation so we can do 
    /// fun stuff like decorate
    /// </summary>
    public interface IPrimeFactorCalculator
    {
        /// <summary>
        /// Take a number and get the list of prime factors. 
        /// </summary>
        IList<int> Execute(int number);
    }
}
