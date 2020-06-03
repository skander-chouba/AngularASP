using AngularASP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularASP.Data.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ItemsRepository> _logger;

        public ItemsRepository(AppDbContext context, ILogger<ItemsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Item[]> GetItemsAsync()
        {
            try
            {
                IQueryable<Item> items = _context.Items;
                return await items.ToArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get all items from database", ex);
                return null;
            }
        }

        public async Task<Item> GetItemAsync(int id)
        {
            try
            {
                IQueryable<Item> query = _context.Items.Where(item => item.Id == id);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get the item from database", ex);
                return null;
            }
        }
    }
}
