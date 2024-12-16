namespace Formula1Standings.DataAccess;

public interface IRepository<TKey, TModel>
{
    TModel Get(TKey key);
    IList<TModel> GetAll();
}
