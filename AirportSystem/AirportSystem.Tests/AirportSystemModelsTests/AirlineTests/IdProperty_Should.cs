﻿using AirportSystem.Models;
using NUnit.Framework;

namespace AirportSystem.Tests.AirportSystemModelsTests.AirlineTests
{
    [TestFixture]
    public class IdProperty_Should
    {
        [Test]
        public void ReturnCorrectValue_WhenGetterIsCalled()
        {
            // Arrange
            var sut = new Airline();
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
            var sut = new Airline();
            var expected = 5;

            // Act
            sut.Id = expected;
            var actual = sut.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
