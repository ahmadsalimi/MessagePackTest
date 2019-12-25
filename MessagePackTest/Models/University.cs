using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePackTest.Models
{
    [MessagePackObject]
    public class University
    {
        [Key(0)]
        public string Name { get; }
        [Key(1)]
        public List<IPerson> People { get; }

        public University(string name, List<IPerson> people)
        {
            Name = name;
            People = people;
        }

        public override string ToString()
        {
            return $"UnivarsityName: {Name} - People: {People.MakeString()}";
        }
    }
}
