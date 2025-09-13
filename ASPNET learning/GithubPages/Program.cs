using Microsoft.VisualBasic;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//beyond here is where we can map gets and posts
//for now, lets design a get and post for infgormation, and what info is needed.

//we can also design a resource for all the relevent skills i have used!

//we should use app.use to inject middlware (basically to see if the source has an API key or something
//do it above the  resources

app.Run();
