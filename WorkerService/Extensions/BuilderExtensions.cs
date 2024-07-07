using MassTransit;
using RabbitMQ.Client;

using WorkerService.Workers;
namespace WorkerService.Extensions
{
	public static class BuilderExtensions
	{
		public static void AddMassTransitRabbitMq(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMassTransit(busConfigurator =>
			{
				busConfigurator.SetSnakeCaseEndpointNameFormatter();
				busConfigurator.AddConsumer<UserFanoutEventConsumer>();
				//busConfigurator.AddConsumer<UserTopicEventConsumer>();
				busConfigurator.AddConsumer<UserDirectEventConsumer>();
				//busConfigurator.AddConsumer<UserHeadersEventConsumer>();
				busConfigurator.UsingRabbitMq((ctx, cfg) =>
				{
					cfg.Host(configuration.GetConnectionString("RabbitMq"));
					cfg.ConfigureEndpoints(ctx, new SnakeCaseEndpointNameFormatter(false));
					cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });

					#region Direct Event

					cfg.ReceiveEndpoint("user_direct_event_default", x =>
					{
						x.ConfigureConsumeTopology = false;
						x.Bind("user_direct_event", s =>
						{
							s.ExchangeType = ExchangeType.Direct;
							s.RoutingKey = "Default";
						});
						x.Consumer<UserDirectEventConsumer>(ctx);
					});

					cfg.ReceiveEndpoint("user_direct_event_admin", x =>
					{
						x.ConfigureConsumeTopology = false;
						x.Bind("user_direct_event", s =>
						{
							s.RoutingKey = "Admin";
							s.ExchangeType = ExchangeType.Direct;
						});
						x.Consumer<UserDirectEventConsumer>(ctx);
					});
					#endregion Direct Event

				});

			});

		}
		public static void AddMassTransitKafka(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMassTransit(busConfigurator =>
			{
				busConfigurator.SetSnakeCaseEndpointNameFormatter();
				busConfigurator.AddConsumer<UserFanoutEventConsumer>();
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