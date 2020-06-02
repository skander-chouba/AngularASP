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

        public async Task<List<Item>> GetItemsAsync()
        {
            try
            {
                return await _context.Items.ToListAsync();
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
                return await _context.Items.SingleOrDefaultAsync(item => item.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get the item from database", ex);
                return null;
            }
        }
    }
}
