class Program
{
    static void Main()
    {
        Program.Operaciones();
        // TODO: agregar un case para cada clase
    }


    public static void Fecha()
    {
        //Obtener la hora del sistema
        DateTime actual = DateTime.Now;
        Console.WriteLine(actual);
        /*y asi de facil
          obtienes la hora
         del sistema*/

    }
    public static void Float()
    {
        float DecimalGrande = 10152466.25f;
        //byte NumeroBytes = 5 + DecimalGrande; ESTO DA ERROR

        byte NumeroBytes = (byte)(5 + DecimalGrande); //gpt dice que se puede asi pero que el valor se "rompe"
        Console.WriteLine(NumeroBytes);
    }
    public static void Operaciones()
    {
        int Entero = 20;
        Console.WriteLine($"{Entero++}\n{Entero}");
        Entero -= 5;
        Console.WriteLine(Entero);

        //operaciones
        Console.WriteLine("Operaciones:\n Numeros iniciales:\n");

        int IntNumberOne = 59;
        int IntNumberTwo = 4;
        int Result = 0;

        Console.WriteLine($"Numero 1: {IntNumberOne}, Numero 2: {IntNumberTwo}\n");

        Console.WriteLine("Operando:");

        Result = ++IntNumberOne / IntNumberTwo--;
        Console.WriteLine($"Resultado: {Result}");
        Console.WriteLine($"Numero uno: {IntNumberOne}, Numero Dos: {IntNumberTwo}");
    }
}
