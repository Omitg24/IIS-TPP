using System;

namespace TPP.Laboratory.ObjectOrientation.Lab01
{
    /// <summary>
    /// Clase Program
    /// Clase para probar la LinkedList implementada
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(1);
            list.Add(8);
            list.Add(0);
            list.Add(6);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(9);
            Console.WriteLine(list.ToString());
            Console.WriteLine($"\tNumberOfElements: {list.NumberOfElements}");
            Console.WriteLine($"\tRemoving 0: {list.Remove(0)}");
            Console.WriteLine($"\tRemoving 0: {list.Remove(0)}");
            Console.WriteLine($"\tRemoving 4: {list.Remove(4)}");
            Console.WriteLine($"\tRemoving 1: {list.Remove(1)}");
            Console.WriteLine($"\tRemoving 2: {list.Remove(2)}");
            Console.WriteLine($"\tRemoving 1: {list.Remove(1)}");
            Console.WriteLine($"\tRemoving 1: {list.Remove(1)}");
            Console.WriteLine($"\tRemoving 0: {list.Remove(0)}");            
            Console.WriteLine(list.ToString());
            Console.WriteLine($"\tNumberOfElements: {list.NumberOfElements}");
            Console.WriteLine($"\tGetting 0 element: {list.GetElement(0)}");
            Console.WriteLine($"\tGetting 1 element: {list.GetElement(1)}");
            Console.WriteLine($"\tGetting 2 element: {list.GetElement(2)}");
            Console.WriteLine($"\tNumberOfElements: {list.NumberOfElements}");
            Console.WriteLine($"\tIndex of 8: {list.IndexOf(8)}");
            Console.WriteLine($"\tIndex of 6: {list.IndexOf(6)}");
            Console.WriteLine($"\tIndex of 2: {list.IndexOf(2)}");
            Console.WriteLine($"\tIndex of 9: {list.IndexOf(9)}");
            Console.WriteLine($"\tIndex of 0: {list.IndexOf(0)}");
            list.SetElement(0, 1);
            list.SetElement(1, 2);
            list.SetElement(2, 3);
            Console.WriteLine(list.ToString());
            Console.WriteLine($"\tNumberOfElements: {list.NumberOfElements}");
            list.Clear();
            Console.WriteLine(list.ToString());
            Console.WriteLine($"\tNumberOfElements: {list.NumberOfElements}");
        }
    }
}
