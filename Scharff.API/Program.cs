using MediatR;
using Npgsql;
using Scharff.Infrastructure.Queries.Client.GetAllClients;
using Scharff.Infrastructure.Queries.Client.GetClientById;
using Scharff.Infrastructure.Repositories.Client.RegisterClient;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbConnection>(x => new NpgsqlConnection(builder.Configuration.GetConnectionString("Scharff_BD")));

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", p =>
        {
            p.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    });
builder.Services.AddTransient(typeof(IGetClientById), typeof(GetClientById));
builder.Services.AddTransient(typeof(IRegisterClientRepository), typeof(RegisterClientRepository));
builder.Services.AddTransient(typeof(IGetAllClients), typeof(GetAllClients));

Assembly application = AppDomain.CurrentDomain.Load("Scharff.Application");
builder.Services.AddMediatR(application);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

