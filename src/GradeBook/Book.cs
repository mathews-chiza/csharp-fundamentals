namespace GradeBook
{
    public abstract class Book(string name) : NamedObject(name), IBook
    {
        public abstract event GradeAddedDelegate? GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        public abstract void ShowStatistics();
    }
}