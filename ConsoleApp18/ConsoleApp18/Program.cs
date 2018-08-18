using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            if (File.Exists("key.bin") && File.Exists("iv.bin"))
            {
                rijn.Key = File.ReadAllBytes("key.bin");
                rijn.IV = File.ReadAllBytes("iv.bin");
                var fin = File.Open("cipher.bin", FileMode.Open);
                CryptoStream decStream = new CryptoStream(fin, rijn.CreateDecryptor(rijn.Key, rijn.IV), CryptoStreamMode.Read);
                byte[] clearTextBytes = new byte[256];
                decStream.Read(clearTextBytes, 0, 256);
                fin.Close();
                Console.WriteLine(Encoding.UTF8.GetString(clearTextBytes));
                var f = File.CreateText("out.txt");
                    f.WriteLine(Encoding.UTF8.GetString(clearTextBytes));
                f.Close();
                Console.ReadLine();
            }
            else
            {
                File.Create("Key.bin").Write(rijn.Key, 0, rijn.Key.Length);
                File.Create("iv.bin").Write(rijn.IV, 0, rijn.IV.Length);
            }
            string s = " 英 衛 詠 鋭 液 疫 益 駅 悦 謁 越 閲 榎 厭";
            Stream fout = File.Create("cipher.bin");
            CryptoStream encStream = new CryptoStream(fout, rijn.CreateEncryptor(rijn.Key, rijn.IV), CryptoStreamMode.Write);
            encStream.Write(Encoding.UTF8.GetBytes(s), 0, Encoding.UTF8.GetBytes(s).Length);
            encStream.Close();



        }
    }
}
