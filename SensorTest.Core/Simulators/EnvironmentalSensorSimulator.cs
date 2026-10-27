using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorTest.Core.Models;

namespace SensorTest.Core.Simulators
{
    public class EnvironmentalSensorSimulator
    {
        private readonly Random random = new Random();
        public EnvironmentalReading GenerateReading()
        {
            var sensorReading = new EnvironmentalReading("ENV-001");
            sensorReading.Timestamp = DateTime.Now;
            sensorReading.Temperature = 20 + 10 * random.NextDouble();
            sensorReading.Pressure = 980 + 150 * random.NextDouble();
            sensorReading.Humidity = 30 + 40 * random.NextDouble();

            return sensorReading;

        }
    }
}
