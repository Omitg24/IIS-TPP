using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02 {

    /// <summary>
    /// Person class used in different examples
    /// </summary>
    public class Person {
        /// <summary>
        /// Atributos firstName, surname
        /// </summary>
        private String firstName, surname;

        /// <summary>
        /// Propiedad FirstName
        /// </summary>
        public String FirstName {
            get { return firstName; }
        }

        /// <summary>
        /// Propiedad Surname
        /// </summary>
        public String Surname {
            get { return surname; }
        }

        /// <summary>
        /// Atributo idNumber
        /// </summary>
        private string idNumber;

        /// <summary>
        /// Propiedad IDNumber
        /// </summary>
        public string IDNumber {
            get { return idNumber; }
        }

        /// <summary>
        /// Método ToString
        /// </summary>
        /// <returns></returns>
        public override String ToString() {
            return String.Format("{0} {1}, with {2} ID number", firstName, surname, idNumber);
        }

        /// <summary>
        /// Constructor de Person
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        public Person(String firstName, String surname, string idNumber) {
            this.firstName = firstName;
            this.surname = surname;
            this.idNumber = idNumber;
        }
    }
}
