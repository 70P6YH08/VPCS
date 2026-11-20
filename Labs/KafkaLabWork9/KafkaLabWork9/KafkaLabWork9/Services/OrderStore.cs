using Confluent.Kafka;
using Confluent.Kafka.Admin;
using KafkaLabWork9.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json;

namespace KafkaLabWork9.Services
{
    public class OrderStore
    {
        private readonly ConcurrentDictionary<int, Order> _orders = new();
        public async Task CreateOrderAsync(Order order)
        {
            _orders[_orders.Count() + 1] = new Order
            {
                Id = order.Id,
                Title = $"Заказ {order.Id}",
                Price = order.Price * 100,
                CreatedDate = order.CreatedDate,
                IsDelivered = Random.Shared.Next(2) == 0
            };
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            var randomData = Random.Shared.Next(0, 100);

            return _orders.TryGetValue(orderId, out Order order) ? order : null;
        }

        public async Task<bool> UpdateOrderAsync(int id, bool newStatus, string? reason)
        {
            if (_orders.TryGetValue(id, out Order order))
                return false;

            _orders[id].IsDelivered = newStatus;
            return true;
        }

        public async Task CancelOrderAsync(int id, string? reason)
        {
            if (_orders.TryGetValue(id, out Order order))
            {
                _orders[id].IsDelivered = false;
                _orders[id].Price = 0;
                _orders[id].Title = "Cancelled";
            }
        }
    }
}
