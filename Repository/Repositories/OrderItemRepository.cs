using Models.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class OrderItemRepository : EFCoreRepository<OrderItem, AppDbContext>
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
