namespace Formula1Standings.DataAccess;

public interface IRepository<T>
{
    IList<T> GetAll();
}
