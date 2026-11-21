using Confluent.Kafka;
using KafkaLabWork9.Models;
using KafkaLabWork9.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace KafkaLabWork9
{
    public class OrderEventConsumer : BackgroundService
    {
        private readonly OrderStore _store;
        private readonly string _bootstrapServers;
        private readonly string _groupId = "order-service-group";

        public OrderEventConsumer(OrderStore store, string bootstrapServers)
        {
            _store = store;
            _bootstrapServers = bootstrapServers;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = _groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };

            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(new[] { "payment.completed", "payment.failed", "inventory.reserved" });

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(stoppingToken);
                    if (consumeResult?.Message == null) continue;

                    ProcessEvent(consumeResult.Message.Topic, consumeResult.Message.Value);
                    consumer.Commit(consumeResult);
                }
                catch (ConsumeException ex)
                {
                    Console.WriteLine($"Consume error: {ex.Error.Reason}");
                }
            }
        }

        private void ProcessEvent(string topic, string value)
        {
            try
            {
                switch (topic)
                {
                    case "payment.completed":
                        var paymentComp = JsonSerializer.Deserialize<PaymentCompletedEvent>(value);
                        if (paymentComp != null)
                            _store.TryUpdate(paymentComp.OrderId, "Paid", null);
                        break;
                    case "payment.failed":
                        var paymentFail = JsonSerializer.Deserialize<PaymentFailedEvent>(value);
                        if (paymentFail != null)
                            _store.TryUpdate(paymentFail.OrderId, "PaymentFailed", paymentFail.FailureReason);
                        break;
                    case "inventory.reserved":
                        var invRes = JsonSerializer.Deserialize<InventoryReservedEvent>(value);
                        if (invRes != null)
                            _store.TryUpdate(invRes.OrderId, "InventoryReserved", null);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing event from {topic}: {ex.Message}");
            }
        }
    }
}
