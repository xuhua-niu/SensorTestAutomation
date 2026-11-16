using SensorTest.Core.Models;
using SensorTest.Core.Simulators;
using SensorTest.Core.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTest.Tests
{
    public class SensorReadingStoreTests
    {
        [Fact]
        public void LastReading_ShouldBeNull_WhenStoreIsNew()
        {
            //Arrange
            var store = new SensorReadingStore();

            //Act
            var result = store.LatestReading;

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void LastReading_ShouldReturnSaveReading()
        {
            //Arrange
            var store = new SensorReadingStore();
            var simulator = new EnvironmentalSensorSimulator();
            var reading = simulator.GenerateReading();


            //Act
            store.Save(reading);
            var result = store.LatestReading;

            //Assert
            Assert.Same(reading,result);
        }

        [Fact]
        public void LastReading_ShouldBeUpdated_WhenSavedTwice()
        {
            //Arrange
            var store = new SensorReadingStore();
            var reading1 = new EnvironmentalReading("ENV-001");
            var reading2 = new EnvironmentalReading("ENV-001");

            //Act
            store.Save(reading1);
            store.Save(reading2);
            var result = store.LatestReading;

            //Assert
            Assert.Same(reading2 ,result);


        }
            
    }
}
