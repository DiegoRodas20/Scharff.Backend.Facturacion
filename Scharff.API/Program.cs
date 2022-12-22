using MediatR;
using Npgsql;
using Scharff.Infrastructure.Queries.Client.GetAllClients;
using Scharff.Infrastructure.Queries.Client.GetClientById;
using Scharff.Infrastructure.Queries.Contact.GetContactById;
using Scharff.Infrastructure.Queries.Direction.GetDirectionById;
using Scharff.Infrastructure.Repositories.Client.RegisterClient;
using Scharff.Infrastructure.Repositories.Contact.DeleteContact;
using Scharff.Infrastructure.Repositories.Contact.RegisterContact;
using Scharff.Infrastructure.Repositories.Contact.UpdateContact;
using Scharff.Infrastructure.Repositories.Direction.DeleteDirection;
using Scharff.Infrastructure.Repositories.Direction.RegisterDirection;
using Scharff.Infrastructure.Repositories.Direction.UpdateDirection;
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

builder.Services.AddTransient(typeof(IGetContactById), typeof(GetContactById));
builder.Services.AddTransient(typeof(IRegisterContactRepository), typeof(RegisterContactRepository));

builder.Services.AddTransient(typeof(IUpdateContactRepository), typeof(UpdateContactRepository));
builder.Services.AddTransient(typeof(IDeleteContactRepository), typeof(DeleteContactRepository));

builder.Services.AddTransient(typeof(IGetDirectionById), typeof(GetDirectionById));
builder.Services.AddTransient(typeof(IRegisterDirectionRepository), typeof(RegisterDirectionRepository));

builder.Services.AddTransient(typeof(IUpdateDirectionRepository), typeof(UpdateDirectionRepository));
builder.Services.AddTransient(typeof(IDeleteDirectionRepository), typeof(DeleteDirectionRepository));


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

