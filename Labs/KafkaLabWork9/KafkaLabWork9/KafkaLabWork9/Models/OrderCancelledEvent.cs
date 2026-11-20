using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaLabWork9.Models
{
    public record OrderCancelledEvent(
        int Id,
        string Reason,
        DateTime CancelledDate
    );
}
