using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.PlaneTests
{
    [TestFixture]
    public class AirlineIdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Plane();
            var expected = 5;
            sut.AirlineId = expected;

            // Act
            var actual = sut.AirlineId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new Plane();
            var expected = 5;

            // Act
            sut.AirlineId = expected;
            var actual = sut.AirlineId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
