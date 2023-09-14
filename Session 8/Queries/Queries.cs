using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    class Query {

        private Model model = new Model();

        private static void Show<T>(IEnumerable<T> collection) {
            foreach (var item in collection) {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
        }

        static void Main(string[] args) {
            Query query = new Query();
            Console.WriteLine("CLASS QUERIES:\nQuery 1:");
            query.Query1();
            Console.WriteLine("-----------------------------\nQuery 2:");
            query.Query2();
            Console.WriteLine("-----------------------------\nQuery 3:");
            query.Query3();
            Console.WriteLine("-----------------------------\nQuery 4:");
            query.Query4();
            Console.WriteLine("-----------------------------\nQuery 5:");
            query.Query5();
            Console.WriteLine("-----------------------------\nQuery 6:");
            query.Query6();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("HOMEWORK QUERIES:\nHomework1:");
            query.Homework1();
            Console.WriteLine("\nHomework2:");
            query.Homework2();
            Console.WriteLine("\nHomework3:");
            query.Homework3();
            Console.WriteLine("\nHomework4:");
            query.Homework4();
            Console.WriteLine("\nHomework5:");
            query.Homework5();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("EXTRA QUERIES\nExtraQuery1:");
            query.ExtraQuery1();
        }

        private void Query1() {
            // Modify this query to show the names of the employees older than 50 years
            var employees = model.Employees.Where(e => e.Age>50).Select(e => $"--Name: {e.Name}");
            Console.WriteLine("Employees:");
            Show(employees);
        }

        private void Query2() {
            // Show the name and email of the employees who work in Asturias

            //CON TIPO STRING
            var employees = model.Employees.Where(e => e.Province.ToLower().Equals("asturias")).Select(e => $"--Name: {e.Name}, Email: {e.Email}");

            //CON TIPOS ANÓNIMOS
            //var employees = model.Employees.Where(e => e.Province.ToLower().Equals("asturias")).Select(e => new
            //{
            //    e.Name,
            //    e.Email,
            //});

            //CON INSTANCIAS DE CLASES
            //var employees = model.Employees.Where(e => e.Province.ToLower().Equals("asturias")).Select(e => new NameAndEmail
            //{
            //    Name = e.Name,
            //    Email = e.Email,
            //});

            //CON TUPLAS
            //var employees = model.Employees.Where(e => e.Province.ToLower().Equals("asturias")).Select(e => (e.Name, e.Email));
            Console.WriteLine("Employees:");
            Show(employees);
        }

        /// <summary>
        /// Clase NameAndEmail
        /// </summary>
        internal class NameAndEmail
        {
            /// <summary>
            /// Propiedad Name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Propiedad Email
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// Método ToString
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return $"--Name: {Name}, Email: {Email}";
            }
        }

        // Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx

        private void Query3() {
            // Show the names of the departments with more than one employee 18 years old and beyond; 
            // the department should also have any office number starting with "2.1"

            //CON 2 WHERE
            var departments = model.Departments.Where(d => d.Employees.Count(e => e.Age>=18) >= 1)
                                                .Where(d => d.Employees.Any(e => e.Office.Number.StartsWith("2.1")))
                                                .Select(d => $"--Department: {d.Name}");

            //CON UN ÚNICO WHERE
            //var departments = model.Departments.Where(d => d.Employees.Count(e => e.Age>=18) >= 1 && d.Employees.Any(e => e.Office.Number.StartsWith("2.1")))
            //                                   .Select(d => $"Department: {d.Name}");
            Console.WriteLine("Departments:");
            Show(departments);
        }

        private void Query4() {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.

            //CON JOIN
            var phoneCalls = model.PhoneCalls.Join(model.Employees, p => p.SourceNumber, e => e.TelephoneNumber, (p, e) => new
                                                {
                                                    Employee = e.Name,
                                                    Duration = p.Seconds
                                                }).Select(value => $"--Name: {value.Employee}, Duration: {value.Duration}");

            //CON WHERE Y TIPOS ANÓNIMOS
            //var phoneCalls = model.PhoneCalls.Where(p => model.Employees.Any(e => e.TelephoneNumber == p.SourceNumber))
            //                                    .Select(value => new
            //                                    {
            //                                        Employee = model.Employees.First(e => e.TelephoneNumber == value.SourceNumber).Name,
            //                                        Duration = value.Seconds
            //                                    }).Select(value => $"Name: {value.Employee}, Duration: {value.Duration}");

            //CON SELECTMANY
            //var phoneCalls = model.Employees.SelectMany(e => model.PhoneCalls.Where(p => p.SourceNumber == e.TelephoneNumber))
            //                                .Select(value => new
            //                                {
            //                                    Employee = model.Employees.First(e => e.TelephoneNumber == value.SourceNumber).Name,
            //                                    Duration = value.Seconds
            //                                }).Select(value => $"Name: {value.Employee}, Duration: {value.Duration}");
            Console.WriteLine("PhoneCalls:");
            Show(phoneCalls);
        }

        private void Query5() {
            // Show, grouped by each province, the name of the employees 
            // (both province and employees must be lexicographically ordered)
            var provinceEmployee = model.Employees.OrderBy(e => e.Name)
                                                    .GroupBy(e => e.Province)
                                                    .OrderBy(g => g.Key);
            int number = 0;
            Console.WriteLine("Provinces:");
            foreach (var province in provinceEmployee)
            {
                number++;
                Console.WriteLine($"--Employees of {province.Key}:");                
                foreach (var employee in province)
                {
                    number++;
                    Console.WriteLine($"  -->Name: {employee.Name}");
                }
            }
            Console.WriteLine("Number of items in the collection: {0}.", number);
        }

        private void Query6()
        {
            //Show phone calls sort by duration and ranking
            var phoneCalls = model.PhoneCalls.OrderByDescending(p => p.Seconds)
                                            .Zip(Enumerable.Range(1, model.PhoneCalls.Count() + 1), (p, r) => $"--Rank: {r}º, ({p.Seconds}), from {p.SourceNumber} to {p.DestinationNumber}");
            
            Console.WriteLine("PhoneCalls:");
            Show(phoneCalls);
        }

            /************ Homework **********************************/

        private void Homework1() {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute

            var employees = model.Employees.OrderBy(e => e.Age)
                                           .Where(e => e.Department.Name.ToLower().Equals("computer science"))
                                           .Where(e => e.Office.Building.ToLower().Equals("faculty of science"))
                                           .Join(model.PhoneCalls.Where(p => p.Seconds >= 60), e => e.TelephoneNumber, p => p.SourceNumber, (e,p) => new
                                           {
                                               e.Name
                                           }).Select(value => $"--Name: {value.Name}");
            Console.WriteLine("Employees:");
            Show(employees);
        }

        private void Homework2() {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
            var totalSeconds = model.Employees.Where(e => e.Department.Name.ToLower().Equals("computer science"))
                                              .Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new 
                                              {
                                                  Duration = p.Seconds
                                              }).Aggregate(0, (acum, value) => acum + value.Duration);
            Console.WriteLine($"Total seconds of calls: {totalSeconds}");
        }

        private void Homework3() {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”
            var departments = model.Departments.OrderBy(d => d.Name)
                                               .SelectMany(d => d.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new
                                               {
                                                   Name = e.Department.Name,
                                                   Duration = p.Seconds
                                               }).Aggregate(new Dictionary<string, int>(), (acum, value) =>
                                               {
                                                   if (acum.ContainsKey(value.Name))
                                                   {
                                                       acum[value.Name]+=value.Duration;
                                                   }
                                                   else
                                                   {
                                                       acum[value.Name] = value.Duration;
                                                   }
                                                   return acum;
                                               }).Select(x => new
                                               {
                                                   Name = x.Key,
                                                   Duration = x.Value
                                               }).Select(x => $"--Name: {x.Name}, Duration: {x.Duration}"));
            Console.WriteLine("Departments");
            Show(departments);
        }

        private void Homework4()
        {
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)
            var departments = model.Departments.OrderBy(d => d.Name)
                                               .GroupJoin(model.Employees, d => d.Name, e => e.Department.Name, (d, e) => new
                                               {
                                                   DName = d.Name,
                                                   EName = e.First(e1 => e1.Age.Equals(e.Min(e2 => e2.Age))).Name,
                                                   MinAge = e.Min(e1 => e1.Age),
                                               }).Select(value => $"--DepartmentName: {value.DName}, EmployeeName: {value.EName}, Age: {value.MinAge}");
            Console.WriteLine("Departments:");
            Show(departments);
        }

        private void Homework5() {
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)

            var greatestSummation = model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new
            {
                DepartmentName = e.Department.Name,
                PartialDuration = p.Seconds
            }).Aggregate(new Dictionary<string, int>(), (acum, value) =>
            {
                if (acum.ContainsKey(value.DepartmentName))
                {
                    acum[value.DepartmentName]+=value.PartialDuration;
                }
                else
                {
                    acum[value.DepartmentName] = value.PartialDuration;
                }
                return acum;
            }).Aggregate(("", 0), (acum, value) =>
            {
                if (value.Value > acum.Item2)
                {
                    acum.Item1 = value.Key;
                    acum.Item2 = value.Value;                    
                }
                return acum;
            });
            Console.WriteLine($"--The greatest summation is from department {greatestSummation.Item1}, and the value is {greatestSummation.Item2}");
        }

            /************ Extra **********************************/

        private void ExtraQuery1()
        {
            //Show the name of the employees along with the total time that the employee has been calling someone
            //var employeesTalking = model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, p => p.SourceNumber, (e, p) => new
            //{
            //    Employee = e.Name,
            //    Duration = p.Seconds
            //}).Aggregate(new Dictionary<string, int>(), (acum, value) =>
            //{
            //    if (acum.ContainsKey(value.Employee))
            //    {
            //        acum[value.Employee]+=value.Duration;
            //    } else
            //    {
            //        acum[value.Employee]=value.Duration;
            //    }
            //    return acum;
            //}).Select(x => $"--Name: {x.Key}, Duration: {x.Value}");
            var employeesTalking = model.Employees.Join(model.PhoneCalls, e => (e.TelephoneNumber, default), p => (p.SourceNumber, p.DestinationNumber), (e, p) => new
            {
                Employee = e.Name,
                Duration = p.Seconds
            }, new NumberComparer()).Aggregate(new Dictionary<string, int>(), (acum, value) =>
            {
                if (acum.ContainsKey(value.Employee))
                {
                    acum[value.Employee]+=value.Duration;
                }
                else
                {
                    acum[value.Employee]=value.Duration;
                }
                return acum;
            }).Select(x => $"--Name: {x.Key}, Duration: {x.Value}");
            Console.WriteLine("Employees:");
            Show(employeesTalking);
        }
    }

    /// <summary>
    /// Método NumberComparer
    /// </summary>
    class NumberComparer : IEqualityComparer<(string, string)>
    {
        /// <summary>
        /// Método Equals
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals((string, string) x,(string, string) y)
        {
            int numberx1 = Convert.ToInt32(x.Item1.Replace(" ", ""));
            int numbery1 = Convert.ToInt32(y.Item1.Replace(" ", ""));
            int numbery2 = Convert.ToInt32(y.Item2.Replace(" ", ""));
            return numberx1.Equals(numbery1) || numberx1.Equals(numbery2);
        }

        /// <summary>
        /// Método GetHashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode((string, string) obj)
        {
            return 0;
        }
    }

    //class NumberComparer : IEqualityComparer<object>
    //{
    //    public new bool Equals(object x, object y)
    //    {
    //        Employee emp = x as Employee;
    //        PhoneCall pc = null;
    //        if (emp == null) {
    //            emp = y as Employee;
    //        } else {
    //            pc = y as PhoneCall;
    //        }
    //        if (emp == null)
    //        {
    //            return false;
    //        }
    //        if (pc == null)
    //        {
    //            pc = x as PhoneCall;
    //        }
    //        if (pc == null)
    //        {
    //            return false;
    //        }
    //        //Console.WriteLine(emp.Name);
    //        //Console.WriteLine(pc.SourceNumber);
    //        //Console.WriteLine(pc.DestinationNumber);
    //        return emp.TelephoneNumber.Equals(pc.SourceNumber) || emp.TelephoneNumber.Equals(pc.DestinationNumber);
    //    }

    //    public int GetHashCode(object obj)
    //    {
    //        return obj.GetHashCode();
    //    }
    //}
}
