using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.AirportTests
{
    [TestFixture]
    public class NameProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Airport();
            var expected = "Plovdiv Airport";
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
            var sut = new Airport();
            var expected = "Plovdiv Airport";

            // Act
            sut.Name = expected;
            var actual = sut.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
