using System;
using System.Collections.Generic;
using System.Linq;

namespace jet_test1
{

    class Department
    {
        public List<int> lastVisitBlank = new List<int>(); // для проверки на бесконечный цикл

        public int id;
        public bool isFirstDep = false;
        public bool isLastDep = false;
        public int add1;
        public int delete1;
        public int todep1;
        public int checkSeal=0;
        public int add2;
        public int delete2;
        public int todep2;
        public Department(int id, int add1, int delete1, int todep1) // без условия
        {
            this.id = id;
            this.add1 = add1;
            this.delete1 = delete1;
            this.todep1 = todep1;
        }
        public Department(int id, int checkSeal, int add1, int delete1, int todep1, int add2, int delete2, int todep2) // с условием
        {
            this.id = id;
            this.checkSeal = checkSeal;
            this.add1 = add1;
            this.delete1 = delete1;
            this.todep1 = todep1;
            this.add2 = add2;
            this.delete2 = delete2;
            this.todep2 = todep2;
        }
        public Department(int id, int add1, int delete1, int todep1, bool isFirstDep, bool isLastDep) // - без условия
        {
            this.id = id;
            this.add1 = add1;
            this.delete1 = delete1;
            this.todep1 = todep1;
            this.isFirstDep = isFirstDep;
            this.isLastDep = isLastDep;
        }
        public Department(int id, int checkSeal, int add1, int delete1, int todep1, 
            int add2, int delete2, int todep2, bool isFirstDep, bool isLastDep) // с условием
        {
            this.id = id;
            this.checkSeal = checkSeal;
            this.add1 = add1;
            this.delete1 = delete1;
            this.todep1 = todep1;
            this.add2 = add2;
            this.delete2 = delete2;
            this.todep2 = todep2;
            this.isFirstDep = isFirstDep;
            this.isLastDep = isLastDep;
        }
        public Department()
        {
        }
    }

    class Blank
    {
        List<int> seals = new List<int>();

        public Blank()
        {
        }

        public Blank(List<int> seals)
        {
            this.seals = seals;
        }

        public List<Blank> GetBlank (Department department, List<Department> departments)
        {
            List<Blank> blanks = new List<Blank>();
            Department chosenDep = new Department();
            int lastDepId=0;
            foreach(var dep in departments)
            {
                if (dep.isFirstDep) { chosenDep = dep; }
                if (dep.isLastDep) lastDepId = dep.id;
            }
            while (true)
            {
                if (chosenDep.id == lastDepId) break;
                Department todep=new Department();
                if ((chosenDep.checkSeal != 0 && seals.Contains(chosenDep.checkSeal)) || chosenDep.checkSeal==0)
                {
                    if (!seals.Contains(chosenDep.add1)) seals.Add(chosenDep.add1); // вынести в отдельный метод
                    if (seals.Contains(chosenDep.delete1)) seals.Remove(chosenDep.delete1);
                    foreach (var dep in departments)
                    {
                        if (dep.id == chosenDep.todep1) { todep = dep; break; }
                    }
                }
                else
                {
                    if (!seals.Contains(chosenDep.add2)) seals.Add(chosenDep.add2);
                    if (seals.Contains(chosenDep.delete2)) seals.Remove(chosenDep.delete2);
                    foreach (var dep in departments)
                    {
                        if (dep.id == chosenDep.todep1) { todep = dep; break; }
                    }
                }
                if (chosenDep.lastVisitBlank.Except(seals).Count() == 0 && chosenDep.lastVisitBlank.Count() == seals.Count())
                    { Console.WriteLine("бесконечный цикл"); break; }
                chosenDep.lastVisitBlank.Clear();
                chosenDep.lastVisitBlank.AddRange(seals);
                if (department.id == chosenDep.id) blanks.Add(new Blank(seals));
                chosenDep = todep;
            }
            if (blanks.Count == 0) Console.WriteLine("Ни разу не были в этом отделе");
            return blanks;
        }
    }

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
            List<Blank> blanks = blank.GetBlank(d1, deps);
            Console.WriteLine("Hello World!");
        }
    }
}
