using Core.Events;
using MassTransit;

namespace WorkerService.Workers
{
	public class UserTopicEventConsumer : IConsumer<UserTopicEvent>
	{
		private readonly ILogger<UserTopicEventConsumer> _logger;

		public UserTopicEventConsumer(ILogger<UserTopicEventConsumer> logger)
		{
			_logger = logger;
		}
		public Task Consume(ConsumeContext<UserTopicEvent> context)
		{
			_logger.LogInformation($"User message receive: {context.Message.Name}");
			return Task.CompletedTask;
		}
	}
}
