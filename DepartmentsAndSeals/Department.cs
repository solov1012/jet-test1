using System;
using System.Collections.Generic;

namespace DepartmentsAndSeals
{
    public class Department
    {
        public List<int> lastVisitBlank = new List<int>(); // для проверки на бесконечный цикл
        public int whichtodep = 0; // для проверки на бесконечный цикл

        public int id;
        public bool isFirstDep = false;
        public bool isLastDep = false;
        public int add1;
        public int delete1;
        public int todep1;
        public int checkSeal = 0;
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
}
