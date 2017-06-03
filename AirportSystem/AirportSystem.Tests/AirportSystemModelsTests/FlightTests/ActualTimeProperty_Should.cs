using NUnit.Framework;
using System;
using AirportSystem.Models;

namespace AirportSystem.Tests.AirportSystemModelsTests.FlightTests
{
    [TestFixture]
    public class ActualTimeProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Flight();
            var expected = new DateTime(2017, 6, 7, 12, 30, 0);
            sut.ActualTime = expected;

            // Act
            var actual = sut.ActualTime;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetCorrectValue_WhenSetterAssigns()
        {
            // Arrange
            var sut = new Flight();
            var expected = new DateTime(2017, 6, 7, 12, 30, 0);

            // Act
            sut.ActualTime = expected;
            var actual = sut.ActualTime;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
