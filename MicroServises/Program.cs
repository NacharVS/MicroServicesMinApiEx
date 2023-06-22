using MicroServises.UserService.Infrastructure;
using MicroServises.UserService.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseStatusCodePages( async statusContext =>
{
    var response = statusContext.HttpContext.Response;
    var path = statusContext.HttpContext.Request.Path;

    if(response.StatusCode == 403)
    {
        await response.WriteAsync(path);
    }
    else
        await response.WriteAsync("Not found");
});
//app.Environment.EnvironmentName = "Production";





if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
}

app.Map("/error", app => app.Run(async (context) =>
{
    context.Response.StatusCode = 500;
    await context.Response.WriteAsync("opps! Something wrong!");
})); 

app.MapGet("/", () => "Hello");

app.MapGet("/getUser/{login}", (string login) => MongoDBContext.GetByName(login));

app.MapPost("/sendUser", (User user) => {
    MongoDBContext.Add(user);
    
    });

app.Run();
