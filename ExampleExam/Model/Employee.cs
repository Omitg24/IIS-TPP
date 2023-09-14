using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    public class Employee {

        public Employee(string name, string surname, DateTime dateOfBirth, string telephoneNumber, string email, string province, Office office) {
            Name = name;
            Surname = surname;
            Email = email;
            TelephoneNumber = telephoneNumber;
            DateOfBirth = dateOfBirth;
            Province = province;
            Office = office;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Province { get; set; }
        public Office Office { get; set; }
        public Department Department { get; set; }
        public int Age { get { return (DateTime.Now - DateOfBirth).Days / 365; } }

        public override string ToString() {
            return String.Format("[Employee: {0}]", Name);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

}
