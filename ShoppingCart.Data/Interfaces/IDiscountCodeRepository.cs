using ShoppingCart.Domain;

namespace ShoppingCart.Data.Interfaces
{
    public interface IDiscountCodeRepository
    {
        DiscountCode GetByCode(string code);
    }
}