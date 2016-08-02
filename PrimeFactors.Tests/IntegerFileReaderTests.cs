using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace PrimeFactors.Tests
{
    [TestFixture]
    public class IntegerFileReaderTests
    {
        [Test]
        public void Test_Missing_File()
        {
            var path = Path.Combine(Path.GetTempPath(), "FileThatDoesNotExist.txt");

            // Ensure that the file wasn't created for whatever reason.
            Assert.IsFalse(File.Exists(path));

            var reader = new IntegerFileReader(path);

            Assert.Throws<FileNotFoundException>(() =>
                reader.ReadNext(),
                "A missing file exeption was not fired."
            );
        }

        [Test]
        public void Test_Empty_File()
        {
            var path = TempFileHelpers.CreateTestFile(string.Empty);

            var reader = new IntegerFileReader(path);

            // Make sure that we don't read anything.
            Assert.AreEqual(reader.ReadNext(), null);
        }

        [Test]
        public void Test_Garbage_Before_Number_File()
        {
            var path = TempFileHelpers.CreateTestFile("Stuff\r\n123");

            var reader = new IntegerFileReader(path);

            var number = reader.ReadNext();

            Assert.IsTrue(number.HasValue);
            Assert.AreEqual(123, number.Value);
        }

        [Test]
        public void Test_Garbage_Multiple_Numbers()
        {
            var path = TempFileHelpers.CreateTestFile("321\r\n123");

            var reader = new IntegerFileReader(path);

            var number = reader.ReadNext();

            Assert.IsTrue(number.HasValue);
            Assert.AreEqual(321, number.Value);

            number = reader.ReadNext();

            Assert.IsTrue(number.HasValue);
            Assert.AreEqual(123, number.Value);
        }
    }
}
