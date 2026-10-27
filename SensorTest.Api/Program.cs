using SensorTest.Core.Simulators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var simulator = new EnvironmentalSensorSimulator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/sensor/environment", () =>
{
    var reading = simulator.GenerateReading();
    return reading;
})
.WithName("GetEnvironmentalReading")
.WithOpenApi();

app.Run();


