using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    /// <summary>
    /// Clase Autoboxing
    /// </summary>
    class Autoboxing
    {
        /// <summary>
        /// Método AutoboxingDemo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static int AutoboxingDemo(int obj)
        {
            return obj;
        }

        /// <summary>
        /// Método Demo
        /// </summary>
        private static void Demo()
        {
            int i = 3;
            int oi = i;
            object o = i;
            AutoboxingDemo(3);
            Console.WriteLine(o);

            i = oi;
            Console.WriteLine(i);
            i = (int) o;
            int unbox = AutoboxingDemo(3);
            Console.WriteLine(i);
        }

        /// <summary>
        /// Método AsIsDemo
        /// </summary>
        private static void AsIsDemo()
        {
            object str = "a sample string";

            if (str is string)
            {
                Console.WriteLine("Length: {0}.", ((string)str).Length);
                Console.WriteLine("Uppercase: {0}.", ((string)str).ToUpper());
            }

            string asString = str as string;
            if (asString != null)
            {
                Console.WriteLine("Length: {0}.", asString.Length);
                Console.WriteLine("ToString: {0}.", asString.ToUpper());
            }
        }

        /// <summary>
        /// Método Main
        /// </summary>
        static void Main()
        {
            Demo();
            AsIsDemo();
        }
    }
}
