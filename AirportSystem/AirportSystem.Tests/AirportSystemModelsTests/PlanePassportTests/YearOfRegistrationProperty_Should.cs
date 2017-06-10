using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.PlanePassportTests
{
    [TestFixture]
    public class YearOfRegistrationProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new PlanePassport();
            var expected = 5;
            sut.YearOfRegistration = expected;

            // Act
            var actual = sut.YearOfRegistration;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new PlanePassport();
            var expected = 5;

            // Act
            sut.YearOfRegistration = expected;
            var actual = sut.YearOfRegistration;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
