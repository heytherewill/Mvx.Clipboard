using System;
using Clipboard;
using Clipboard.Wpf;

namespace Client.Windows
{
    class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {
            IClipboardService service = new ClipboardService();
            
            service.CopyToClipboard("Hello, you're testing the Clipboard plugin for MvvmCross.");

            Console.WriteLine("Text copied, try to paste the clipboard in this window (valid the input with Enter):");
            var pastedText = Console.ReadLine();

            var value = service.ReadFromClipboard();
            Console.WriteLine("Read value from your manual paste : " + value);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Read value from clipboard : " + value);

            Console.WriteLine("");
            Console.WriteLine("");

            if (value.Equals(pastedText))
                Console.WriteLine("OK - All is good !");
            else
                Console.WriteLine("An error occured ... retry ?");

            Console.ReadLine();
        }
    }
}
