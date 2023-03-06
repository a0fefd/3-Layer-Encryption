using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Encryptor
{
    internal class Util
    {
        private static bool StringContains(string str, string[] strings)
        {
            for (int i = 0; i < strings.Length-1; i++)
            {
                if (str.Contains(strings[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private static Byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        public static string Base64Encode(string str)
        {
            return Convert.ToBase64String(
                Encoding.UTF7.GetBytes(str)
            );
        }
        public static string Base64Decode(string str)
        { 
            return Encoding.UTF7.GetString(
                Convert.FromBase64String(str)
            );
        }
        public static String StringToBinary(string str)
        {
            Byte[] data = ConvertToByteArray(str, Encoding.ASCII);

            return string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
        public static String StringToHex(string str)
        {
            Byte[] data = ConvertToByteArray(str, Encoding.ASCII);

            return string.Join("", data.Select(byt => Convert.ToString(byt, 16).PadLeft(2, '0')));
        }
        public static String BinaryToString(string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i += 8)
            {
                string subStr = str.Substring(i, 8);
                sb.Append(Convert.ToChar(Convert.ToUInt32(subStr, 2)));
            }
            return sb.ToString();
        }
        public static String HexToString(string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i += 2)
            {
                string subStr = str.Substring(i, 2);
                sb.Append(Convert.ToChar(Convert.ToUInt32(subStr, 16)));
            }
            return sb.ToString();
        }
        public static void Pause()
        {
            Console.Write("\nPress Enter to continue...");
            Console.Read();
        }
    }
}
