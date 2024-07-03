using Core.Events;
using MassTransit;

namespace WorkerService.Workers
{
	public class UserEventConsumer : IConsumer<UserEvent>
	{
		private readonly ILogger<UserEventConsumer> _logger;

		public UserEventConsumer(ILogger<UserEventConsumer> logger)
		{
			_logger = logger;
		}
		public Task Consume(ConsumeContext<UserEvent> context)
		{
			_logger.LogInformation($"User message receive: {context.Message.Name}");
			return Task.CompletedTask;
		}
	}
}
