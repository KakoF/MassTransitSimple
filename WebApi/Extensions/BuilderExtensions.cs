
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


					#region Direct Event
					cfg.Send<UserDirectEvent>(x =>
					{
						x.UseRoutingKeyFormatter(context => context.Message.Type.Name);
					});
					cfg.Message<UserDirectEvent>(x => x.SetEntityName("user_direct_event"));
					cfg.Publish<UserDirectEvent>(x =>
					{
						x.Durable = true; // default: true
						x.AutoDelete = false; // default: false
						x.ExchangeType = ExchangeType.Direct; // default, allows any valid exchange type
						
					});
					#endregion Direct Event

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
