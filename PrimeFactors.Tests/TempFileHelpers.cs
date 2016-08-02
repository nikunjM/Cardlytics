using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors.Tests
{
    static class TempFileHelpers
    {
        /// <summary>
        ///  Write the body to a temporary text file and return the path to the file.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static string CreateTestFile(string body)
        {
            var path = Path.GetTempFileName();

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(body);
            }

            return path;
        }

        /// <summary>
        /// Delete a file that is pointed to by the path.
        /// </summary>
        /// <param name="path"></param>
        public static void RemoveTestFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
