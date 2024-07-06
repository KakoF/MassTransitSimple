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
				//busConfigurator.AddConsumer<UserDirectEventConsumer>();
				//busConfigurator.AddConsumer<UserHeadersEventConsumer>();
				busConfigurator.UsingRabbitMq((ctx, cfg) =>
				{
					cfg.Host(configuration.GetConnectionString("RabbitMq"));
					cfg.ConfigureEndpoints(ctx, new SnakeCaseEndpointNameFormatter(false));
					cfg.UseMessageRetry(retry => { retry.Interval(3, TimeSpan.FromSeconds(5)); });


					/*cfg.ReceiveEndpoint("user_fanout_event", x =>
					{
						//x.Consumer<UserFanoutEventConsumer>(ctx);
						x.Bind("Core.Events:UserFanoutEvent", s =>
						{
							s.ExchangeType = ExchangeType.Fanout;
						});
					});*/


					cfg.ReceiveEndpoint("user_direct_event_default", x =>
					{
						x.ConfigureConsumeTopology = false;

						x.Consumer<UserDirectEventConsumer>(ctx);

						x.Bind("user_direct_event", s =>
						{
							s.RoutingKey = "Default";
							s.ExchangeType = ExchangeType.Direct;
						});
					});

					cfg.ReceiveEndpoint("user_direct_event_admin", x =>
					{
						x.ConfigureConsumeTopology = false;

						x.Consumer<UserDirectEventConsumer>(ctx);

						x.Bind("user_direct_event", s =>
						{
							s.RoutingKey = "Admin";
							s.ExchangeType = ExchangeType.Direct;
						});
					});
					/*cfg.ReceiveEndpoint("guest", x =>
					{
						x.ConfigureConsumeTopology = false;

						x.Consumer<UserDirectEventConsumer>(ctx);

						x.Bind("user_direct_event", s =>
						{
							s.RoutingKey = "guest";
							s.ExchangeType = ExchangeType.Direct;
						});
					});

					cfg.ReceiveEndpoint("admin", x =>
					{
						x.ConfigureConsumeTopology = false;

						x.Consumer<UserDirectEventConsumer>(ctx);

						x.Bind("user_direct_event", s =>
						{
							s.RoutingKey = "admin";
							s.ExchangeType = ExchangeType.Direct;
						});
					});*/
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