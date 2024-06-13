using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Layer_Encryptor
{
    internal class Process
    {
        private class Encryption
        {
            private string output;

            private static string Stage1(string str, string key)
            { 
                return Util.XOR(str, key);
                //return Util.StringToHex(str);
            }
            private static string Stage2(string str)
            {
                return Util.StringToHex(str);
            }
            private static string Stage3(string str)
            {
                return Util.Base64Encode(str);
            }
            public Encryption(string[] data)
            {
                output = Stage3(
                    Stage2(
                        Stage1(data[0], data[1])
                    )
                );
            }
            public string GetOutput()
            {
                return output;
            }
        }
        private class Decryption
        {
            private string output;

            private static string Stage1(string str)
            {
                return Util.Base64Decode(str);
            }
            private static string Stage2(string str)
            {
                return Util.HexToString(str);
            }
            private static string Stage3(string str, string key)
            {
                return Util.XOR(str, key);
                //return Util.HexToString(str);
            }
            public Decryption(string[] data)
            {
                this.output = Stage3(
                    Stage2(
                        Stage1(data[0])
                    ), data[1]
                );
            }
            public string GetOutput()
            {
                return output;
            }
        }
        public Process(string str, ConsoleKeyInfo mode, string key)
        {

            string[] data = { str, key };

            string output = "";

            if (mode.Key == ConsoleKey.E)
            {
                Encryption e = new Encryption(data);
                output = e.GetOutput();

                Util.Copy(output, true);
            } else {
                Decryption d =  new Decryption(data);
                output = d.GetOutput();

                Console.WriteLine(output);

                Console.Write("\nWould you like to Copy? (y|N): ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Util.Copy(output);
                }
            }
        }
    }
}
