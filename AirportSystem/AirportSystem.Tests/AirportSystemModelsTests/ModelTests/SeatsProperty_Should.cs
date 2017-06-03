using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.ModelTests
{
    [TestFixture]
    public class SeatsProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Model();
            var expected = 123;
            sut.Seats = expected;

            // Act
            var actual = sut.Seats;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new Model();
            var expected = 123;

            // Act
            sut.Seats = expected;
            var actual = sut.Seats;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
