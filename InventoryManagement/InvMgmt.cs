/// <summary>
/// Represents a product with its name, price, and stock information.
/// </summary>
public class InvMgmt
{

    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product { Name = "Apple", Price = 100, Stock = 5 },
            new Product { Name = "Orange", Price = 200, Stock = 3 },
            new Product { Name = "Kiwi", Price = 50, Stock = 10 }
        };

        string sortKey = "stock";
        bool ascending = false;

        Products(products,sortKey, ascending);

    }

    /// <summary>
    /// Sorts the list of products based on the specified sort key and order.
    /// </summary>
    /// <param name="products">The list of products to be sorted.</param>
    /// <param name="sortKey">The key based on which sorting is performed (name, price, or stock).</param>
    /// <param name="ascending">Specifies whether to sort in ascending order (true) or descending order (false).</param>
    /// <returns>The sorted list of products.</returns>
    public List<Product> SortProducts(List<Product> products, string sortKey, bool ascending)
    {
        switch (sortKey.ToLower())
        {
            case "name":
                return ascending ? products.OrderBy(p => p.Name).ToList() : products.OrderByDescending(p => p.Name).ToList();
            case "price":
                return ascending ? products.OrderBy(p => p.Price).ToList() : products.OrderByDescending(p => p.Price).ToList();
            case "stock":
                return ascending ? products.OrderBy(p => p.Stock).ToList() : products.OrderByDescending(p => p.Stock).ToList();
            default:
                throw new ArgumentException("Invalid sort key specified.");
        }
    }

    /// <summary>
    /// Calls the SortProducts method to sort the list of products and prints the sorted products.
    /// </summary>
    /// <param name="products">The list of products to be sorted.</param>
    /// <param name="sortKey">The key based on which sorting is performed (name, price, or stock).</param>
    /// <param name="ascending">Specifies whether to sort in ascending order (true) or descending order (false).</param>
    static void Products(List<Product> products, string sortKey, bool ascending)
    {
        var inventoryManager = new InvMgmt();
        var sortedProducts = inventoryManager.SortProducts(products, sortKey, ascending);

        PrintMessage(sortedProducts);
    }

    static void PrintMessage(List<Product> sortedProducts)
    {
        Console.WriteLine("Sorted Products:");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
        }
    }

}