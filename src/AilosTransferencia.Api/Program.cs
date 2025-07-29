using AilosTransferencia.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseConfiguration();

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddJwtConfiguration();

var app = builder.Build();

app.AddMigrationsConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
