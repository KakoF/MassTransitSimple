using MassTransit;
using WorkerService.Workers;
namespace WorkerService.Extensions
{
	public static class BuilderExtensions
	{
		public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMassTransit(busConfigurator =>
			{
				busConfigurator.SetKebabCaseEndpointNameFormatter();
				busConfigurator.AddConsumer<UserEventConsumer>();
				busConfigurator.UsingRabbitMq((ctx, cfg) =>
				{
					cfg.Host(configuration.GetConnectionString("RabbitMq"));
					cfg.ConfigureEndpoints(ctx);
					cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });
				});

			});
		}
	}
}