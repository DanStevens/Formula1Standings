namespace Formula1Standings.Services;

public interface IRepository<TKey, TModel>
{
    TModel Get(TKey key);
    IList<TModel> GetAll();
}
