using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product, ProductRepository>
    {
        private ProductRepository productRepository;
        public ProductController(ProductRepository repository) : base(repository)
        {
        }
        // GET: api/[controller]/name
        [HttpGet("{name}")]
        public async Task<ActionResult<Product>> GetByName(string name)
        {
            var entityId = productRepository.GetByFilter(x => x.Name == name).Id;
            var entity = await productRepository.Get(entityId);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}
