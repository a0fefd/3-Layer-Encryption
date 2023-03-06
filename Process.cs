using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _3_Layer_Encryptor
{
    internal class Process
    {
        private class Encryption
        {
            private static string Stage1(string str, string key)
            { 
                return Util.XOR(str, key);
                //return Util.StringToHex(str);
            }
            private static string Stage2(string str)
            {
                return Util.StringToBinary(str);
            }
            private static string Stage3(string str)
            {
                return Util.Base64Encode(str);
            }
            public Encryption(string str, string key)
            {
                Console.WriteLine(
                    Stage3(
                        Stage2(
                            Stage1(str, key)
                        )
                    )
                );
            }
        }
        private class Decryption
        {
            private static string Stage1(string str)
            {
                return Util.Base64Decode(str);
            }
            private static string Stage2(string str)
            {
                return Util.BinaryToString(str);
            }
            private static string Stage3(string str, string key)
            {
                return Util.XOR(str, key);
                //return Util.HexToString(str);
            }
            public Decryption(string str, string key)
            {
                Console.WriteLine(
                    Stage3(
                        Stage2(
                            Stage1(str)
                        ), key
                    )
                );
            }
        }

        public Process(string str, string mode, string key)
        {
            if (mode.ToLower() == "e")
            {
                new Encryption(str, key);
            } else
            {
                new Decryption(str, key);
            }
            
        }
    }
}
