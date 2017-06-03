using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.ManufacturerTests
{
    public class NameProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Manufacturer();
            var expected = "Boeing";
            sut.Name = expected;

            // Act
            var actual = sut.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new Manufacturer();
            var expected = "Boeing";

            // Act
            sut.Name = expected;
            var actual = sut.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
