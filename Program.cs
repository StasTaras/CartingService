using CartingService.BusinessLogic;
using CartingService.DAL;
using CartingService.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICartRepository, CartRepository>(_ => new CartRepository(Path.Combine(builder.Environment.ContentRootPath, "CartDB-v1.db")));
builder.Services.AddSingleton<ICartService, CartService>();
//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddControllers();
    //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCartItemRequestValidator>());
//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

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