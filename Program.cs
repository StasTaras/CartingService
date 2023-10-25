using Asp.Versioning;
using CartingService.BusinessLogic;
using CartingService.DAL;
using CartingService.Utils.Swagger;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICartRepository, CartRepository>(_ => new CartRepository(Path.Combine(builder.Environment.ContentRootPath, "CartDB-v1.db")));
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(SwaggerOptions.GetSwaggerGenOptions(builder.Services));
builder.Services
    .AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1.0);
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
    });

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection(); 
//app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(
    options =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });

app.MapControllers();

app.Run();
