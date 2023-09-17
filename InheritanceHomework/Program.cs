namespace InheritanceHomework;

// create program that allows you to either buy or rent
// different types of cars

class Program
{
    static void Main(string[] args)
    {


        Console.ReadLine();
    }
}

public interface IEngine
{
    void Run();
}

public class Vehicle
{
    public string Name { get; set; }
}

public class Car : Vehicle
{
    
}

public class Truck : Vehicle
{

}

public class Motorcycle : Vehicle
{

}