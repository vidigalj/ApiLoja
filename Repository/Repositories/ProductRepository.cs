using Models.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ProductRepository : EFCoreRepository<Product, AppDbContext>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
