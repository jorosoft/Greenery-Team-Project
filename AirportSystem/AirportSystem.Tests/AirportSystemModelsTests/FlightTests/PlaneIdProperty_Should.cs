using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.FlightTests
{
    [TestFixture]
    public class PlaneIdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Flight();
            var expected = 5;
            sut.PlaneId = expected;

            // Act
            var actual = sut.PlaneId;

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
            sut.PlaneId = expected;
            var actual = sut.PlaneId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
