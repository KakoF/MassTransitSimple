
using Core.Events;
using MassTransit;
using RabbitMQ.Client;
namespace WebApi.Extensions
{
	public static class BuilderExtensions
	{
		public static void AddMassTransitRabbitMq(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMassTransit(busConfigurator =>
			{
				busConfigurator.SetSnakeCaseEndpointNameFormatter();
				busConfigurator.AddDelayedMessageScheduler();
				busConfigurator.UsingRabbitMq((ctx, cfg) =>
				{
					cfg.Host(configuration.GetConnectionString("RabbitMq"));
					cfg.UseDelayedMessageScheduler();
					cfg.ConfigureEndpoints(ctx, new SnakeCaseEndpointNameFormatter(false));
					cfg.ConfigureEndpoints(ctx);

					cfg.Publish<UserDirectEvent>(x =>
					{
						x.Durable = true; // default: true
						x.AutoDelete = false; // default: false
						x.ExchangeType = ExchangeType.Direct; // default, allows any valid exchange type
						cfg.Send<UserDirectEvent>(x =>
						{
							// use customerType for the routing key
							x.UseRoutingKeyFormatter(context => nameof(context.Message.Type));
							// multiple conventions can be set, in this case also CorrelationId
							// x.UseCorrelationId(context => context.Message.TransactionId);
						});

					});

					cfg.Publish<UserTopicEvent>(x =>
					{
						x.Durable = true; // default: true
						x.AutoDelete = false; // default: false
						x.ExchangeType = ExchangeType.Topic; // default, allows any valid exchange type

					});
					
					cfg.Publish<UserHeadersEvent>(x =>
					{
						x.Durable = true; // default: true
						x.AutoDelete = false; // default: false
						x.ExchangeType = ExchangeType.Headers; // default, allows any valid exchange type
					});

				});

			});
		}

		public static void AddMassTransitKafka(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMassTransit(busConfig => { 
			
			
			});
		}
	}
}
