namespace Strategy
{
    /// <summary>
    /// Strategy
    /// </summary>
    public interface IExportService
    {
        void Export(Order order);
    }

    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to Json.");
        }
    }

    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML.");
        }
    }

    /// <summary>
    /// ConcreteStrategy
    /// </summary>
    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV.");
        }
    }
   
    /// <summary>
    /// Context
    /// </summary>
    public class Order
    {
        public string Customer { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }                 

        public Order(string customer, int amount, string name)
        {
            Customer = customer;
            Amount = amount;
            Name = name;
        }

        public void Export(IExportService exportService)
        {
            if (exportService is null)
            {
                throw new ArgumentNullException(nameof(exportService));
            }

            exportService.Export(this);
        }
    }
}
