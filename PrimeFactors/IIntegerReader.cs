using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    /// <summary>
    /// Interface for abstracting the reading of the integer file.
    /// </summary>
    public interface IIntegerReader : IDisposable
    {
        int? ReadNext();
    }
}
