using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = "AlexBG";
            string res = Utils.KeySecrets.Encrypt(txt);
            Console.WriteLine(res);

            string dec = Utils.KeySecrets.Decrypt(res);
            Console.WriteLine(dec);
        }
    }
}
