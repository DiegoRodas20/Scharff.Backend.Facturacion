﻿using MediatR;
using Npgsql;
using Scharff.API.Utils.GlobalHandlers;
using Scharff.Infrastructure.Queries.Client.GetAllClients;
using Scharff.Infrastructure.Queries.Client.GetClientById;
using Scharff.Infrastructure.Queries.Contact.GetContactById;
using Scharff.Infrastructure.Queries.Direction.GetDirectionById;
using Scharff.Infrastructure.Repositories.Client.RegisterClient;
using Scharff.Infrastructure.Repositories.Client.UpdateClient;
using Scharff.Infrastructure.Repositories.Contact.DeleteContact;
using Scharff.Infrastructure.Repositories.Contact.DeleteEmailContact;
using Scharff.Infrastructure.Repositories.Contact.DeletePhoneContact;
using Scharff.Infrastructure.Repositories.Contact.RegisterContact;
using Scharff.Infrastructure.Repositories.Contact.RegisterEmailContact;
using Scharff.Infrastructure.Repositories.Contact.RegisterPhoneContact;
using Scharff.Infrastructure.Repositories.Contact.UpdateContact;
using Scharff.Infrastructure.Repositories.Contact.UpdateEmailContact;
using Scharff.Infrastructure.Repositories.Contact.UpdatePhoneContact;
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
builder.Services.AddTransient(typeof(IGetClientByIdQuery), typeof(GetClientByIdQuery));
builder.Services.AddTransient(typeof(IRegisterClientRepository), typeof(RegisterClientRepository));
builder.Services.AddTransient(typeof(IUpdateClientRepository), typeof(UpdateClientRepository));
builder.Services.AddTransient(typeof(IGetAllClients), typeof(GetAllClients));

builder.Services.AddTransient(typeof(IGetContactByIdClientQuery), typeof(GetContactByIdClientQuery));
builder.Services.AddTransient(typeof(IGetContactByIdQuery), typeof(GetContactByIdQuery));

builder.Services.AddTransient(typeof(IRegisterContactRepository), typeof(RegisterContactRepository));
builder.Services.AddTransient(typeof(IRegisterPhoneContactRepository), typeof(RegisterPhoneContactRepository));
builder.Services.AddTransient(typeof(IRegisterEmailContactRepository), typeof(RegisterEmailContactRepository));


builder.Services.AddTransient(typeof(IUpdateContactRepository), typeof(UpdateContactRepository));
builder.Services.AddTransient(typeof(IUpdatePhoneContactRepository), typeof(UpdatePhoneContactRepository));
builder.Services.AddTransient(typeof(IUpdateEmailContactRepository), typeof(UpdateEmailContactRepository));


builder.Services.AddTransient(typeof(IDeleteContactRepository), typeof(DeleteContactRepository));
builder.Services.AddTransient(typeof(IDeletePhoneContactRepository), typeof(DeletePhoneContactRepository));
builder.Services.AddTransient(typeof(IDeleteEmailContactRepository), typeof(DeleteEmailContactRepository));


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
app.UseMiddleware<GlobalErrorHandler>();

app.Run();

