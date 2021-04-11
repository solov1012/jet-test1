using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DepartmentsAndSeals
{
    public class Blank
    {
        List<int> seals = new List<int>();

        public Blank()
        {
        }

        public Blank(List<int> seals)
        {
            this.seals = seals;
        }

        public string ToStr()
        {
            string res = "";
            foreach (int seal in seals) res += seal + ", ";
            return res;
        }

        private Department Operations(Department department, List<Department> departments, int add, int delete, int todep)
        {
            Department todepResult = new Department();
            if (!seals.Contains(add)) seals.Add(add); // вынести в отдельный метод
            if (seals.Contains(delete)) seals.Remove(delete);
            foreach (var dep in departments)
            {
                if (dep.id == todep) { todepResult = dep; break; }
            }
            return todepResult;
        }

        public List<Blank> GetBlank(Department department, List<Department> departments, out string remark)
        {
            remark = "";
            List<Blank> blanks = new List<Blank>();
            Department chosenDep = new Department();
            int lastDepId = 0;
            foreach (var dep in departments)
            {
                if (dep.isFirstDep) { chosenDep = dep; }
                if (dep.isLastDep) lastDepId = dep.id;
            }
            while (true)
            {
                if (chosenDep.id == lastDepId) break;
                Department todep = new Department();
                if ((chosenDep.checkSeal != 0 && seals.Contains(chosenDep.checkSeal)) || chosenDep.checkSeal == 0)
                {
                    todep = Operations(chosenDep, departments, chosenDep.add1, chosenDep.delete1, chosenDep.todep1);
                }
                else
                {
                    todep = Operations(chosenDep, departments, chosenDep.add2, chosenDep.delete2, chosenDep.todep2);
                }
                if (chosenDep.lastVisitBlank.Except(seals).Count() == 0
                    && chosenDep.lastVisitBlank.Count == seals.Count
                    && chosenDep.whichtodep == todep.id)
                { remark += " Бесконечный цикл "; break; }
                chosenDep.lastVisitBlank.Clear();
                chosenDep.lastVisitBlank.AddRange(seals);
                chosenDep.whichtodep = todep.id;
                if (department.id == chosenDep.id)
                {
                    bool isUniqueSeals=true;
                    foreach (Blank bl in blanks)
                    {
                        if (bl.seals.Except(seals).Count() == 0 && bl.seals.Count == seals.Count) isUniqueSeals = false;
                    }
                    if (isUniqueSeals) blanks.Add(new Blank(new List<int>(seals)));
                }
                chosenDep = todep;
            }
            if (blanks.Count == 0) remark += " Ни разу не были в этом отделе ";
            return blanks;
        }
    }
}
