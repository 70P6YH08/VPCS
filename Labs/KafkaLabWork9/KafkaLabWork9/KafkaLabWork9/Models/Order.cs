using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaLabWork9.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDelivered { get; set; }
    }
}
