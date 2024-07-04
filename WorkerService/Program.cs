using WorkerService.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransitRabbitMq(builder.Configuration);

var host = builder.Build();
host.Run();
