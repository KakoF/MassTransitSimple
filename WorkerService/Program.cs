using WorkerService;
using WorkerService.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(builder.Configuration);

var host = builder.Build();
host.Run();
