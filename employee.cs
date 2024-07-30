namespace EcommerceStore
{
    public class Employee : Design
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double salary { get; set; }
        public string Designation { get; set; }

        private static List<Employee> employees;
        private Design design;
        static public int id = 1;
        static Employee()
        {
            employees = new List<Employee>();
        }
        public Employee()
        {
            design = new Design();
        }
        public int EmployeeMenu()
        {
            bool check = true;
            string response;
            Console.Clear();
            design.show();
            while (check)
            {
                Console.Clear();
                design.show();
                Console.Write("1:ADD EMPLOYEE\n" +
                              "2:UPDATE EMPLOYEE\n" +
                              "3:REMOVE EMPLOYEE\n" +
                              "4:VIEW EMPLOYEE\n" +
                              "5:SEARCH EMPLOYEE\n" +
                              "6:BACK TO ADMIN MENU\n" +
                              "7:BACK TO MAIN MENU\n" +
                              "8:QUIT\n" +
                              "ENTER OPTION:");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Console.Clear();
                            design.show();
                            Employee.AddEmployee();
                            Console.Write("DO YOU WANNA PROCEED PRESS Y/N: ");
                            response = Console.ReadLine();
                            if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                check = false;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            design.show();
                            Employee.UpdateEmployee();
                            Console.Write("DO YOU WANNA PROCEED PRESS Y/N: ");
                            response = Console.ReadLine();
                            if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                check = false;
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            design.show();
                            Employee.RemoveEmployee();
                            Console.Write("DO YOU WANNA PROCEED PRESS Y/N: ");
                            response = Console.ReadLine();
                            if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                check = false;
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            design.show();
                            Employee.ShowEmployee();
                            Console.Write("DO YOU WANNA PROCEED PRESS Y/N: ");
                            response = Console.ReadLine();
                            if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                check = false;
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            design.show();
                            Employee.SearchEmployee();
                            Console.Write("DO YOU WANNA PROCEED PRESS Y/N: ");
                            response = Console.ReadLine();
                            if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                check = false;
                            }
                            break;
                        }
                    case 6:
                        {
                            return 1;
                            break;
                        }
                    case 7:
                        {
                            return 2;
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("GOOD BYE.");
                            check = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("ENTER VALID OPTION.");
                            Thread.Sleep(1000);
                            break;
                        }
                }
                if (!check)
                {
                    Console.Clear();
                    Console.WriteLine("GOOD BYE.");
                }
            }
            return 0;
        }

        public static void AddEmployee()
        {
            Console.Write("ENTER EMPLOYEE NAME: ");
            string name = Console.ReadLine();
            Console.Write("ENTER EMPLOYEE SALARY: ");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("ENTER EMPLOYEE DESIGNATION: ");
            string designation = Console.ReadLine();
            employees.Add(new Employee { Id = id++, Name = name, salary = salary, Designation = designation });
            Console.WriteLine("ADDED SUCESSFULLY");
        }
        public static void UpdateEmployee()
        {
            Console.Write("ENTER EMPLOYEE ID TO UPDATE: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = employees.SingleOrDefault(p => p.Id == id);
            if (employee != null)
            {

                Console.Write("ENTER EMPLOYEE NAME: ");
                employee.Name = Console.ReadLine();
                Console.Write("ENTER EMPLOYEE SALARY: ");
                employee.salary = Convert.ToDouble(Console.ReadLine());
                Console.Write("ENTER EMPLOYEE DESIGNATION: ");
                employee.Designation = Console.ReadLine();
                Console.WriteLine("EMPLOYEE INFORMATION UPDATED SUCESSFULLY.");
            }
            else
            {

                Console.WriteLine("EMPLOYEE NOT FOUND.");
            }
        }
        public static void RemoveEmployee()
        {
            Console.WriteLine("ENTER EMPLOYEE ID TO REMOVE: ");
            id = Convert.ToInt32(Console.ReadLine());
            Employee employee = employees.SingleOrDefault(p => p.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("REMOVED SUCESSFULLY.");

            }
            else
                Console.WriteLine("INVALID ID.");
        }
        public static void ShowEmployee()
        {
            if (employees.Count == 0)
                Console.WriteLine("LIST IS EMPTY");
            else
            {
                Console.WriteLine("\t\tALL EMPLOYEES");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"ID: {employee.Id}, NAME: {employee.Name}, SALARY: {employee.salary},DESIGNATION:{employee.Designation}");
                }
            }
        }
        public static void SearchEmployee()
        {
            Console.WriteLine("ENTER EMPLOYEE ID TO SHOW: ");
            id = Convert.ToInt32(Console.ReadLine());
            Employee employee = employees.SingleOrDefault(p => p.Id == id);
            if (employee != null)
            {
                Console.WriteLine($"ID: {employee.Id}, NAME: {employee.Name}, SALARY: {employee.salary},DESIGNATION:{employee.Designation}");
            }
            else
                Console.WriteLine("INVALID ID.");
        }
    }
}