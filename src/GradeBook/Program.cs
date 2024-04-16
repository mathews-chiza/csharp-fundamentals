namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Mathews's Grade Book");
            book.GradeAdded += OnGradeAdded;

            var done = false;
            while (!done)
            {
                Console.WriteLine("Enter a grade to add to grade book.\nEnter q to show statistics and exit:");
                var input = Console.ReadLine();

                if (input == "q" || string.IsNullOrEmpty(input))
                {
                    done = true;
                }
                else
                {
                    InsertValue(book, input);
                }
            }
            ShowStatistics(book);
        }

        private static void ShowStatistics(Book book)
        {
            var stats = book.GetStatistics();
            Console.WriteLine($"::::::{book.Name}::::::\n");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
            Console.WriteLine($"\n::::::{book.Name}::::::");
        }

        private static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("..........................");
            Console.WriteLine("....A grade was added.....");
            Console.WriteLine("..........................");
        }

        private static void InsertValue(IBook book, string input)
        {
            try
            {
                var parsed = double.TryParse(input, out double grade);
                if (parsed)
                {
                    book.AddGrade(grade);
                }
                else
                {
                    Console.WriteLine("Invalid input... Try again :)");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
