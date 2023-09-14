using System;

namespace TPP.Laboratory.ObjectOrientation.Lab04
{

    /// <summary>
    /// Clase Person
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
        /// Propiedad SurName
        /// </summary>
        public String SurName {
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
        /// Constructor Person con parámetros
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        public Person(String name, String surname, string idNumber) {
            this.firstName = name;
            this.surname = surname;
            this.idNumber = idNumber;
        }

        /// <summary>
        /// Constructor Person sin parámetros (para las propiedades)
        /// </summary>
        public Person() { }

        /************************** Equals must be implemented (GetHashCode is advisable) *********************/
        /// <summary>
        /// Método Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            Person person = obj as Person;
            if (person == null)
                return false;
            return this.IDNumber.Equals(person.IDNumber);
        }

        /// <summary>
        /// Método GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return this.IDNumber.GetHashCode();
        }

    }
}
