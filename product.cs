namespace EcommerceStore
{
    public class Product : Design
    {
        protected int Id { get; set; }
        private string Name { get; set; }
        protected double Price { get; set; }
        private string Description { get; set; }
        protected static List<Product> products;
        private Design design;
        static public int id = 1;
        static Product()
        {
            products = new List<Product>();
        }
        public Product()
        {
            design = new Design();
        }
        public int Productmenu()
        {

            bool check = true;
            string response;
            while (check)
            {
                Console.Clear();
                design.show();
                Console.Write("1:ADD PRODUCTS\n" +
                              "2:UPDATE PRODUCT\n" +
                              "3:REMOVE PRODUCT\n" +
                              "4:VIEW PRODUCT\n" +
                              "5:SEARCH PRODUCT\n" +
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
                            Product.AddProduct();
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
                            Product.UpdateProduct();
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
                            Product.RemoveProduct();
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
                            Product.ShowProduct();
                            Console.Write("DO YOU WANNA PROCEED PRESS Y/N: ");
                            response = Console.ReadLine();
                            if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                            {
                                check = false;
                            }
                            break;
                        }
                    case 5:
                        Console.Clear();
                        design.show();
                        Product.SearchProduct();
                        Console.Write("DO YOU WANNA PROCEED PRESS Y/N: ");
                        response = Console.ReadLine();
                        if (response.Equals("n", StringComparison.OrdinalIgnoreCase))
                        {
                            check = false;
                        }
                        break;
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
        private static string idFilePath = @"E:\currentId.txt";

        private static int GetNextId()
        {
            int currentId = 1; // Default ID if the file does not exist or is empty
            if (File.Exists(idFilePath))
            {
                string idContent = File.ReadAllText(idFilePath);
                if (int.TryParse(idContent, out int id))
                {
                    currentId = id;
                }
            }
            return currentId;
        }

        private static void UpdateId(int newId)
        {
            File.WriteAllText(idFilePath, newId.ToString());
        }

        protected static void AddProduct()
        {
            Console.Write("ENTER PRODUCT NAME: ");
            string name = Console.ReadLine();
            Console.Write("ENTER PRODUCT PRICE: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("ENTER PRODUCT DESCRIPTION: ");
            string description = Console.ReadLine();
            int id = GetNextId(); // Get the next ID
            Product newProduct = new Product { Id = id, Name = name, Price = price, Description = description };
            products.Add(newProduct);
            string path = @"E:\product.txt";
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                try
                {
                    sw.WriteLine($"{id},{name},{price},{description}");
                    Console.WriteLine("Product has been successfully added to file.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception happened: {ex.Message}");
                }
            }
            // Update the ID file for the next product
            UpdateId(id + 1);
        }

        protected static void UpdateProduct()
        {
            string originalFilePath = @"E:\product.txt";
            string tempFilePath = Path.Combine(Path.GetDirectoryName(originalFilePath), "tempfile.txt");
            Console.Write("ENTER PRODUCT ID TO UPDATE: ");
            string idToUpdate = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idToUpdate))
            {
                Console.WriteLine("Invalid ID. Please enter a valid product ID.");
                return;
            }

            try
            {
                // Check if the original file exists
                if (!File.Exists(originalFilePath))
                {
                    Console.WriteLine("Original file not found.");
                    return;
                }
                // Read the original file
                string[] lines = File.ReadAllLines(originalFilePath);
                // Write to the temporary file while filtering out the specific ID
                using (StreamWriter tempFile = new StreamWriter(tempFilePath))
                {
                    foreach (string line in lines)
                    {
                        // Assuming each line starts with the ID followed by a delimiter or space
                        if (line.StartsWith(idToUpdate))
                        {
                            Console.Write("ENTER PRODUCT NAME: ");
                            string name = Console.ReadLine();
                            Console.Write("ENTER PRODUCT PRICE: ");
                            double price = Convert.ToDouble(Console.ReadLine());
                            Console.Write("ENTER PRODUCT DESCRIPTION: ");
                            string description = Console.ReadLine();
                            tempFile.WriteLine(idToUpdate + (",") +
                                               name + (",") +
                                               price + (",") +
                                               description);
                        }
                        else
                            tempFile.WriteLine(line);
                    }
                }
                // Replace the original file with the temporary file
                File.Delete(originalFilePath);
                File.Move(tempFilePath, originalFilePath);

                Console.WriteLine("File updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        protected static void RemoveProduct()
        {
            string originalFilePath = @"E:\product.txt";
            string tempFilePath = Path.Combine(Path.GetDirectoryName(originalFilePath), "tempfile.txt");

            Console.Write("ENTER PRODUCT ID TO REMOVE: ");
            string idToRemove = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idToRemove))
            {
                Console.WriteLine("Invalid ID. Please enter a valid product ID.");
                return;
            }
            try
            {
                // Check if the original file exists
                if (!File.Exists(originalFilePath))
                {
                    Console.WriteLine("Original file not found.");
                    return;
                }
                // Read the original file
                string[] lines = File.ReadAllLines(originalFilePath);
                // Write to the temporary file while filtering out the specific ID
                using (StreamWriter tempFile = new StreamWriter(tempFilePath))
                {
                    foreach (string line in lines)
                    {
                        // Assuming each line starts with the ID followed by a delimiter or space
                        if (!line.StartsWith(idToRemove))
                        {
                            tempFile.WriteLine(line);
                        }
                    }
                }
                // Replace the original file with the temporary file
                File.Delete(originalFilePath);
                File.Move(tempFilePath, originalFilePath);

                Console.WriteLine("File updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        protected static void ShowProduct()
        {
            string filePath = @"E:\product.txt";
            if (filePath.Length == 0)
            {
                Console.WriteLine("The file is empty.");
            }
            else
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        Console.WriteLine("\t\tDISPLAYING ALL PRODUCTS");
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
        }
        protected double FetchPrice(int id)
        {
            double price = 0;
            // Find the item with the specified ID
            foreach (var Product in products)
            {
                if (Product.Price == id)
                {
                    price = Product.Price;
                }
            }
            return price;
        }
        protected static void SearchProduct()
        {
            Console.WriteLine("ENTER PRODUCT ID TO SHOW: ");
            id = Convert.ToInt32(Console.ReadLine());
            Product product = products.Find(p => p.Id == id);
            if (product != null)
                Console.WriteLine($"ID: {product.Id}, NAME: {product.Name}, PRICE: {product.Price},DESCRIPTION:{product.Description}");

            else
                Console.WriteLine("INVALID ID.");
        }
    }
}
