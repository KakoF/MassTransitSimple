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
        public async Task PublishAsync<T>(T user)
		{
			await _bus.Publish(user!);
		}
	}
}
