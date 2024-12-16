using Formula1Standings.DataAccess;
using Formula1Standings.Models;
using System.Text.Json;

namespace Formula1Standings.InMemoryRepositories
{
    public abstract class InMemoryRepository<TKey, TModel> : IRepository<TKey, TModel>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TModel> _records = new();

        public InMemoryRepository() { }

        public InMemoryRepository(string initialDataPath)
        {
            LoadFromJsonFile(initialDataPath);
        }

        public TModel Get(TKey key)
        {
            return _records[key];
        }

        public IList<TModel> GetAll()
        {
            return _records.Values.ToArray();
        }

        public void LoadFromJsonFile(string path)
        {
            using var jsonFile = File.OpenRead(path);
            var allRecords = JsonSerializer.Deserialize<TModel[]>(jsonFile)!;
            
            foreach (var record in allRecords)
                _records.Add(ResolveKey(record), record);
        }

        protected abstract TKey ResolveKey(TModel model);
    }
}