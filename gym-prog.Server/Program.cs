using gym_prog.Data.Data;
using gym_prog.Logic.Services.Implementations;
using gym_prog.Logic.Services.Interfaces;
using gym_prog.ML.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database
builder.Services.AddDbContext<GymContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GymContext")));
#endregion

#region Servies
builder.Services.AddTransient<IWorkoutService, WorkoutService>();

var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "GymProgressionModel.zip");
builder.Services.AddSingleton<DataPreparationService>();
builder.Services.AddSingleton(new ModelTrainerService(modelPath));
builder.Services.AddSingleton(new PredictionService(modelPath));
#endregion

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
