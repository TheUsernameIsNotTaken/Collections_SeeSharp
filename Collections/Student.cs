using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Student: IComparable<Student>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Age { get; set; }

        public Student(string name, string code, int age)
        {
            Name = name;
            Code = code;
            Age = age;
        }

        public override string ToString()
        {
            return Name + "(" + Age + ")-" + Code;
        }

        public override int GetHashCode()
        {
            //Console.WriteLine("HashCode: " + this);
            return Name.Length;
        }

        public override bool Equals(object other)
        {
            //Console.WriteLine("Equals: " + this + " & " + other);
            return other is Student student &&
                   Code == student.Code;
        }

        public int CompareTo(Student other)
        {
            int dif = Name.CompareTo(other.Name);
            if (dif != 0) return dif;
            return Age.CompareTo(other.Age);
        }
    }

    class SortByCodeAndAge : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            int dif = x.Code.CompareTo(y.Code);
            if (dif != 0) return dif;
            return x.Age.CompareTo(y.Age);
        }
    }
}
