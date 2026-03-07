namespace Day15_Part02_Exercise_Order_Class
{
    class Order
    {
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private DateTime _orderDate;
        private string _status;
        private bool _discountApplied;

        public Order()
        {
            _orderDate = DateTime.Now;
            _status = "NEW";
            _discountApplied = false;
        }

        public Order(int orderId, string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be empty.");

            _orderId = orderId;
            _customerName = customerName;
            _orderDate = DateTime.Now;
            _status = "NEW";
            _discountApplied = false;
        }

        public int OrderId
        {
            get { return _orderId; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Customer name cannot be empty.");
                _customerName = value;
            }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }

        public void AddItem(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be positive.");

            _totalAmount += price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (_discountApplied)
                throw new InvalidOperationException("Discount already applied.");

            if (percentage < 1 || percentage > 30)
                throw new ArgumentException("Discount must be between 1 and 30.");

            decimal discountAmount = (_totalAmount * percentage) / 100;
            _totalAmount -= discountAmount;

            if (_totalAmount < 0)
                _totalAmount = 0;

            _discountApplied = true;
        }

        public string GetOrderSummary()
        {
            return $"Order Id: {_orderId}\n" +
                   $"Customer: {_customerName}\n" +
                   $"Total Amount: {_totalAmount}\n" +
                   $"Status: {_status}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(101, "Rahul");
            order1.AddItem(500);
            order1.AddItem(300);
            order1.ApplyDiscount(10);

            Console.WriteLine(order1.GetOrderSummary());
            Console.WriteLine();

            Order order2 = new Order();
            order2.CustomerName = "Aman";
            order2.AddItem(1000);
            order2.ApplyDiscount(20);

            Console.WriteLine(order2.GetOrderSummary());
        }
    }
}