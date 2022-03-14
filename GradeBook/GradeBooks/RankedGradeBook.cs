using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            double N = Students.Count * 0.2;
            int counter = 0;
            if (Students.Count < 5)
                throw new InvalidOperationException();

            foreach (var student in Students)
            {
                if (averageGrade >= student.AverageGrade)
                {
                    counter++;
                }
            }

            if (counter > Students.Count - N)
                return 'A';
            else if (counter > Students.Count - 2 * N)
                return 'B';
            else if (counter > Students.Count - 3 * N)
                return 'C';
            else if (counter > Students.Count - 4 * N)
                return 'D';
            else
                return 'F';

        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else
                base.CalculateStatistics();

        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else
                base.CalculateStudentStatistics(name);

        }

    }
}
