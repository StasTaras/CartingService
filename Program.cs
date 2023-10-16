using CartingService.BusinessLogic;
using CartingService.DAL;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICartRepository, CartRepository>(_ => new CartRepository(Path.Combine(builder.Environment.ContentRootPath, "CartDB-v1.db")));
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); 
app.UseAuthorization();
app.MapControllers();

app.Run();