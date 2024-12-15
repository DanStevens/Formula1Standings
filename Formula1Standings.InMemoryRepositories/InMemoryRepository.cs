using Formula1Standings.DataAccess;
using Formula1Standings.Models;
using System.Text.Json;

namespace Formula1Standings.InMemoryRepositories
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly List<T> _records = new List<T>();

        public IList<T> GetAll()
        {
            return _records.ToArray();
        }

        public void LoadFromJsonFile(string path)
        {
            using var jsonFile = File.OpenRead(path);
            var allRecords = JsonSerializer.Deserialize<T[]>(jsonFile);
            _records.AddRange(allRecords!);
        }
    }
}