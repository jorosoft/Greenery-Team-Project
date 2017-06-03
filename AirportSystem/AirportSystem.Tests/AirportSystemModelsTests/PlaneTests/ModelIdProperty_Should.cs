using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.PlaneTests
{
    [TestFixture]
    public class ModelIdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Plane();
            var expected = 5;
            sut.ModelId = expected;

            // Act
            var actual = sut.ModelId;

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
            sut.ModelId = expected;
            var actual = sut.ModelId;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
