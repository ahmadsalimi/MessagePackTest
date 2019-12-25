using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePackTest.Models
{
    public class Student : Person
    {
        public Student(string name, string familyName, DateTime birthDay, List<object> phones, Grade grade, string schoolName) : base(name, familyName, birthDay, phones)
        {
            Grade = grade;
            UniversityName = schoolName;
        }

        public Grade Grade { get; }
        public string UniversityName { get; }

        public override string ToString()
        {
            return base.ToString() + $" - Grade: {Grade} - University: {UniversityName}";
        }
    }
}
