using BookStore.DbOperations;
using BookStore.MiddleWares;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BookStoreContext>(x => x.UseInMemoryDatabase(databaseName: "BookStoreDb")); // Db context added to the configuraiton files
builder.Services.AddScoped<IBookStoreContext>(provider => provider.GetService<BookStoreContext>());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    DataGenerator.Initialize(service);
} // Data were added to the inmemory database as default parameter

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

// Middle Wares must be written after UseAuthorization before MapControllers

app.UsecustomExceptionMiddle();



app.MapControllers(); // It works lastly

app.Run();
