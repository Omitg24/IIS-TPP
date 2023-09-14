using System;

namespace TPP.Laboratory.Functional.Lab06 {

    /// <summary>
    /// Try to guess the behavior of this program without running it
    /// </summary>
    class Closures {

        /// <summary>
        /// Version with a single method
        /// </summary>
        static Func<int> Counter1() {
            int counter = 0;
            return () => ++counter;
        }

        /// <summary>
        /// Método Counter2
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="increment"></param>
        /// <param name="decrement"></param>
        /// <param name="assign"></param>
        static void Counter2(int initialValue, out Func<int> increment, out Func<int> decrement, out Action<int> assign)
        {
            int counter = initialValue;
            increment = () => counter++;
            decrement = () => counter--;
            assign = (value) => counter=value;
        }

        /// <summary>
        /// Método Counter3
        /// </summary>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        static Counter Counter3(int initialValue)
        {
            int counter = initialValue;
            return new Counter
            {
                increment = () => counter++,
                decrement = () => counter--,
                assign = (value) => counter = value,
            };
        }

        /// <summary>
        /// Clase Counter
        /// </summary>
        internal class Counter
        {
            internal Func<int> increment { get; set; }
            internal Func<int> decrement { get; set; }
            internal Action<int> assign { get; set; }
        }

        /// <summary>
        /// Método Counter4
        /// </summary>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        static (Func<int> increment, Func<int> decrement, Action<int> assign) Counter4(int initialValue)
        {
            int counter = initialValue;
            return (() => counter++,
                    () => counter--,
                    (value) => counter=value
                    );
        }

        /// <summary>
        /// Método Main
        /// </summary>
        static void Main() {
            //Versión 1:
            Console.WriteLine("-- Counter1:\ncounter:");
            Func<int> counter = Counter1();
            Console.WriteLine(counter());
            Console.WriteLine(counter());
            Console.WriteLine("anotherCounter:");
            Func<int> anotherCounter = Counter1();
            Console.WriteLine(anotherCounter());
            Console.WriteLine(anotherCounter());
            Console.WriteLine("counter:");
            Console.WriteLine(counter());
            Console.WriteLine(counter());

            //Versión 2:
            Console.WriteLine("\n-- Counter2:");
            Func<int> increment, decrement;
            Action<int> assign;
            Counter2(10, out increment, out decrement, out assign); //(10, out Func<int> increment, out Func<int> decrement, out Action<int> assign);
            Console.WriteLine(increment());
            Console.WriteLine(increment());
            assign(20);
            Console.WriteLine(decrement());
            Console.WriteLine(decrement());

            //Versión 3:
            Console.WriteLine("\n-- Counter3:");
            var counter3 = Counter3(100);
            Console.WriteLine(counter3.increment());
            Console.WriteLine(counter3.increment());
            counter3.assign(200);
            Console.WriteLine(counter3.decrement());
            Console.WriteLine(counter3.decrement());

            //Versión 4:
            Console.WriteLine("\n-- Counter4:");
            var counter4 = Counter4(1000); //Es una tupla de 2 funciones y 1 acción
            Console.WriteLine(counter4.increment());
            Console.WriteLine(counter4.increment());
            counter4.assign(2000);
            Console.WriteLine(counter4.decrement());
            Console.WriteLine(counter4.decrement());
        }
    }
}
