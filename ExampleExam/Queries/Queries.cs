using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    class Query
    {

        private Model model = new Model();

        private static void Show<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
        }

        static void Main(string[] args)
        {
            Query query = new Query();
            query.Query1();
        }

        private void Query1()
        {
            var buildings = model.
            Show(buildings);
        }
    }
}
