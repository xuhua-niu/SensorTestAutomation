using SensorTest.Core.Models;
using SensorTest.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTest.Tests
{
    public class TemnperatureValidatorTests
    {
        [Fact]
        public void IsOverThreshold_TemperatureAboveThreshold_ReturnsTrue()
        {
            // Arrange
            var reading = new EnvironmentalReading("Env-001");
            reading.Temperature = 38;
            var validator = new TemperatureValidator();

            // Act
            bool result = validator.IsOverThreshold(reading, 35);

            // Assert
            Assert.True(result);       
        }

        [Fact]
        public void IsOverThreshold_TemperatureEqualsThreshold_ReturnsFalse()
        {
            // Arrange
            var reading = new EnvironmentalReading("Env-001");
            reading.Temperature = 35;
            var validator = new TemperatureValidator();

            // Act
            bool result = validator.IsOverThreshold(reading, 35);

            // Assert
            Assert.False(result);
           
        }

        [Fact]
        public void IsOverThreshold_TemperatureBelowThreshold_ReturnsFalse()
        {
            // Arrange
            var reading = new EnvironmentalReading("Env-001");
            reading.Temperature = 32;
            var validator = new TemperatureValidator();

            // Act
            bool result = validator.IsOverThreshold(reading, 35);

            // Assert
            Assert.False(result);

        }

        [Theory]
        [InlineData(35.1, 35, true)]
        [InlineData(35.0, 35, false)]
        [InlineData(34.9, 35, false)]

        public void IsOverThreshold_ReturnsExpectedResults(
            double temperature,
            double threshold,
            bool expected)
        {
            // Arrange
            var reading = new EnvironmentalReading("Env-001");
            reading.Temperature = temperature;
            var validator = new TemperatureValidator();

            // Act
            bool result = validator.IsOverThreshold(reading, threshold);

            // Assert
            Assert.Equal(expected, result);

        }

    }
}
