using AngularASP.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AngularASP.Data
{
    public class ItemsSeeder
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hosting;

        public ItemsSeeder(AppDbContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            if (!_context.Items.Any())
            {
                //Need to create Sample data
                var filePath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(json);
                _context.Items.AddRange(items);

                var order = await _context.Orders.SingleOrDefaultAsync(order => order.Id == 1);
                if (order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Item = items.FirstOrDefault(),
                            Quantity = 5,
                            UnitPrice = items.FirstOrDefault().Price
                        }
                    };
                }
               await  _context.SaveChangesAsync();
            }
        }

    }
}
