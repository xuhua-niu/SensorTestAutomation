using SensorTest.Core.Simulators;

namespace SensorTest.Tests;

public class EnvironmentalSensorSimulatorTests
{
    [Fact]
    public void GenerateReading_TemperatureShouldBeWithinExpectedRange()
    {
        //Arrange  //object
        var simulator = new EnvironmentalSensorSimulator();

        //Act
        var reading = simulator.GenerateReading();

        //Assert
        Assert.InRange(reading.Temperature, 20,30);
    }

    [Fact]
    public void GenerateReading_PressureShouldBeWithinExpectedRange()
    {
        //Arrange
        var simulator = new EnvironmentalSensorSimulator();

        //Act
        var reading = simulator.GenerateReading();

        //Assert
        Assert.InRange(reading.Pressure, 980, 1130);
    }

    [Fact]
    public void GenerateReading_HumidityShouldBeWithinExpectedRange()
    {
        //Assert
        var simulator = new EnvironmentalSensorSimulator();

        //Act
        var reading = simulator.GenerateReading();

        //Assert
        Assert.InRange(reading.Humidity, 30, 70);
    }

    [Fact]
    public void GenerateReading_SensorIdShouldBeDefault()
    {
        //Arrange
        var simulator = new EnvironmentalSensorSimulator();

        //Act
        var reading = simulator.GenerateReading();

        //Assert
        Assert.Equal("ENV-001", reading.SensorId);

    }

    [Fact]
    public void GenerateReading_MultipleTimes()
    {
        //Arrange
        var simulator = new EnvironmentalSensorSimulator();

        //Act
        for (int i = 0; i < 10; i++)
        {
            var reading = simulator.GenerateReading();
        }


    }
}