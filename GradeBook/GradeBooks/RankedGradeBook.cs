using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        private int CountSmallerGrades(List<Student> Students, double grade)
        {
            int result = 0;
            foreach (var student in Students)
            {
                if (student.AverageGrade <= grade) result++;
            }

            return result;
        }

        private int PercentCount(int total, int percent)
        {
            return (total * percent) / 100;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new System.InvalidOperationException();
            }

            int totalCount = Students.Count;
            int rank = CountSmallerGrades(Students, averageGrade);

            if (PercentCount(totalCount, 20) >= rank)
            {
                return 'A';
            }
            
            if (PercentCount(totalCount, 40) >= rank)
            {
                return 'B';
            }
            
            if (PercentCount(totalCount, 60) >= rank)
            {
                return 'C';
            }
            
            if (PercentCount(totalCount, 80) >= rank)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
