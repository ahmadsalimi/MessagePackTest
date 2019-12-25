using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsgPack;
using System.Diagnostics;
using MsgPack.Serialization;
using MessagePackTest.Models;

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

            var personSerializer = MessagePackSerializer.Get<Person>();
            var studentSerializer = MessagePackSerializer.Get<Student>();

            var rezaRazavi = new Student(
                "Reza", "Razavi", DateTime.Parse("10/13/1990"),
                new List<object>
                {
                    new Phone("09123456789", PhoneType.CellPhone),
                    new Phone("07612345678", PhoneType.Home)
                }, Grade.BS, "Sharif University of Technology"
            );

            Console.WriteLine($"Original object befor serializing:\n{rezaRazavi}\n---------------------\n");

            var output = File.AppendText(DestinationPath + FileName);


            Console.WriteLine("Serializing student as person\n---------------------\n");
            personSerializer.Pack(output.BaseStream, rezaRazavi);
            Console.WriteLine("Serializing student as student\n---------------------\n");
            studentSerializer.Pack(output.BaseStream, rezaRazavi);
            output.Flush();
            output.Close();

            var input = File.OpenRead(DestinationPath + FileName);

            var deserializedPerson = personSerializer.Unpack(input);
            Console.WriteLine($"deserialized Person as Person:\n{deserializedPerson}\n---------------------\n");

            try
            {
                var deserializedStudentAsPerson = personSerializer.Unpack(input);
                Console.WriteLine($"deserialized Student as Person:\n{deserializedStudentAsPerson}\n---------------------\n");
            }
            catch
            {
                Console.WriteLine("Error in deserializing student object as person.\n---------------------\n");
            }

            input.Seek(0, SeekOrigin.Begin);
            personSerializer.Unpack(input);

            var deserializedStudent = studentSerializer.Unpack(input);
            Console.WriteLine($"deserialized Student as Student:\n{deserializedStudent}\n---------------------\n");

            Console.ReadKey(true);
        }
    }
}
