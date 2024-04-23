using DeliVeggie.Application.Abstracts;
using DeliVeggie.Application.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(setupAction =>
{
    setupAction.AddPolicy("DeliVeggieCORS", configurePolicy =>
    {
        configurePolicy.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();

var app = builder.Build();


// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("DeliVeggieCORS");

app.MapControllers();

app.Run();
