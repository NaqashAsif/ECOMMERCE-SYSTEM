using System;
using System.ComponentModel.Design;
namespace EcommerceStore
{
    public class Customer : Product, Idesign
    {
        Idesign des = new Design();
        Product productorder = new Product();
        public int CustomerMenu()
        {
            Console.Write("\t\tCUSTOMER MENU\n" +
                          "SELECT OPTION FROM GIVEN BELOW\n" +
                          "1:VIEW PRODUCTS & ORDER\n" +
                          "2:BACK TO MAIN MENU\n" +
                          "3:Quit\n" +
                          "ENTER OPTION: ");
            return (Convert.ToInt32(Console.ReadLine()));
        }
        public void Porder()
        {
            string filePath = @"E:\product.txt";
            Console.Clear();
            des.show();
            ShowProduct();
            Console.Write("WHICH THING YOU PUT IN CART CHOOSE BY ID: ");
            int idToFind = Convert.ToInt32(Console.ReadLine());
            try
            {
                string price = GetPriceById(filePath, idToFind);
                if (price != null)
                {
                    Console.WriteLine($"YOUR ORDER WITH PRODUCT ID {idToFind} IS BEING PROCESSEED TOTAL PRICE:{price}");
                }
                else
                {
                    Console.WriteLine("Product ID not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static string GetPriceById(string filePath, int id)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4 && int.TryParse(parts[0], out int currentId) && currentId == id)
                {
                    return parts[2];
                }
            }
            return null;
        }

    }
}
