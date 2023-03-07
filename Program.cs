using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Encryptor
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Increase Console.ReadLine() limit
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));


            Console.Write("Encryption or Decryption (e/d): ");
            ConsoleKeyInfo mode = Console.ReadKey();

            Console.Write("\nText: ");
            string text = Console.ReadLine();

            Console.Write("Key: ");
            string key = Console.ReadLine();

            new Process(text, mode, key);

            Util.Pause();
        }
    }
}
