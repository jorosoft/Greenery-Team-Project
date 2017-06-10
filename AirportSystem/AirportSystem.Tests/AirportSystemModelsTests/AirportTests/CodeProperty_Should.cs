using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.AirportTests
{
    [TestFixture]
    public class CodeProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Airport();
            var expected = "LBPD";
            sut.Code = expected;

            // Act
            var actual = sut.Code;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new Airport();
            var expected = "LBPD";

            // Act
            sut.Code = expected;
            var actual = sut.Code;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
