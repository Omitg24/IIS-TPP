
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    /// <summary>
    /// Clase Algorithms
    /// </summary>
    static class Algorithms {

        // Exercise: Implement an IndexOf method that finds the first position (index) 
        // of an object in an array of objects. It should be valid for Person, Angle and future classes.
        /// <summary>
        /// Método IndexOf1
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static int? IndexOf1(this object[] elements, object target)
        {
            int index = 0;
            foreach (object element in elements)
            {
                if (element.Equals(target))
                {
                    return index;
                }
                index++;
            }
            return null;
        }
        
        /// <summary>
        /// Método IndexOf2
        /// Contempla la posibilidad de incluir un predicado de comparación,
        /// de esta forma se pueden poner más criterios
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="target"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        static int? IndexOf2(this object[] elements, object target, IEqualityPredicate predicate)
        {
            int index = 0;
            foreach (object element in elements)
            {
                if (Compare(element, target, predicate))
                {
                    return index;
                }
                index++;
            }
            return null;
        }

        /// <summary>
        /// Método Compare
        /// Método que, de recibir un predicado de comparación, realiza la comparación con dicho predicado,
        /// y, en caso de no recibir ninguno, devuelve la comparación base de Equals
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private static bool Compare(object e1, object e2, IEqualityPredicate predicate)
        {
            if (predicate == null)
            {
                return e1.Equals(e2);
            }
            return predicate.Compare(e1, e2);
        }

        /// <summary>
        /// Método CreatePeople
        /// </summary>
        /// <returns></returns>
        static Person[] CreatePeople() {
            string[] firstNames = { "Alba", "Omar", "Israel", "Guillermo", "Carlos", "Coral", "Raquel", "Javier" };
            string[] surnames = { "Francos", "Teixeira", "Solís", "Pulido", "Sánchez", "Izquierdo", "Suárez", "Escalada" };
            int numberOfPeople = 100;

            Person[] printOut = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printOut[i] = new Person(
                    firstNames[random.Next(0, firstNames.Length)],
                    surnames[random.Next(0, surnames.Length)],
                    random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z')
                    );
            return printOut;
        }

        /// <summary>
        /// Método CreateAngles
        /// </summary>
        /// <returns></returns>
        static Angle[] CreateAngles() 
        {
            Angle[] angles = new Angle[(int)(Math.PI * 2 * 10)];
            int i = 0;
            while (i < angles.Length) {
                angles[i] = new Angle(i / 10.0);
                i++;
            }
            return angles;
        }

        /// <summary>
        /// Método Main
        /// </summary>
        static void Main() {
            // To be done by the student
            //CREACIÓN DE VARIABLES
            var people = CreatePeople();
            var angles = CreateAngles();
            var person0 = new Person(people[75].FirstName, people[75].SurName, people[75].IDNumber);
            var angle0 = new Angle(angles[50].Radians);

            //PRUEBAS CON INDEXOF1
            Console.WriteLine("PRUEBAS DE INDEXOF1");            
            var idxPerson1 = people.IndexOf1(person0);
            Console.WriteLine($"\tidxPerson1 = {idxPerson1}");
            if (idxPerson1.HasValue)
            {
                Console.WriteLine($"\tperson0 = {person0}");
                Console.WriteLine($"\tpeople[{idxPerson1.Value}] = {people[idxPerson1.Value]}");
            }                        
            var idxAngle1 = angles.IndexOf1(angle0);
            Console.WriteLine($"\n\tidxAngle1 = {idxAngle1}");
            if (idxAngle1.HasValue)
            {
                Console.WriteLine($"\tangle0 = {angle0}");
                Console.WriteLine($"\tangle[{idxAngle1.Value}] = {angles[idxAngle1.Value]}");
            }

            //PRUEBAS CON INDEXOF2
            Console.WriteLine("\nPRUEBAS DE INDEXOF2");
            var idxPerson2 = people.IndexOf2(person0, predicate : new SameFirstName());
            Console.WriteLine($"\tidxPerson2 = {idxPerson2}");
            if (idxPerson2.HasValue)
            {
                Console.WriteLine($"\tperson0 = {person0}");
                Console.WriteLine($"\tpeople[{idxPerson2.Value}] = {people[idxPerson2.Value]}");
            }
            var idxAngle2 = angles.IndexOf2(angle0, predicate : new SameQuadrant());
            Console.WriteLine($"\n\tidxAngle2 = {idxAngle2}");
            if (idxAngle2.HasValue)
            {
                Console.WriteLine($"\tangle0 = {angle0}");
                Console.WriteLine($"\tangle[{idxAngle2.Value}] = {angles[idxAngle2.Value]}");
            }
        }

        class SameSine : IEqualityPredicate
        {
            public bool Compare(object e1, object e2)
            {
                Angle a1 = e1 as Angle, a2 = e2 as Angle;
                if (a1 == null || a2 == null)
                {
                    return false;
                }
                return a1.Sine() == a2.Sine();
            }
        }

        /// <summary>
        /// Clase SameFirstName
        /// </summary>
        class SameFirstName : IEqualityPredicate
        {
            /// <summary>
            /// Método Compare
            /// </summary>
            /// <param name="e1"></param>
            /// <param name="e2"></param>
            /// <returns></returns>
            public bool Compare(object e1, object e2)
            {
                Person p1 = e1 as Person, p2 = e2 as Person;
                if (p1 == null || p2 == null)
                {
                    return false;
                }
                return p1.FirstName.Equals(p2.FirstName);
            }
        }

        /// <summary>
        /// Clase SameQuadrant
        /// </summary>
        class SameQuadrant : IEqualityPredicate
        {
            /// <summary>
            /// Método Compare
            /// </summary>
            /// <param name="e1"></param>
            /// <param name="e2"></param>
            /// <returns></returns>
            public bool Compare(object e1, object e2)
            {
               Angle a1 = e1 as Angle, a2 = e2 as Angle;
                if (a1 == null || a2 == null)
                {
                    return false;
                }
                return Quadrant(a1.Radians) == Quadrant(a2.Radians);
            }

            /// <summary>
            /// Método Quadrant
            /// </summary>
            /// <param name="angle"></param>
            /// <returns></returns>
            private uint Quadrant(double angle)
            {
                if (angle > 2 * Math.PI)
                {
                    return Quadrant(angle % (2 * Math.PI));
                }
                if (angle < 0)
                {
                    return Quadrant(angle + (2 * Math.PI));
                }
                if (angle <= (Math.PI/2))
                {
                    return 1;
                } 
                else if (angle <= (Math.PI))
                {
                    return 2;
                }
                else if (angle <= (3*(Math.PI/2)))
                {
                    return 3;
                }
                return 4;

            }
        }

        /// <summary>
        /// Interfaz IEqualityPredicate
        /// </summary>
        interface IEqualityPredicate
        {
            /// <summary>
            /// Método Compare
            /// </summary>
            /// <param name="e1"></param>
            /// <param name="e2"></param>
            /// <returns></returns>
            bool Compare(object e1, object e2);
        }
    }
}
