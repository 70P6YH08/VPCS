using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaLabWork9.Models
{
    public record InventoryReservedEvent(
        int OrderId,
        DateTime ReservedAt
    );
}
