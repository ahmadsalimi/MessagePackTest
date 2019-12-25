using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MessagePackTest.Models;
using MessagePack;

namespace MessagePackTest
{
    class Program
    {
        private const string DestinationPath = "../../../Results/";
        private const string FileName = "people.msgpack";

        static void Main()
        {
            if (!Directory.Exists(DestinationPath))
            {
                Directory.CreateDirectory(DestinationPath);
            }
            if (File.Exists(DestinationPath + FileName))
            {
                File.Delete(DestinationPath + FileName);
            }

            //var serializer = MessagePackSerializer.Get<University>();

            var sut = new University(
                "Sharif University of Technology",
                new List<IPerson>
                {
                    new Student(
                        "Reza", "Razavi", DateTime.Parse("10/13/1990"),
                        new List<Phone>
                        {
                            new Phone(09123456789, PhoneType.CellPhone),
                            new Phone(07612345678, PhoneType.Home)
                        }, Grade.BS, "Sharif University of Technology",
                        new List<object>
                        {
                            (short)10, (float)19.5, (float)17.75, (float)19.25, (short)20, (float)14.4, (float)13.3, (float)12.6, (float)10.75, (float)19.8
                        }
                    ),
                    new Person(
                        "Ali", "Alavi", DateTime.Parse("12/27/1973"),
                        new List<Phone>
                        {
                            new Phone(09173454389, PhoneType.CellPhone),
                            new Phone(07618547393, PhoneType.Work),
                            new Phone(07328584578, PhoneType.Home)
                        }
                    )
                }
            );

            Console.WriteLine($"Original object befor serializing:\n{sut}\n---------------------\n");

            //var output = File.AppendText(DestinationPath + FileName);

            Console.WriteLine("Serializing\n---------------------\n");
            //serializer.Pack(output.BaseStream, sut);
            //output.Flush();
            //output.Close();

            var rawSerialized = MessagePackSerializer.Serialize(sut);
            Console.WriteLine($"Raw serialized: {rawSerialized.Length} bytes\n{Encoding.ASCII.GetString(rawSerialized)}\n---------------------\n");


            var json = MessagePackSerializer.ConvertToJson(new ReadOnlyMemory<byte>(rawSerialized));
            Console.WriteLine($"json serialized: {Encoding.ASCII.GetBytes(json).Length} bytes\n{json}\n---------------------\n");


            //var input = File.OpenRead(DestinationPath + FileName);

            //var deserializedSut = serializer.Unpack(input);
            var deserializedSut = MessagePackSerializer.Deserialize(typeof(University), new ReadOnlyMemory<byte>(rawSerialized));
            Console.WriteLine($"deserialized object:\n{deserializedSut}\n---------------------\n");

            Console.ReadKey(true);
        }
    }
}
