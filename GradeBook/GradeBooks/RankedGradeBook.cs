using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        private int CountSmallerGrades(List<Student> Students, double grade)
        {
            int result = 0;
            foreach (var student in Students)
            {
                if (student.AverageGrade >= grade) result++;
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

            if (rank <= PercentCount(totalCount, 20))
            {
                return 'A';
            }
            
            if (rank <= PercentCount(totalCount, 40))
            {
                return 'B';
            }
            
            if (rank <= PercentCount(totalCount, 60))
            {
                return 'C';
            }
            
            if (rank <= PercentCount(totalCount, 80))
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
