namespace GradeBook
{
    public interface IBook
    {
        event GradeAddedDelegate? GradeAdded;

        Statistics GetStatistics();

        void ShowStatistics();

        void AddGrade(double grade);
    }
}