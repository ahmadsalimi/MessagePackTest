using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace MessagePackTest.Models
{
    [MessagePackObject]
    public class Phone
    {
        [Key(0)]
        public long Number { get; }
        [Key(1)]
        public PhoneType Type { get; }

        public Phone(long number, PhoneType type)
        {
            Number = number;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Number}({Type})";
        }
    }
}
