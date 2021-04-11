using DepartmentsAndSeals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace jet_test1
{

    class Program
    {
        static void Main(string[] args)
        {
            Department d1 = new Department(1, 1, 2, 2, true, false);
            Department d2 = new Department(2, 2, 1, 1);
            Department d3 = new Department(3, 1, 2, 1, false, true);
            List<Department> deps = new List<Department>();
            deps.Add(d1); deps.Add(d2); deps.Add(d3);
            Blank blank = new Blank();
            List<Blank> blanks = blank.GetBlank(d1, deps, out string remark);
            Console.WriteLine(remark);
            foreach(var bl in blanks)
            {
                Console.WriteLine(bl.ToStr());
            }
        }
    }
}
