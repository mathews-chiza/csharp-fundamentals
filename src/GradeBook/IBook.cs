namespace GradeBook
{
    public interface IBook
    {
        event GradeAddedDelegate? GradeAdded;

        Statistics GetStatistics();

        void AddGrade(double grade);
    }
}