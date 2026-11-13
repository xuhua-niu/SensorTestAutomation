using SensorTest.Core.Models;
using SensorTest.Core.Services;


namespace SensorTest.Tests
{
    public class AlarmServiceTests
    {
        [Theory]
        [InlineData(38.5, 35.0, true)]
        [InlineData(35.0, 35.0, false)]
        [InlineData(30.0, 35.0, false)]
        public void CheckTemperature_ReturnExpectedAlarmStatus(double temperature, double threshold, bool expectedAlarm) 
        {
            
            //Arrange
            var reading = new EnvironmentalReading("ENV-001");
            reading.Temperature = temperature;

            var service = new AlarmService();

            //Act
            AlarmResult result = service.CheckTemperature(reading, threshold);

            //Assert
            Assert.Equal(expectedAlarm, result.IsAlarm);
            Assert.Equal(reading.SensorId, result.SensorID);
            Assert.Equal(temperature, result.Temperature);
            Assert.Equal(threshold, result.Threshold);

        }
    }
}
