using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.PlaneTests
{
    [TestFixture]
    public class ManufacturerIdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Plane();
            var expected = 5;
            sut.ManufacturerId = expected;

            // Act
            var actual = sut.ManufacturerId;

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
            sut.ManufacturerId = expected;
            var actual = sut.ManufacturerId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
