using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Repository.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : BaseController<OrderItem, OrderItemRepository>
    {
        public OrderItemController(OrderItemRepository repository) : base(repository)
        {
        }
    }
}
