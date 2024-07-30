using System.ComponentModel.Design;
using System.Text;
namespace EcommerceStore
{
    public class Design : Idesign
    {
        public void show()
        {
            StringBuilder headerdesign = new StringBuilder();
            headerdesign
                        .Append('-', 120)
                        .AppendLine()
                        .Append(' ', 45)
                        .Append("WELCOME TO E-COMMERCE SYSTEM SOFTWARE")
                        .Append(' ', 45)
                        .AppendLine()
                        .Append('-', 120);
            Console.WriteLine(headerdesign);
        }

    }
}
