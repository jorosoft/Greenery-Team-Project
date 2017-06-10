using System;
using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.FlightTests
{
    [TestFixture]
    public class ScheduledTimeProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Flight();
            var expected = new DateTime(2017, 6, 7, 12, 30, 0);
            sut.SheduledTime = expected;

            // Act
            var actual = sut.SheduledTime;

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
            sut.SheduledTime = expected;
            var actual = sut.SheduledTime;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
