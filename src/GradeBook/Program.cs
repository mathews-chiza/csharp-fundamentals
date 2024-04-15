namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Mathews's Grade Book");
            var done = false;
            while (!done)
            {
                Console.WriteLine("Enter a grade to add to grade book.\nEnter q to show statistics and exit:");
                var input = Console.ReadLine();

                if (input == "q" || string.IsNullOrEmpty(input)) {
                    done = true;
                } else {
                    InsertValue(book, input);
                }
            }
            book.ShowStatistics();
        }

        private static void InsertValue(Book book, string input)
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
