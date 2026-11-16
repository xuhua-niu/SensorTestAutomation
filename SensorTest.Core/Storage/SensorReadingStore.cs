using SensorTest.Core.Models;


namespace SensorTest.Core.Storage
{
    public class SensorReadingStore
    {
        public EnvironmentalReading? LatestReading { get; private set; }

        public void Save(EnvironmentalReading reading)
        { 
            LatestReading = reading; 
        }
    }
}
