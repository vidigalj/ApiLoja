using Models.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : EFCoreRepository<Product, AppDbContext>
    {
        private AppDbContext context;
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
