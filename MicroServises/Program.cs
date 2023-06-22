using MicroServises.UserService;
using MicroServises.UserService.Infrastructure;
using MicroServises.UserService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSession();

//app.Environment.EnvironmentName = "Production";
//app.UseMiddleware<CustomMiddleware>("");

var options = new RewriteOptions().AddRedirect("home[/]?$", "home/index" );
app.UseRewriter(options);

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

app.MapGet("/home", () => "Hello");
app.MapGet("/home/index", () => "Hello");

app.MapGet("/getUser/{login}", (string login) => MongoDBContext.GetByName(login));

app.MapPost("/sendUser", (User user) => {
    MongoDBContext.Add(user);
    
    });

//app.Run(async (context) =>
//{
//    if (context.Session.Keys.Contains("user"))
//    {
//        UserS user = context.Session.Get<UserS>("user");
//        await context.Response.WriteAsync($"Hi {user.Name}");
//    }
//    else
//    {
//        UserS user = new UserS() { Id = 1, Name = "Bob" };
//        context.Session.Set<UserS>("user", user);
//        await context.Response.WriteAsync("hello");
//    }
   

//});

app.Run();

class UserS
{
    public int Id { get; set; }
    public string Name { get; set; }
}