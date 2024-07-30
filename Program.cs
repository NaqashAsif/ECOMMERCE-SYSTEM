using EcommerceStore;
int attempt = 3;
Design design = new Design();
Product product = new Product();
Employee employee = new Employee();
Customer customer = new Customer();
mainmenu:
Console.Clear();
design.show();
int Moption = Menu.MainMenu();
if (Moption == 1)
{
    Console.Clear();
    design.show();
    int coption = customer.CustomerMenu();
    if (coption == 1)
        customer.Porder();
    else if (coption == 2)
        goto mainmenu;
    else if (coption == 3)
        Console.WriteLine("GOOD BYE!");
    else
        Console.WriteLine("INVALID INPUT!");
}
else if (Moption == 2)
    do
    {
        Console.Clear();
        design.show();
        string name = "", password = "";
        Console.Write("ENTER USER NAME: ");
        name = Console.ReadLine();
        Console.Write("ENTER PASSWORD: ");
        password = Console.ReadLine();
    adminmenu:
        Console.Clear();
        design.show();
        if (name == "naqash" && password == "5476")
        {
            attempt = 0;
            Console.Clear();
            design.show();
            int option = Menu.ShowMenu();
            switch (option)
            {
                case 1:
                    int employeemenu = employee.EmployeeMenu();
                    if (employeemenu == 1)
                    {
                        goto adminmenu;
                        break;
                    }
                    else if (employeemenu == 2)
                    {
                        goto mainmenu;
                        break;
                    }
                    else
                        break;
                case 2:
                    int productmenu = product.Productmenu();
                    if (productmenu == 1)
                    {
                        goto adminmenu;
                        break;
                    }
                    else if (productmenu == 2)
                    {
                        goto mainmenu;
                        break;
                    }
                    else
                        break;
                case 3:
                    Console.Clear();
                    design.show();
                    goto mainmenu;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("GOOD BYE.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("WRONG USER OR PASSWORD!");
            Console.WriteLine("REMAINING TRY: " + --attempt);
            Thread.Sleep(1000);
            Console.Clear();
            if (attempt == 0)
            {
                Console.WriteLine("WARNING!\nNEXT TIME ENTER CORRECT USER & PASSWORD. ");
            }
        }
    } while (attempt != 0);
else
    Console.WriteLine("GOOD BYE");


