using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaLabWork9.Models
{
    public record PaymentCompletedEvent(
        int OrderId,
        decimal PaidAmount,
        DateTime PaidAt
    );
}
