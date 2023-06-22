using MicroServises.UserService.Infrastructure;
using MicroServises.UserService.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var app = builder.Build();

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
app.Run(async (context) =>
{
    int[]qq = new int[10];
    for (int i = 0; i < 20; i++)
    {
        qq[i] = 1;
    }
});
app.Run();
