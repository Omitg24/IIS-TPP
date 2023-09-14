using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensorMethod
{
    public static class Extensor
    {

        public static IEnumerable<(int, T)> EncodeRLE<T>(this IEnumerable<T> collection)
        {            
            var list = new List<(int, T)> ();
            int counter = 0, iter = 0; ;
            T previousElement = default;            
            foreach (var item in collection)
            {                   
                if (iter != 0) 
                {
                    if (item.Equals(previousElement))
                    {
                        counter++;
                    }
                    else
                    {
                        counter++;
                        list.Add((counter, previousElement));
                        counter = 0;
                    }
                }
                previousElement = item;
                iter++;
            }
            counter++;
            list.Add((counter, previousElement));
            return list;
        }
        
        public static IEnumerable<T> DecodeRLE<T>(this IEnumerable<(int, T)> collection)
        {
            var list = new List<T>();
            int counter = 0;
            foreach (var item in collection)
            {
                counter = item.Item1;
                while (counter > 0)
                {
                    list.Add(item.Item2);
                    counter--;
                }
            }
            return list;
        }
    }
}
