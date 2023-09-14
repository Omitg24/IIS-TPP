using System;

namespace TPP.Laboratory.ObjectOrientation.Lab04
{
    class OtherProgram
    {
        static IComparable Max1(IComparable a, IComparable b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        static IComparable<T> Max2<T>(IComparable<T> a, IComparable<T> b)
        {
            return a.CompareTo((T) b) > 0 ? a : b;
        }

        static T Max3<T>(IComparable<T> a, IComparable<T> b)
        {
            return (T) (a.CompareTo((T)b) > 0 ? a : b);
        }

        static T Max4<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        static void Main(string[] args)
        {
            Person p = new Person("g");
            Animal a = new Animal("f");

            /******************************************************************
             * Max1
             ***/

            /* SIN error de compilación */
            /* SIN error de ejecución */
            IComparable c_pa_1 = Max1(p, a);
            Console.WriteLine($"c_pa_1 = {c_pa_1}");

            /* SIN error de compilación */
            /* SIN error de ejecución */
            IComparable c_ap_1 = Max1(a, p);
            Console.WriteLine($"c_ap_1 = {c_ap_1}");

            /******************************************************************
             * Max2
             ***/

            /* No hay error en compilación, el sistema de tipos lo permite */
            /* Error en ejecución: no se puede convertir Animal en Persona */
            //IComparable<Person> cp_pa_2 = Max2<Person>(p, a);
            //Console.WriteLine($"cp_pa_2 = {cp_pa_2}");

            /* SIN error de compilación */
            /* SIN error de ejecución */
            IComparable<Animal> ca_pa_2 = Max2<Animal>(p, a);
            Console.WriteLine($"ca_pa_2 = {ca_pa_2}");

            /* SIN error de compilación */
            /* SIN error de ejecución */
            IComparable<Person> cp_ap_2 = Max2<Person>(a, p);
            Console.WriteLine($"cp_ap_2 = {cp_ap_2}");

            /* SIN error de compilación */
            /* Error en ejecución: no se puede convertir Persona en Animal */
            //IComparable<Animal> ca_ap_2 = Max2<Animal>(a, p);
            //Console.WriteLine($"ca_ap_2 = {ca_ap_2}");

            /******************************************************************
             * Max3
             ***/

            /* SIN error de compilación */
            /* Error en ejecución: no se puede convertir Animal en Persona */
            //Person p_pa_3 = Max3<Person>(p, a);
            //Console.WriteLine($"p_pa_3 = {p_pa_3}");

            /* SIN error de compilación */
            /* Person > Animal -> SIN error en ejecución */
            /* Animal > Persona -> Error en ejecución: no se puede convertir Animal en Persona */
            Person p_ap_3 = Max3<Person>(a, p);
            Console.WriteLine($"p_ap_3 = {p_ap_3}");

            /* SIN error de compilación */
            /* Person > Animal -> Error en ejecución: no se puede convertir Persona en Animal */
            /* Animal > Persona -> SIN error en ejecución */
            //Animal a_pa_3 = Max3<Animal>(p, a);
            //Console.WriteLine($"a_pa_3 = {a_pa_3}");

            /* SIN error de compilación */
            /* Error en ejecución: no se puede convertir Persona en Animal */
            //Animal a_ap_3 = Max3<Animal>(a, p);
            //Console.WriteLine($"a_ap_3 = {a_ap_3}");

            /******************************************************************
             * Max4
             ***/

            /* Error de compilación: no se puede convertir Animal en Persona */
            /* Este error es gracias a la genericidad acotada */
            //Person p_pa_4 = Max4<Person>(p, a);
            //Console.WriteLine($"p_pa_4 = {p_pa_4}");

            /* Error de compilación: no se puede convertir Animal en Persona */
            /* Este error es gracias a la genericidad acotada */
            //Person p_ap_4 = Max4<Person>(a, p);
            //Console.WriteLine($"p_ap_4 = {p_ap_4}");

            /* Error de compilación: no se puede convertir Persona en Animal */
            /* Este error es gracias a la genericidad acotada */
            //Animal a_pa_4 = Max4<Animal>(p, a);
            //Console.WriteLine($"a_pa_4 = {a_pa_4}");

            /* Error de compilación: no se puede convertir Persona en Animal */
            /* Este error es gracias a la genericidad acotada */
            //Animal a_ap_4 = Max4<Animal>(a, p);
            //Console.WriteLine($"a_ap_4 = {a_ap_4}");
        }
    }

    class Person : IComparable, IComparable<Person>, IComparable<Animal>
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public int CompareTo(object other)
        {
            Console.WriteLine($"Person.CompareTo(object {other})");
            if (other == null)
            {
                return 1;
            }

            Person pOther = other as Person;
            if (pOther != null)
            {
                return this.CompareTo(pOther);
            }

            Animal aOther = other as Animal;
            if (aOther != null)
            {
                return this.CompareTo(aOther);
            }

            throw new ArgumentException("Object is not a Person or Animal");
        }

        public int CompareTo(Person other)
        {
            Console.WriteLine($"Person.CompareTo(Person {other})");
            return Name.CompareTo(other.Name);
        }

        public int CompareTo(Animal other)
        {
            Console.WriteLine($"Person.CompareTo(Animal {other})");
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"<Person {Name}>";
        }
    }

    class Animal : IComparable, IComparable<Animal>, IComparable<Person>
    {
        public string Name { get; private set; }

        public Animal(string name)
        {
            Name = name;
        }

        public int CompareTo(object other)
        {
            Console.WriteLine($"Animal.CompareTo(object {other})");
            if (other == null)
            {
                return 1;
            }

            Animal aOther = other as Animal;
            if (aOther != null)
            {
                return this.CompareTo(aOther);
            }

            Person pOther = other as Person;
            if (pOther != null)
            {
                return this.CompareTo(pOther);
            }

            throw new ArgumentException("Object is not a Person or Animal");
        }

        public int CompareTo(Animal other)
        {
            Console.WriteLine($"Animal.CompareTo(Animal {other})");
            return Name.CompareTo(other.Name);
        }

        public int CompareTo(Person other)
        {
            Console.WriteLine($"Animal.CompareTo(Person {other})");
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"<Animal {Name}>";
        }
    }
}
