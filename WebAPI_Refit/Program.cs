
using Refit;
using WebAPI_Refit.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var baseCorreiosUrl = builder.Configuration["CorreiosURL"].ToString();

builder
    .Services
    .AddRefitClient<ICorreiosCEP>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseCorreiosUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

