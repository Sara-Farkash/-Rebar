using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rebar.Models;
using Rebar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RebarStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(RebarStoreDatabaseSettings)));
builder.Services.AddSingleton<IRebarStoreDatabaseSettings>(sp=>
sp.GetRequiredService<IOptions<RebarStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>(
  "RebarStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IMenuService,MenuService>();
builder.Services.AddScoped<IDatabaseOfBranchService,DatabaseOfBranchService>();



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
