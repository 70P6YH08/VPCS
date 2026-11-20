using Confluent.Kafka;
using KafkaLabWork9.Models;
using System.Text.Json;

namespace KafkaLabWork9
{
    public class OrderService
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _createdTopic = "order.created";
        private readonly string _cancelledTopic = "order.cancelled";
        public OrderService()
        {
            var confing = new ProducerConfig()
            {
                BootstrapServers = "10.9.2.80:9092"
            };
            _producer = new ProducerBuilder<string, string>(confing).Build();

            //Task.Run(async () => await ExecuteAsync());
        }

        public async Task PublishOrderCreatedAsync(OrderCreatedEvent evt)
        {
            await PublishAsync(_createdTopic, evt.Id.ToString(), evt);
        }

        public async Task PublishOrderCancelledAsync(OrderCancelledEvent evt)
        {
            await PublishAsync(_cancelledTopic, evt.Id.ToString(), evt);
        }

        private async Task PublishAsync<T>(string topic, string key, T evt)
        {
            var json = JsonSerializer.Serialize(evt);
            var msg = new Message<string, string> { Key = key, Value = json };
            var dr = await _producer.ProduceAsync(topic, msg);
            Console.WriteLine($"[PRODUCER] Published to {topic}, offset: {dr.TopicPartitionOffset}");
        }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    _logger.LogInformation("Order service started.");



        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        try
        //        {
        //            var 
        //        }
        //        catch (OperationCanceledException)
        //        {
        //            _logger.LogInformation("Worker cancellation requested.");
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogInformation(ex, "Unexpected error while producing message.");
        //        }

        //        _logger.LogInformation("Worker stopped gracefully.");
        //    }
        //}
    }
}
