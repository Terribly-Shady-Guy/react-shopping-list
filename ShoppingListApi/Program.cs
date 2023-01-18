using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string clientCorsPolicyName = "shoppingListClientPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(clientCorsPolicyName, policy =>
    {
        policy.WithOrigins("https://localhost:3000");
        policy.WithHeaders("content-type");
        policy.AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShoppingListApi.Data.ShoppingListContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingList"));
});

builder.Services.AddTransient<IShoppingListItemRepository, ShoppingListItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(clientCorsPolicyName);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
