using SensorTest.Core.Simulators;
using SensorTest.Core.Services;
using SensorTest.Core.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SensorReadingStore>();

var simulator = new EnvironmentalSensorSimulator();
var alarmService = new AlarmService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint 1: get sensor reading
app.MapGet("/sensor/environment", (SensorReadingStore store) =>
{
    var reading = simulator.GenerateReading();
    store.Save(reading);
    return reading;
})
.WithName("GetEnvironmentalReading")
.WithOpenApi();

// Endpoint 2: return temperature alarm result
app.MapGet("/sensor/alarms", (double threshold, SensorReadingStore store) =>
{
    var reading = store.LatestReading;
    if (reading == null)
    { 
        return Results.NotFound("No sensor reading available.");
    }

    var result = alarmService.CheckTemperature(reading, threshold);

    return Results.Ok(result);

});

app.Run();


