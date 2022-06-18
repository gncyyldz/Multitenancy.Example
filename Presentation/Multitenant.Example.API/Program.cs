using Multitenant.Example.Application.Settings;
using Multitenant.Example.Infrastructure;
using Multitenant.Example.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection("TenantSettings"));
builder.Services.AddInfrastructureService();
await builder.Services.AddPersistenceService();


builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
