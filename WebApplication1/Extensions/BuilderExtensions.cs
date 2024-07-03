
using MassTransit;
namespace WebApi.Extensions
{
	public static class BuilderExtensions
	{
		public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMassTransit(busConfigurator =>
			{
				busConfigurator.SetKebabCaseEndpointNameFormatter();
				busConfigurator.AddDelayedMessageScheduler();
				busConfigurator.UsingRabbitMq((ctx, cfg) =>
				{
					cfg.Host(configuration.GetConnectionString("RabbitMq"));
					cfg.UseDelayedMessageScheduler();
					cfg.ConfigureEndpoints(ctx);
				});

			});
		}
	}
}
