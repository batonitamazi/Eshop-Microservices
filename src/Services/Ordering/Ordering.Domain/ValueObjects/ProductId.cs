namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    public Guid Value { get;}
    
    private ProductId(Guid value) => Value = value;

    public static ProductId Of(ProductId productId)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (productId.Value == Guid.Empty)
        {
            throw new ArgumentException("Product id is invalid", nameof(productId));
        }

        return new ProductId(productId.Value);
    }
};