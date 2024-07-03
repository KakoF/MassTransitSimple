using Core.Interfaces.Publishers;
using MassTransit;


namespace BusWrapper.Publishers
{
	public class PublishSchedulerWrapper : IPublishSchedulerWrapper
	{
		private readonly IMessageScheduler _bus;
		public PublishSchedulerWrapper(IMessageScheduler bus)
		{
			_bus = bus;
		}
		public async Task PublishSchedulerAsync<T>(T user)
		{
			await _bus.SchedulePublish(DateTime.UtcNow + TimeSpan.FromSeconds(10), user!);
		}
	}
}
