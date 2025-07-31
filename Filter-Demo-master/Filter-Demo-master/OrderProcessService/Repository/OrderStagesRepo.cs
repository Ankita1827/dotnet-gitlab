using Microsoft.EntityFrameworkCore;
using OrderProcessService.Models;

namespace OrderProcessService.Repository
{
    public class OrderStagesRepo
    {
        private readonly OrderStagesDBContext _context;
        public OrderStagesRepo(OrderStagesDBContext context)
        {
            _context = context;
        }
       
        public bool StartSoldering(int orderid)
        { 
            try{
            _context.Database.ExecuteSqlRaw($"insert into orderstages(order,stage,startdate) values ({orderid},'soldering',getdate())");
           }catch
            {
                return false;
            }
            return true;           
        }
        
         public bool CompleteSoldering(int orderid,UpdateStageDTO stage)
        {
            _context.Database.ExecuteSqlRaw($"update orderstage set remarks={stage.Remarks},image={stage.Image},enddate=getdate() where orderid={orderid}");
            return true;
        }        
        public bool StartPainting(int orderid)
        {
            _context.Database.ExecuteSqlRaw($"insert in to orderprocess(orderid,status) values({orderid}),'painting')");
            return true;
        }
        public bool StartPackaging(int orderid)
        {
            _context.Database.ExecuteSqlRaw($"insert in to orderprocess(orderid,status) values({orderid}),'packaging')");
            return true;
        }
        
        public bool CompletePainting(int orderid, UpdateStageDTO stage)
        {
            var op = _context.OrderStages.Where(p => p.OrderId == orderid).FirstOrDefault();
            if (op != null)
            {
                op.Remarks = stage.Remarks;
                op.Image = stage.Image;
                op.EndDate = DateTime.Now;
                _context.SaveChanges();
                StartPackaging(orderid);
            }
            return true;
        }

        public bool CompletePackaging(int orderid, UpdateStageDTO stage)
        {
            _context.Database.ExecuteSqlRaw($"update orderstage set remarks={stage.Remarks},image={stage.Image},enddate=getdate() where orderid={orderid}");
            return true;
        }
    }
}
