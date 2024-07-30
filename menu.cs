namespace EcommerceStore
{
    public class Menu
    {
        public static int MainMenu()
        {
            Console.Write("\t\tMAIN MENU\n" +
                              "SELECT OPTION FROM GIVEN BELOW:\n" +
                              "1:CUSTOMER\n" +
                              "2:ADMIN\n" +
                              "3:Quit\n" +
                              "ENTER OPTION: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int ShowMenu()
        {
            Console.Write("\t\tADMIN\n" +
                              "SELECT OPTION FROM GIVEN BELOW:\n" +
                              "1:EMPLOYEE\n" +
                              "2:PRODUCTS\n" +
                              "3:BACK TO MAIN MENU\n" +
                              "4:Quit\n" +
                              "ENTER OPTION: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
