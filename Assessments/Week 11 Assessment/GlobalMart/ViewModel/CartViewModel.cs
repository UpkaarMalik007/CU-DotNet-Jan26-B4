namespace GlobalMart.ViewModel
{
    public class CartViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public string PromoCode { get; set; } = "None";
    }
}
