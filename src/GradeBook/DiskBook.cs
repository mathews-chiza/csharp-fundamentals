namespace GradeBook
{
    public class DiskBook(string name) : Book(name)
    {
        private readonly string fileName = $"{name}.txt";

        public override event GradeAddedDelegate? GradeAdded;

        public override void AddGrade(double grade)
        {
            using var writer = File.AppendText(fileName);
            writer.WriteLine(grade);

            if (GradeAdded is not null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText(fileName))
            {
                var line = reader.ReadLine();
                while (line is not null)
                {
                    result.Add(double.Parse(line));
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}