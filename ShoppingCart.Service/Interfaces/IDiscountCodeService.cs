using ShoppingCart.Domain;

namespace ShoppingCart.Service.Interfaces
{
    public interface IDiscountCodeService
    {
        DiscountCode GetByCode(string code);
    }
}