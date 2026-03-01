using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Operation Operation { get; set; }
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }

        public static Order Create(Guid userId, Operation operation, decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount must be greater than 0.");

            return new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Operation = operation,
                Amount = amount,
                Status = OrderStatus.PendingPayment,
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = null
            };
        }
    }
}
