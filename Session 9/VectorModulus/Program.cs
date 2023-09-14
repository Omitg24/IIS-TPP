using System;

namespace TPP.Laboratory.Concurrency.Lab09 {
    
    /// <summary>
    /// Clase VectorModulusProgram
    /// </summary>
    public class VectorModulusProgram {

        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            short[] vector = CreateRandomVector(100000, -10, 10);

            Master master = new Master(vector, 1);
            DateTime before = DateTime.Now;
            double result = master.ComputeModulus();
            DateTime after = DateTime.Now;
            Console.WriteLine("Result with one thread: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks );

            master = new Master(vector, 4);
            before = DateTime.Now;
            result = master.ComputeModulus();
            after = DateTime.Now;
            Console.WriteLine("Result with 4 threads: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
        }

        /// <summary>
        /// Método CreateRandomVector
        /// </summary>
        /// <param name="numberOfElements"></param>
        /// <param name="lowest"></param>
        /// <param name="greatest"></param>
        /// <returns></returns>
        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest) {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }

    }

}
