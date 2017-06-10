using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.PlanePassportTests
{
    [TestFixture]
    public class StateProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new PlanePassport();
            var expected = "Perfect condition";
            sut.State = expected;

            // Act
            var actual = sut.State;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new PlanePassport();
            var expected = "Perfect condition";

            // Act
            sut.State = expected;
            var actual = sut.State;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
