using System;

class Program
{    static void Main(string[] args)
    {
        Console.Write("Informe um número: ");
        int num = int.Parse(Console.ReadLine());

        if (PertenceFibonacci(num))
        {
            Console.WriteLine($"O número {num} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {num} não pertence à sequência de Fibonacci.");
        }
    }

    static bool PertenceFibonacci(int numero)
    {
        int a = 0, b = 1;
        if (numero == a || numero == b)
        {
            return true;
        }

        int proximo = a + b;
        while (proximo <= numero)
        {
            if (proximo == numero)
            {
                return true;
            }

            a = b;
            b = proximo;
            proximo = a + b;
        }

        return false;
    }
}
