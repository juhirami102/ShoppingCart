using ShoppingCart.Data.Interfaces;
using ShoppingCart.Domain;
using ShoppingCart.Service.Interfaces;

namespace ShoppingCart.Service
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly IDiscountCodeRepository _discountCodeRepository;

        public DiscountCodeService(IDiscountCodeRepository discountCodeRepository)
        {
            _discountCodeRepository = discountCodeRepository;
        }

        public DiscountCode GetByCode(string code)
        {
            return _discountCodeRepository.GetByCode(code);
        }
    }
}