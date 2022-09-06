using System;
using System.Text;
namespace TODO
{
    internal class Program
    {
        internal static Files file = new Files();
        internal static Check check = new Check();
        internal static UI ui = new UI();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            check.Start();

            ui.UserMenu();

            ui.Menu();
        }
    }
}
