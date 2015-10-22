using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryJSON
{
    class Program
    {
        public class A
        {
            public int i = 10;
            public int j = 11;
            public string s = "hello";
            public A a;
            public string q = null;
            public byte[] b = { 1, 2, 3 };
            public string[] bs = { "s", "d" };
            public List<string> ls = new List<string>() { "ls", "ld" };
        }
        static void Main(string[] args)
        {
            var result = BinaryJSON.Serialization.BinaryJSON.Write(new A { i = 11, j = 12, s = "bb", a = new A() { q = "hello", b = new byte[] { 9, 8 } }, b = new byte[] { 5, 6 }, ls = new List<string>() { "GGG" } });
            //var result = BinaryJSON.Serialization.BinaryJSON.Write(new List<string>() { "GGG" });

            Console.WriteLine(result);

            var value = Serialization.BinaryJSON.Read<A>(result);
            Console.ReadKey();
        }
    }
}
