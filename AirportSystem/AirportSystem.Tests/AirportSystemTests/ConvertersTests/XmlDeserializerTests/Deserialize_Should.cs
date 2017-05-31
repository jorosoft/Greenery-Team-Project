using Moq;
using NUnit.Framework;
using System;
using AirportSystem.Converters;

namespace AirportSystem.Tests.AirportSystemTests.ConvertersTests.XmlDeserializerTests
{
    [TestFixture]
    public class Deserialize_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithPropperMessage_WhenNullValueIsPassed()
        {
            // Arrange
            var sut = new XmlDeserializer();
            var expectedMessage = "No input file";

            // Act & Assert            
            var ex = Assert.Throws<ArgumentNullException>(() => sut.Deserialize(null));
            StringAssert.Contains(expectedMessage, ex.Message);
        }
    }
}
