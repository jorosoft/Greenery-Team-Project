using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.AirportTests
{
    [TestFixture]
    public class IdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Airport();
            var expected = 5;
            sut.Id = expected;

            // Act
            var actual = sut.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new Airport();
            var expected = 5;

            // Act
            sut.Id = expected;
            var actual = sut.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
