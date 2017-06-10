using AirportSystem.Converters;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Tests.AirportSystemTests.ConvertersTests.ExcelDeserializerTests
{
    [TestFixture]
    class Deserialize_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithPropperMessage_WhenNullValueIsPassed()
        {
            // Arrange
            var sut = new Mock<ExcelDeserializer>().Object;
            var expectedMessage = "No input file";

            // Act & Assert            
            var ex = Assert.Throws<ArgumentNullException>(() => sut.Deserialize(null));
            StringAssert.Contains(expectedMessage, ex.Message);
        }
    }
}
