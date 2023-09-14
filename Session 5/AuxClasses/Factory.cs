using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace TPP.Laboratory.Functional.Lab05 {

    /// <summary>
    /// Creates collections of objects 
    /// </summary>
    public class Factory {

        /// <summary>
        /// Creats a collection of people
        /// </summary>
        public static Person[] CreatePeople() {
            string[] firstNames = { "Alba", "Omar", "Israel", "Guillermo", "Carlos", "Coral", "Raquel", "Javier", "Bruce", "Selina", "Omar", "Alba"};
            string[] surnames = { "Francos", "Teixeira", "Solís", "Pulido", "Sánchez", "Izquierdo", "Suárez", "Escalada", "Wayne", "Kyle", "Wayne", "Kyle"};
            string[] idNumbers = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384W", "9469019K", "4810993W", "9190315K"};

            Debug.Assert(firstNames.Length == surnames.LongLength && surnames.Length == idNumbers.Length);
            Person[] people = new Person[firstNames.Length];
            for (int i = 0; i < people.Length; i++)
                people[i] = new Person(firstNames[i], surnames[i], idNumbers[i]);
            return people;
        }


        /// <summary>
        /// Creates a collection of angles from 0 to 360 degrees
        /// </summary>
        public static Angle[] CreateAngles() {
            Angle[] angles = new Angle[361];
            for(int angle=0; angle<=360; angle++)
                angles[angle] = new Angle(angle/180.0*Math.PI);
            return angles;
        }

    }
}
