namespace GlobalMart.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculatePrice(decimal basePrice, string promo)
        {
            if (promo == "WINTER25")
            {
                return basePrice * 0.85m;
            }
            if(promo== "FREESHIP")
            {
                return basePrice - 5m;
            }
            return basePrice;
        }
    }
}
