using Core.Events;
using MassTransit;

namespace WorkerService.Workers
{
	public class UserHeadersEventConsumer : IConsumer<UserHeadersEvent>
	{
		private readonly ILogger<UserHeadersEventConsumer> _logger;

		public UserHeadersEventConsumer(ILogger<UserHeadersEventConsumer> logger)
		{
			_logger = logger;
		}
		public Task Consume(ConsumeContext<UserHeadersEvent> context)
		{
			_logger.LogInformation($"User message receive: {context.Message.Name}");
			return Task.CompletedTask;
		}
	}
}
