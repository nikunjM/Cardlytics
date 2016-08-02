using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    /// <summary>
    /// Does what it can to safely wrap up the console standard and error output 
    /// streams behind the <see cref="ILogger"/> interface.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private TextWriter _standardOutput;
        private TextWriter _errorOutput;

        /// <summary>
        /// Initializes a new instance of the ConsoleLogger class.
        /// </summary>
        /// <param name="standardOutput"></param>
        /// <param name="errorOutput"></param>
        public ConsoleLogger(TextWriter standardOutput, TextWriter errorOutput)
        {
            _standardOutput = standardOutput ?? TextWriter.Null;
            _errorOutput = errorOutput ?? TextWriter.Null;
        }

        /// <summary>
        /// Log a message to the console.
        /// </summary>
        public void Log(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                _standardOutput.WriteLine(message);
            }
        }

        /// <summary>
        /// This isn't that interesting of a read.  I'd move on.
        /// </summary>
        public void Log(string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format))
            {
                _standardOutput.WriteLine(string.Format(format, args));
            }
        }

        /// <summary>
        /// You really are persistent, aren't you.
        /// </summary>
        public void LogError(Exception ex)
        {
            if (ex != null)
            {
                _errorOutput.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Well obviously, you can't put a bad book down so this will log an exception and 
        /// a hopefully more pleasant message to the console window.
        /// </summary>
        public void LogError(Exception ex, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                _errorOutput.WriteLine(message);
            }
            if (ex != null)
            {
                _errorOutput.WriteLine(ex.ToString());
            }
        }
    }
}
