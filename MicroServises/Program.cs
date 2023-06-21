using MicroServises.UserService.Infrastructure;
using MicroServises.UserService.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/", () => "Hello");
app.MapGet("/getUser/{login}", (string login) => MongoDBContext.GetByName(login));
app.MapPost("/sendUser", (User user) => MongoDBContext.Add(user));
app.Run();
