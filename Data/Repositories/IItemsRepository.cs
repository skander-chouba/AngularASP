using AngularASP.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularASP.Data.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(int id);
        Task<Item[]> GetItemsAsync();
    }
}