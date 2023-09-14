using System;

namespace TPP.Laboratory.ObjectOrientation.Lab04
{
    /// <summary>
    /// Clase Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Método Swap
        /// Intercambia 2 variables
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void Swap<T>(ref T x, ref T y)
        {
            Console.WriteLine($"x = {x}\ny = {y}\nSwaping {x} and {y}");
            (y, x) = (x, y);
        }

        /// <summary>
        /// Método Max1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static IComparable Max1 (IComparable a, IComparable b)
        {
            return a.CompareTo(b)>0 ? a : b;
        }

        /// <summary>
        /// Método Max2
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static IComparable<T> Max2<T> (IComparable<T> a, IComparable<T> b)
        {
            return a.CompareTo((T)b)>0 ? a : b;
        }

        /// <summary>
        /// Método Max3
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static T Max3<T>(IComparable<T> a, IComparable<T> b)
        {
            return (T) (a.CompareTo((T)b)>0 ? a : b);
        }

        /// <summary>
        /// Método Max4
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static T Max4<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b)>0 ? a : b;
        }

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static void Main(string[] args)
        {
            var x = 2;
            var y = 1; //var y = "Hola" daría error de compilación,
                       //debido a no ser posible la inferencia de tipos.
            Swap(ref x, ref y);
            Console.WriteLine($"x = {x}\ny = {y}");

            int m1 = (int) Max1(x, y);  //No detecta fallos de compilación, requiere casting
            Console.WriteLine($"\nEl mayor (Max1) entre {x} y {y} es: {m1}");

            int m2 = (int)Max2(x, y);  //Da fallos de compilación, por tipos distintos, requiere casting en la llamada, no en el método
            Console.WriteLine($"El mayor (Max2) entre {x} y {y} es: {m2}");

            int m3 = Max3(x, y);  //Da fallos de compilación, por tipos distintos, no requiere casting en la llamada, pero sí en el método
            Console.WriteLine($"El mayor (Max3) entre {x} y {y} es: {m3}");

            int m4 = Max4(x, y);  //Da fallos de compilación, por tipos distintos, no requiere casting ni en la llamada ni en el método
            Console.WriteLine($"El mayor (Max3) entre {x} y {y} es: {m4}");
        }
    }
}
