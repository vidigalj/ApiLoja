using Models.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class OrderRepository : EFCoreRepository<Order, AppDbContext>
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
