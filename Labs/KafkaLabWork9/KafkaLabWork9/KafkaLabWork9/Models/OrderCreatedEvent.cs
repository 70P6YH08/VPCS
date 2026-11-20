using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaLabWork9.Models
{
    public record OrderCreatedEvent(
        int Id,
        string Title,
        int Price,
        DateTime CreatedDate,
        bool IsDelivered
    );
}
