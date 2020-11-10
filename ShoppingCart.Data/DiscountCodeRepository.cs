using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Domain;

namespace ShoppingCart.Data
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly List<DiscountCode> _discountCodes;

        public DiscountCodeRepository()
        {
            _discountCodes = new List<DiscountCode>
            {
                new DiscountCode
                {
                    Id = 1,
                    Code = "ABC123",
                    Value = 5m,
                    Expiry = new DateTime(2019, 11, 18, 23, 59, 00),
                    IsUsed = false
                },
                new DiscountCode
                {
                    Id = 2,
                    Code = "ZZZ555",
                    Value = 5m,
                    Expiry = new DateTime(2070, 11, 18, 23, 59, 00),
                    IsUsed = true
                },
                new DiscountCode
                {
                    Id = 3,
                    Code = "A1B2C3",
                    Value = 2.5m,
                    Expiry = new DateTime(2030, 11, 18, 23, 59, 00),
                    IsUsed = false
                }
            };
        }

        public DiscountCode GetByCode(string code)
        {
            return _discountCodes.SingleOrDefault(x => x.Code == code);
        }
    }
}
