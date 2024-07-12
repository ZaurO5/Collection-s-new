public class Inventory
{
    public Dictionary<string, int>
    Products
    { get; private set; }

    public Inventory()
    {
        Products = new Dictionary<string, int>();
    }

    public void AddProduct(string productName, int quantity)
    {
        if (!Products.ContainsKey(productName))
        {
            Products[productName] = quantity;
            Console.WriteLine($"Product: {productName}, quantity: {quantity}.");
        }
        else
        {
            Console.WriteLine($"Product {productName} already exists. Use UpdateQuantity.");
        }
    }

    public void RemoveProduct(string productName)
    {
        if (Products.ContainsKey(productName))
        {
            Products.Remove(productName);
            Console.WriteLine($"Product {productName} removed.");
        }
        else
        {
            Console.WriteLine($"Product {productName} not found.");
        }
    }

    public void UpdateQuantity(string productName, int quantity)
    {
        if (Products.ContainsKey(productName))
        {
            Products[productName] = quantity;
            Console.WriteLine($"Quantity {productName}. New quantity {quantity}.");
        }
        else
        {
            Console.WriteLine($"Product {productName} not found. Use AddProduct.");
        }
    }

    public int GetQuantityByProduct(string productName)
    {
        if (Products.TryGetValue(productName, out int quantity))
        {
            return quantity;
        }
        else
        {
            Console.WriteLine($"Product {productName} not found.");
            return 0;
        }
    }
}