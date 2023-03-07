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
        static void Main(string[] args)
        {
            // Increase Console.ReadLine() limit
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));


            Console.Write("Encryption or Decryption (e/d): ");
            string mode = Console.ReadLine();

            Console.Write("Text: ");
            string text = Console.ReadLine();

            Console.Write("Key: ");
            string key = Console.ReadLine();

            new Process(text, mode, key);

            Util.Pause();
        }
    }
}
