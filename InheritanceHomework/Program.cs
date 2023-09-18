namespace InheritanceHomework;

// create program that allows you to either buy or rent
// different types of cars

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        vehicles.Add(new Car { ProductName = "Tesla", QuantityInStock = 2 });
        vehicles.Add(new Truck { ProductName = "Tundra", QuantityInStock = 1 });
        vehicles.Add(new Motorcycle { ProductName = "Hell's Angel", QuantityInStock = 3 });

        Console.Write("Do you want to purchase or rent: ");
        string output = Console.ReadLine();

        //if (output == "rent")
        //{
        //    foreach (var item in vehicles)
        //    {
        //        if (item is IRentable)
        //        {
        //            Console.WriteLine(item.ProductName);
        //        }
        //    }
        //}
        //else
        //{
        //    foreach (var item in vehicles)
        //    {
        //        if (item is IPurchasable)
        //        {
        //            Console.WriteLine(item.ProductName);
        //        }
        //    }
        //}

        List<IVehicleInventory> inventory = new List<IVehicleInventory>();

        inventory.Add(new Car { ProductName = "Tesla", QuantityInStock = 2 });
        inventory.Add(new Truck { ProductName = "Tundra", QuantityInStock = 1 });
        inventory.Add(new Motorcycle { ProductName = "Hell's Angel", QuantityInStock = 3 });

        if (output == "rent")
        {
            foreach (var item in inventory)
            {
                if (item is IRentable)
                {
                    Console.WriteLine(item.ProductName);
                }
            }
        }
        else
        {
            foreach (var item in inventory)
            {
                if (item is IPurchasable)
                {
                    Console.WriteLine(item.ProductName);
                }
            }
        }

        Console.ReadLine();
    }
}

public interface IPurchasable : IVehicleInventory
{
    void Purchase();
}

public interface IRentable : IVehicleInventory
{
    void Rent();
    void ReturnRental();
}

public interface IVehicleInventory
{
    string ProductName { get; set; }
    int QuantityInStock { get; set; }
}

public class Vehicle
{
    public string ProductName { get; set; }
    public int QuantityInStock { get; set; }
}

public class Car : Vehicle, IPurchasable
{
    public void Purchase()
    {
        QuantityInStock--;
        Console.WriteLine("Car purchased.");
    }
}

public class Truck : Vehicle, IPurchasable, IRentable
{
    public void Purchase()
    {
        QuantityInStock--;
        Console.WriteLine("Truck purchased.");
    }

    public void Rent()
    {
        QuantityInStock--;
        Console.WriteLine("Truck rented.");
    }

    public void ReturnRental()
    {
        QuantityInStock++;
        Console.WriteLine("Truck returned.");
    }
}

public class Motorcycle : Vehicle, IRentable
{
    public void Rent()
    {
        QuantityInStock--;
        Console.WriteLine("Motorcycle rented.");
    }

    public void ReturnRental()
    {
        QuantityInStock++;
        Console.WriteLine("Motorcycle returned.");
    }
}