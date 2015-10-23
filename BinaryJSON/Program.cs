using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using JsonFx;
using Records.Initialization;

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
            var str = File.ReadAllText("initializationFile.txt");

            var initialization = JsonReader.Deserialize<InitializationRecord>(str);
            var bytes = BinaryJSON.Write(initialization);

            var result = BinaryJSON.Read<InitializationRecord>(bytes);

            var json = JsonWriter.Serialize(result);
            var bjson = JsonWriter.Serialize(initialization);

            var eq = json == bjson;

            var jsonStart = Stopwatch.GetTimestamp();
            JsonReader.Deserialize<InitializationRecord>(str);
            var jsonEnd = Stopwatch.GetTimestamp();
            var bsonStart = Stopwatch.GetTimestamp();
            BinaryJSON.Read<InitializationRecord>(bytes);
            var bsonEnd = Stopwatch.GetTimestamp();

            Console.WriteLine("JSON:" + (jsonEnd - jsonStart));
            Console.WriteLine("BJSON:" + (bsonEnd - bsonStart));

            Console.ReadKey();
        }
    }
}
