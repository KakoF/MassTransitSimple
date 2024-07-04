using Core.Interfaces.Publishers;
using MassTransit;


namespace BusWrapper.Publishers
{
	public class PublishEndpointWrapper : IPublishEndpointWrapper
	{
		private readonly IPublishEndpoint _bus;
        public PublishEndpointWrapper(IPublishEndpoint bus)
        {
			_bus = bus;
        }
        public async Task PublishFanoutAsync<T>(T user)
		{
			await _bus.Publish(user!);
		}

		public async Task PublishDirectAsync<T>(T user)
		{
			await _bus.Publish(user!);
		}

		public async Task PublishHeadersAsync<T>(T user)
		{
			await _bus.Publish(user!);
		}

		public async Task PublishTopicAsync<T>(T user)
		{
			await _bus.Publish(user!);
		}
	}
}
