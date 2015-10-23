using System;
using System.Diagnostics;
using System.IO;
using JsonFx;
using Records.Initialization;

namespace BinaryJSON
{
    class Program
    {
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
