using SensorTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTest.Core.Validators
{
    public class TemperatureValidator
    {
        public bool IsOverThreshold(EnvironmentalReading reading, double threshold)
        {
            return reading.Temperature > threshold;
        }
    }
}
