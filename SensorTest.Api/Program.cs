using SensorTest.Core.Simulators;
using SensorTest.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapGet("/sensor/environment", () =>
{
    var reading = simulator.GenerateReading();
    return reading;
})
.WithName("GetEnvironmentalReading")
.WithOpenApi();

// Endpoint 2: return temperature alarm result
app.MapGet("/sensor/alarms", (double threshold) =>
{
    var reading = simulator.GenerateReading();

    var result = alarmService.CheckTemperature(reading, threshold);

    return Results.Ok(result);

});

app.Run();


