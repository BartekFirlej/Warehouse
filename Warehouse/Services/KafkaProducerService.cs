using Confluent.Kafka;
using Warehouse.DTOs;

namespace Warehouse.Services
{
    public interface IKafkaProducerService
    {
        public Task ProduceCustomerProduct(string topic, string customerWithAddress);
    }
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerService(ProducerConfig config)
        {
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceCustomerProduct(string topic, string customerWithAddress)
        {
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = customerWithAddress });
        }
    }
}
