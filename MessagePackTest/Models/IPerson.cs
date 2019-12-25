using MessagePack;

namespace MessagePackTest.Models
{
    [Union(0, typeof(Person))]
    [Union(1, typeof(Student))]
    public interface IPerson
    {
    }
}
