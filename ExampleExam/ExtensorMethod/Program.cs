using System;
using System.Collections.Generic;

namespace ExtensorMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                sequence.Add("B");
            }
            sequence.Add("N");
            for (int i = 0; i < 12; i++)
            {
                sequence.Add("B");
            }
            sequence.Add("N"); 
            sequence.Add("N"); 
            sequence.Add("N");
            for (int i = 0; i < 24; i++)
            {
                sequence.Add("B");
            }
            sequence.Add("N");
            for (int i = 0; i < 14; i++)
            {
                sequence.Add("B");
            }

            Console.WriteLine("SEQUENCE: ");
            foreach (string s in sequence)
            {
                Console.Write(s);
            }
            Console.WriteLine();

            Console.WriteLine("\nENCODED SEQUENCE: ");
            var encodedSequence = sequence.EncodeRLE();
            foreach (var s in encodedSequence)
            {
                Console.Write(s);
            }
            Console.WriteLine();

            Console.WriteLine("\nDECODED SEQUENCE: ");
            var decodedSequence = encodedSequence.DecodeRLE();
            foreach (var s in decodedSequence)
            {
                Console.Write(s);
            }
        }
    }
}
