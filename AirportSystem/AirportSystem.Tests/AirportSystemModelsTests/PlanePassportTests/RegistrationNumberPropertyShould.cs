using NUnit.Framework;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.PlanePassportTests
{
    [TestFixture]
    public class RegistrationNumberPropertyShould
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new PlanePassport();
            var expected = "BG11111SL";
            sut.RegistrationNumber = expected;

            // Act
            var actual = sut.RegistrationNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new PlanePassport();
            var expected = "BG11111SL";

            // Act
            sut.RegistrationNumber = expected;
            var actual = sut.RegistrationNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
