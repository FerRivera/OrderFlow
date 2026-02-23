namespace OrderFlow.Orders.Domain
{
    public enum Operation
    {
        Buy,
        Sell
    }

    public enum OrderStatus
    {
        PendingPayment,
        Approved,
        Rejected
    }
}
