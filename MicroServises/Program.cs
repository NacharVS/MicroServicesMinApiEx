using MicroServises.UserService;
using MicroServises.UserService.Infrastructure;
using MicroServises.UserService.Models;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSession();

//app.Environment.EnvironmentName = "Production";
//app.UseMiddleware<CustomMiddleware>("");




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
}

app.Map("/error/{statusCode}", (int statusCode) => $"Error. Status Code:{statusCode}");


//app.Map("/error", app => app.Run(async (context) =>
//{
//    context.Response.StatusCode = 500;
//    await context.Response.WriteAsync("opps! Something wrong!");
//})); 

//app.MapGet("/", () => "Hello");

app.MapGet("/getUser/{login}", (string login) => MongoDBContext.GetByName(login));

app.MapPost("/sendUser", (User user) => {
    MongoDBContext.Add(user);
    
    });

app.Run(async (context) =>
{
    if (context.Session.Keys.Contains("user"))
    {
        User user = context.Session.Get<User>("user");
        await context.Response.WriteAsync($"Hi {user.Name}");
    }
    else
    {
        context.Response.Cookies.Append("name", "Bob");
        await context.Response.WriteAsync("hello");
    }
   

});

app.Run();

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}