using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaLabWork9.Models
{
    public record PaymentFailedEvent(
        int OrderId,
        string FailureReason,
        DateTime FailedAt
    );
}
