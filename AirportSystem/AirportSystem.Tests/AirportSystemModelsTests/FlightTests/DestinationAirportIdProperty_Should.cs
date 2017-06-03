using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.FlightTests
{
    [TestFixture]
    public class DestinationAirportIdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Flight();
            var expected = 5;
            sut.DestinationAirportId = expected;

            // Act
            var actual = sut.DestinationAirportId;

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
            sut.DestinationAirportId = expected;
            var actual = sut.DestinationAirportId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
