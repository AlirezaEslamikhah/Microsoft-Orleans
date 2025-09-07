
using Orleans.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Orleans Client
builder.Host.UseOrleansClient(client =>
{
    client.UseLocalhostClustering(gatewayPort: 30000)
          .Configure<ClusterOptions>(opt =>
          {
              opt.ClusterId = "dev";
              opt.ServiceId = "OrleansApp";
          });
    
    client.UseTransactions();

});





// Add services to the container.

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
