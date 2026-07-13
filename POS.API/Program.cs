using POS.DATABASE;
using POS.DOMAIN.Features.Menu;
using POS.DOMAIN.Features.MenuCategory;
using POS.DOMAIN.Features.MenuCategory.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllMenuCagHandler).Assembly));
builder.Services.AddSingleton<DbconnectionFactory>();
builder.Services.AddScoped<IMenuCag , MenuCagService>();
builder.Services.AddScoped<IMenu , MenuService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
