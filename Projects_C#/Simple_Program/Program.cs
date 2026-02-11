using System;

class Program
{
    static void Main()
    {
        string respuesta;
        do
        {
            //Pedimos al usuario que ingrese un número entero
            Console.WriteLine("Por favor ingrese un número entero que desee saber si es par o impar");
            int Number = int.Parse(Console.ReadLine());

            //operamos el número para saber si es par o impar
            if (Number % 2 == 0)
            {
                Console.WriteLine("El número es par");
            }
            else
            {
                Console.WriteLine("El número es impar");
            }

            Console.WriteLine("¿Desea ingresar otro número? (s/n)");
            respuesta = Console.ReadLine();
        }
        while (respuesta == "s");

    }
}