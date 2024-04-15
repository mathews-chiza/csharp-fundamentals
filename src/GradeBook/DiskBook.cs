namespace GradeBook
{
    public class DiskBook(string name) : Book(name)
    {
        public override event GradeAddedDelegate? GradeAdded;

        public override void AddGrade(double grade)
        {
            using var writer = File.AppendText($"{name}.txt");
            writer.WriteLine(grade);

            if (GradeAdded is not null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public override void ShowStatistics()
        {
            throw new NotImplementedException();
        }
    }
}