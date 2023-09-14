
using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02 {

    /// <summary>
    /// Default argument values
    /// </summary>
    class DefaultArgumentValues {


        /// <summary>
        /// This method filters all the people with:
        /// - A specific first name
        /// - A specific surname name
        /// - A part of an ID number
        /// Comparison should not be case-sensitive
        /// Returns the people fulfilling the criteria
        /// </summary>
        static Person[] Filter(Person[] people, string firstName = null, string surname = null, string idNumberContains = null) {
            Person[] filteredPeople = new Person[people.Length];

            int i = 0;
            foreach (Person person in people)
            {
                if ((firstName != null && firstName.Equals(person.FirstName)) ||
                    (surname != null && surname.Equals(person.Surname)) ||
                    (idNumberContains != null && person.IDNumber.Contains(idNumberContains)))
                {
                    filteredPeople[i] = person;
                    i++;
                }
            }
            Array.Resize(ref filteredPeople, i);
            return filteredPeople;
        }


        /// <summary>
        /// Creates a random list of people 
        /// </summary>
        /// <returns></returns>
        static Person[] CreatePeople() {
            string[] firstNames = { "Alba", "Omar", "Israel", "Guillermo", "Carlos", "Coral", "Raquel", "Javier" };
            string[] surnames = { "Francos", "Teixeira", "Solís", "Pulido", "Sánchez", "Izquierdo", "Suárez", "Escalada" };
            int numberOfPeople = 100;

            Person[] printout = new Person[numberOfPeople];
            Random random = new Random();
            for (int i = 0; i < numberOfPeople; i++)
                printout[i] = new Person(
                    firstNames[random.Next(0, firstNames.Length)],
                    surnames[random.Next(0, surnames.Length)],
                    random.Next(9000000, 90000000) + "-" + (char)random.Next('A', 'Z')
                    );
            return printout;
        }

        /// <summary>
        /// Shows a list of people in the console
        /// </summary>
        static void Show(Person[] people) {
            foreach (Person person in people) {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Complete the following code
        /// </summary>
        static void Main() {
            Person[] people = CreatePeople();
            Console.WriteLine("People named Alba:");
            // * Complete the code
            Show(Filter(people, firstName: "Alba"));
            Console.WriteLine("People whose surname is Francos:");
            // * Complete the code
            Show(Filter(people, surname: "Francos"));
            Console.WriteLine("People whose ID number contains A");
            // * Complete the code
            Show(Filter(people, idNumberContains: "A"));
        }
    }
}
