using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keygen
{
    internal class Util
    {
        public static void Error(Exception exception)
        {
            Console.Clear();

            Console.Error.WriteLine(exception.ToString());
            Console.Error.WriteLine("Usage: keygen.exe <length - int>");

            Environment.Exit(0);
        }
        public static void Copy(string output, bool inform = false)
        {
            if (inform)
            {
                Console.WriteLine("\n\nCopied to Clipboard");
            }

            Clipboard.SetText(output);
        }

    }
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Util.Error(new ArgumentException("Keygen.exe requires an argument."));
            }

            int keyLength = Convert.ToInt32(args[0]);

            string keyChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string key = "";
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                while (key.Length != keyLength)
                {
                    byte[] oneByte = new byte[1];
                    provider.GetBytes(oneByte);
                    char character = (char)oneByte[0];
                    if (keyChars.Contains(character))
                    {
                        key += character;
                    }
                }
            }

            Console.WriteLine("key: " + key);
            Util.Copy(key, true);
        }
    }
}
