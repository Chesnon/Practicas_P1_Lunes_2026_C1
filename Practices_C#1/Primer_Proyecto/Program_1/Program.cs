class Program
{
    const double PI = 3.1416;

    static void Main()
    {
        Console.WriteLine("PI es: " + PI);

        PI = 23


        Variables.Show();
    }
}

class Variables
{
    public static void Show()
    {
        var number = 2;
        var decimalValue = 0.56;
        var name = "Papotico";
        var booleana = false;
        
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine($"Variable numerica: {number}\nVariable decimal: {decimalValue}\nVariable String: {name}\nVariable booleana: {booleana}");
    }
}