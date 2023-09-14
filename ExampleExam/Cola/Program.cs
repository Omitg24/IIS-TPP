using System;
using LinkedList;

namespace Cola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var predicates = new List<Predicate<int>>();
            predicates.Add((x) => x%2 == 0);
            predicates.Add((x) => x >= 2);
            predicates.Add((x) => x <= 20);
            predicates.Add((x) => x/1 == x);
            var cola = new Cola<int>(predicates);
            Console.WriteLine(cola.EstaVacía);  //True
            Console.WriteLine(cola.Encolar(1)); //False
            Console.WriteLine(cola.Encolar(2)); //True
            Console.WriteLine(cola.Encolar(0)); //False
            Console.WriteLine(cola.Encolar(25));    //False
            Console.WriteLine(cola.Encolar(4)); //True
            Console.WriteLine(cola.Encolar(6)); //True
            Console.WriteLine(cola.Encolar(3)); //False
            Console.WriteLine(cola.Encolar(10));    //True
            Console.WriteLine(cola.Encolar(16));    //True
            Console.WriteLine(cola.EstaVacía);  //False
            Console.WriteLine(cola);
            Console.WriteLine($"Numero de elementos: {cola.NumberOfElements}");
            int value = 0;
            cola.Desencolar(out value);
            Console.WriteLine(value);
            cola.Desencolar(out value);
            Console.WriteLine(value);
            cola.Desencolar(out value);
            Console.WriteLine(value);
            Console.WriteLine($"Numero de elementos: {cola.NumberOfElements}");
            cola.Desencolar(out value);
            Console.WriteLine(value);
            cola.Desencolar(out value);
            Console.WriteLine(value);
            Console.WriteLine(cola.EstaVacía);
            Console.WriteLine($"Numero de elementos: {cola.NumberOfElements}");
        }
    }
}
