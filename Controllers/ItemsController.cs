using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularASP.Data.Entities;
using AngularASP.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AngularASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(IItemsRepository itemsRepository, ILogger<ItemsController> logger)
        {
            _itemsRepository = itemsRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<Item[]>> Get()
        {
            try
            {
                var results = await _itemsRepository.GetItemsAsync();
                return results;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>>Get(int id)
        {
            try
            {
                var result = await _itemsRepository.GetItemAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
