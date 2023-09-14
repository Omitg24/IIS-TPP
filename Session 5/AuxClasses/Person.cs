using System;

namespace TPP.Laboratory.Functional.Lab05 
{
    /// <summary>
    /// Clase Person
    /// </summary>
    public class Person 
    {
        
        /// <summary>
        /// Propiedad FirstName
        /// </summary>
        public String FirstName { get; private set; }

        /// <summary>
        /// Propiedad Surname
        /// </summary>
        public String Surname { get; private set; }

        /// <summary>
        /// Propiedad IDNumber
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// Método ToString
        /// </summary>
        /// <returns></returns>
        public override String ToString() {
            return String.Format("{0} {1}, with {2} ID number", FirstName, Surname, IDNumber);
        }

        /// <summary>
        /// Constructor Person con parámetros
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        public Person(String firstName, String surname, string idNumber) {
            this.FirstName = firstName;
            this.Surname = surname;
            this.IDNumber = idNumber;
        }


    }
}
