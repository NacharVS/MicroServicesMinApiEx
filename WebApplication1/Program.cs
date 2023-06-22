using MicroServices.ClientService.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var conection = builder.Configuration.GetConnectionString("ClientDataBase");
//builder.Services.AddDbContext<ClientDbContext>(opt => opt.UseSqlServer( ));



app.Run();
