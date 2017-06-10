using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.AirlineTests
{
    [TestFixture]
    public class NameProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Airline();
            var expected = "Bulgaria Air";
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
            var sut = new Airline();
            var expected = "Bulgaria Air";

            // Act
            sut.Name = expected;
            var actual = sut.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
