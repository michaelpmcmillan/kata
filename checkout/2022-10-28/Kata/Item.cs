namespace Kata
{
    public record Item(
        string Sku,
        int FullPrice,
        int? DiscountQty,
        int? DiscountPrice
    );
}
