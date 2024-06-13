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
        static readonly long buffer = (long)Math.Pow(2, 16);
        [STAThread]
        static void Main(string[] args)
        {
            Console.Clear();

            // Increase Console.ReadLine() limit
            byte[] inputBuffer = new byte[buffer];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            
            ConsoleKeyInfo mode;
            string text;
            string key;
            
            Console.Write("Session Key: ");
            key = Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < 1000; i++) {
                Console.Write("Encryption or Decryption (e/d) [CTRL+C to exit]: ");
                mode = Console.ReadKey();

                Console.Write("\nText: ");
                if (i > 0) {
                    Console.ReadLine();
                }
                text = Console.ReadLine();

                Console.WriteLine(" ");
                Console.WriteLine("## Output ##");

                new Process(text, mode, key);

                Util.Pause();
                Console.Clear();
            }
        }
    }
}
