using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.FlightTests
{
    [TestFixture]
    public class FlightTypeIdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Flight();
            var expected = 5;
            sut.FlightTypeId = expected;

            // Act
            var actual = sut.FlightTypeId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new Flight();
            var expected = 5;

            // Act
            sut.FlightTypeId = expected;
            var actual = sut.FlightTypeId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
