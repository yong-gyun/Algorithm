using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise
{
    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }

        public int CompareTo(Knight? other)
        {
            if (Id == other.Id)
                return 0;

            return Id > other.Id ? 1 : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}