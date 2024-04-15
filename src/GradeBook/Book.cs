namespace GradeBook
{
    public class Book
    {
        private List<double> grades;

        public string Name;

        public event GradeAddedDelegate? GradeAdded;

        public Book(string name)
        {
            grades = [];
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);

                if (GradeAdded is not null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        private static void ComputeLetterGrade(Statistics statistics)
        {
            switch (statistics.Average)
            {
                case var d when d >= 90:
                    statistics.Letter = 'A';
                    break;

                case var d when d >= 80:
                    statistics.Letter = 'B';
                    break;

                case var d when d >= 70:
                    statistics.Letter = 'C';
                    break;

                case var d when d >= 60:
                    statistics.Letter = 'D';
                    break;

                default:
                    statistics.Letter = 'F';
                    break;
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics
            {
                Average = 0.0,
                High = double.MinValue,
                Low = double.MaxValue
            };
            foreach (var grade in grades)
            {
                result.Average += grade;

                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
            }

            result.Average /= grades.Count;

            ComputeLetterGrade(result);

            return result;
        }

        public void ShowStatistics()
        {
            var stats = GetStatistics();
            if (grades.Count > 0)
            {
                Console.WriteLine($"The statistics for {Name} are:");
                Console.WriteLine($"The average grade is {stats.Average:N1}");
                Console.WriteLine($"The highest grade is {stats.High}");
                Console.WriteLine($"The lowest grade is {stats.Low}");
                Console.WriteLine($"The letter grade is {stats.Letter}");
            }
            else
            {
                Console.WriteLine("No grades entered!");
            }
        }
    }
}