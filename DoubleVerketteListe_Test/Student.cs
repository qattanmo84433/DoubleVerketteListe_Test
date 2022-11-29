using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVerketteListe_Test
{
    public class Student : IComparable
    {
        public string name { get; }
        public Student(string name)
        {
            this.name = name;
        }

        public int CompareTo(object obj)
        {
            Student temp = (Student)obj;
            return this.name.CompareTo(temp.name);
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
