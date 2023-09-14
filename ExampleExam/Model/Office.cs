using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    public class Office {

        public Office(string number, string building) {
            Number = number; 
            Building = building;
        }

        public string Number { get; private set;}
        public string Building { get; private set; }

        public override string ToString() {
            return String.Format("[Office: {0}\\{1}]", Number, Building);
        }
    }
}
