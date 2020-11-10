using System;

namespace ShoppingCart.Domain
{
    public class DiscountCode
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public decimal Value { get; set; }

        public DateTime Expiry { get; set; }

        public bool IsUsed { get; set; }
    }
}

