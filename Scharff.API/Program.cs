using MediatR;
using Npgsql;
using Scharff.Infrastructure.Queries.Client.GetClientById;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbConnection>(x => new NpgsqlConnection(builder.Configuration.GetConnectionString("Scharff_BD")));

builder.Services.AddTransient(typeof(IGetClientById), typeof(GetClientById));
Assembly application = AppDomain.CurrentDomain.Load("Scharff.Application");
builder.Services.AddMediatR(application);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

