using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTest.Core.Models
{
    public class EnvironmentalReading
    {
        public EnvironmentalReading(string sensorId) 
        {
            this.SensorId = sensorId;
        }
        public string SensorId { get; } 

        public DateTime Timestamp { get; set; }

        public double Temperature { get; set; }

        public double Pressure { get; set;}

        public double Humidity { get; set;}
    }
}
