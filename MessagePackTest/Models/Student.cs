using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePackTest.Models
{
    [MessagePackObject]
    public class Student : Person
    {
        public Student(string name, string familyName, DateTime birthDay, List<Phone> phones, Grade grade, string schoolName) : base(name, familyName, birthDay, phones)
        {
            Grade = grade;
            UniversityName = schoolName;
        }

        [Key(4)]
        public Grade Grade { get; }
        [Key(5)]
        public string UniversityName { get; }

        public override string ToString()
        {
            return base.ToString() + $" - Grade: {Grade} - University: {UniversityName}";
        }
    }
}
