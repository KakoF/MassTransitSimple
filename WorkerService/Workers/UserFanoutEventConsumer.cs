using Core.Events;
using MassTransit;

namespace WorkerService.Workers
{
	public class UserFanoutEventConsumer : IConsumer<UserFanoutEvent>
	{
		private readonly ILogger<UserFanoutEventConsumer> _logger;

		public UserFanoutEventConsumer(ILogger<UserFanoutEventConsumer> logger)
		{
			_logger = logger;
		}
		public Task Consume(ConsumeContext<UserFanoutEvent> context)
		{
			_logger.LogInformation($"User message receive: {context.Message.Name}");
			return Task.CompletedTask;
		}
	}
}
