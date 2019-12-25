using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePackTest.Models
{
    [MessagePackObject]
    public class Person
    {
        [Key(0)]
        public string Name { get; }
        [Key(1)]
        public string FamilyName { get; }
        [Key(2)]
        public DateTime BirthDay { get; }
        [Key(3)]
        public List<object> Phones { get; } = new List<object>();

        public Person(string name, string familyName, DateTime birthDay, List<object> phones)
        {
            Name = name;
            FamilyName = familyName;
            BirthDay = birthDay;
            Phones = phones;
        }

        public override string ToString()
        {
            return $"{Name} {FamilyName} - BirthDay: {BirthDay.ToString()} - Phones: {Phones.MakeString()}";
        }
    }
}
