using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrderProcessService.Models;

namespace OrderProcessService.Repository
{
    public class OrderStagesDBContext:Microsoft.EntityFrameworkCore.DbContext
    {
            public OrderStagesDBContext(DbContextOptions<OrderStagesDBContext> options) : base(options)
                   
            { }

            public Microsoft.EntityFrameworkCore.DbSet<OrderStages>  OrderStages{ get; set; }

    }
}
