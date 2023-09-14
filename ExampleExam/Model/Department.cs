using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    public class Department {

        public Department(string name, IEnumerable<Employee> employees) {
            Name = name; 
            Employees = employees;
        }

        public string Name { get; private set; }

        public IEnumerable<Employee> Employees { get; private set; }

        public override string ToString() {
            return String.Format("[Department: {0}]", Name);
        }
    }
}
