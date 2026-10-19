using SQLite;
using System.Threading.Tasks;

namespace FrigoMalin.Services
{
    public interface IDatabaseService
    {
        Task<SQLiteAsyncConnection> GetConnectionAsync();
        Task ResetAndSeedDataAsync();
    }
}
