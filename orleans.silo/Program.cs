using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using orleans.grains;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering(
            siloPort: 11111,
    gatewayPort: 30000
)
            .Configure<ClusterOptions>(opt =>
            {
                opt.ClusterId = "dev";
                opt.ServiceId = "OrleansApp";
            });
        
        silo.UseTransactions();
    })
    .RunConsoleAsync();
