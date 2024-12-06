namespace Ordering.Domain.ValueObjects;

public record OrderItemId
{
    public Guid Value { get;}
    private OrderItemId(Guid value) => Value = new Guid();

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new OrderItemId(value);
    }
};