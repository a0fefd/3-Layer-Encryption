using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Encryptor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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
