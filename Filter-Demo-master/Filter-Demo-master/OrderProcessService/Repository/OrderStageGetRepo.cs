using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderProcessService.Models;
using Microsoft.Data.SqlClient;
namespace OrderProcessService.Repository
{
    public class OrderStageGetRepo
    {
        SqlConnection con = new SqlConnection("Server=localhost;Initial Catalog=wheelfactory;User ID=sa;Password=winner@123;Encrypt=True;TrustServerCertificate=true;");
        SqlCommand cmd;
        SqlDataReader reader;
        List<OrderStages> stages ;
        OrderStagesDBContext db;
        public OrderStageGetRepo(OrderStagesDBContext db)
        {
            this.db = db;
        }
         public List<OrderStages> ShowOrders()
        {
            return db.OrderStages.Select(os => new OrderStages(){ 
                    OrderId = os.OrderId,
                    Stage=os.Stage,
                    EmpId=os.EmpId,
            }).ToList();
        }
         
        public List<OrderStages> GetSolderingToComplete()
        {
            OrderStages os = new OrderStages();
            stages = new List<OrderStages>();
            con.Open();
            cmd = new SqlCommand("select * from orderstages where stage='soldering' and enddate is null", con);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                os.OrderId = reader.GetInt32(0);
                os.Stage = reader.GetString(1);
                os.StartDate = reader.GetDateTime(4);
                os.EmpId = reader.GetInt32(6);
                stages.Add(os);
            }
            con.Close();
            return stages;
        }
        public List<OrderStages> GetPaintingToStart()
        {
            OrderStages os = new OrderStages();
            stages = new List<OrderStages>();
            con.Open();
            cmd = new SqlCommand("select * from orderstages where stage='painting' and startdate is null", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                os.OrderId = reader.GetInt32(0);
                os.Stage = reader.GetString(1);
                os.EmpId = reader.GetInt32(6);
                stages.Add(os);
            }
            con.Close();
            return stages;
           
        }
        public List<OrderStages> GetPaintingToComplete()
        {
            OrderStages os = new OrderStages();
            stages = new List<OrderStages>();
            con.Open();
            cmd = new SqlCommand("select * from orderstages where stage='painting' and enddate is null", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                os.OrderId = reader.GetInt32(0);
                os.Stage = reader.GetString(1);
                os.StartDate = reader.GetDateTime(4);
                os.EmpId = reader.GetInt32(6);
                stages.Add(os);
            }
            con.Close();
            return stages;           
        }
        public List<OrderStages> GetPackagingToStart()
        {
            OrderStages os = new OrderStages();
            stages = new List<OrderStages>();
            con.Open();
            cmd = new SqlCommand("select * from orderstages where stage='packaging' and startdate is null", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                os.OrderId = reader.GetInt32(0);
                os.Stage = reader.GetString(1);
                os.EmpId = reader.GetInt32(6);
                stages.Add(os);
            }
            con.Close();
            return stages;
        }
        public List<OrderStages> GetPackagingToComplete()
        {
            OrderStages os = new OrderStages();
            stages = new List<OrderStages>();
            con.Open();
            cmd = new SqlCommand("select * from orderstages where stage='packaging' and enddate is null", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                os.OrderId = reader.GetInt32(0);
                os.Stage = reader.GetString(1);
                os.StartDate = reader.GetDateTime(4);
                os.EmpId = reader.GetInt32(6);
                stages.Add(os);
            }
            con.Close();
            return stages;
            
        }
    }
}
