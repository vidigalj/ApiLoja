using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Interfaces;
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
            this.productRepository = repository;
        }
        // GET: api/[controller]/name
        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<Product>> GetByName(string name)
        {
            var entity = await productRepository.GetByName(x => x.Name == name);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

    }
}
