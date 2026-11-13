using SensorTest.Core.Models;
using SensorTest.Core.Validators;


namespace SensorTest.Core.Services
{
    public class AlarmService
    {
        public readonly TemperatureValidator validator = new TemperatureValidator();

        public AlarmResult CheckTemperature(EnvironmentalReading reading, double threshold) 
        {
            bool isAlarm = validator.IsOverThreshold(reading, threshold);

            return new AlarmResult(reading.SensorId, reading.Temperature, threshold, isAlarm);
        }
    }
}
