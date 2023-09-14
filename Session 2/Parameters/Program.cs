using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    /// <summary>
    /// Clase Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Método Main
        /// Mostrar los diferentes tipos de parámetros
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int x = 1;
            int y = 2;
            Console.WriteLine($"Before Swap:\n\tx = {x}\n\ty = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"After Swap:\n\tx = {x}\n\ty = {y}");

            AskData(out string fn, out string sn, out string id);
            Console.WriteLine($"\tFirstName: {fn}\n\tSurname: {sn}\n\tID Number: {id}");
        }
        
        /// <summary>
        /// Método Swap
        /// Intercambia 2 variables
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void Swap(ref int x, ref int y)
        {
            Console.WriteLine($"Swaping {x} and {y}");
            (y, x) = (x, y);
        }

        /// <summary>
        /// Método AskData
        /// Pregunta datos al usuario
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="sn"></param>
        /// <param name="id"></param>
        private static void AskData(out string fn, out string sn, out string id)
        {
            Console.WriteLine("\nAsking Data:");
            Console.Write("First Name: ");
            fn = Console.In.ReadLine();
            Console.Write("Surname: ");
            sn = Console.In.ReadLine();
            Console.Write("ID Number: ");
            id = Console.In.ReadLine();
        }
    }
}
