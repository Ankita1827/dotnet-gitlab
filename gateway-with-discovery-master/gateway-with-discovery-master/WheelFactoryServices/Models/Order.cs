using MongoDB.Bson.Serialization.Attributes;

namespace WheelFactoryServices.Models
{
    //reflection
    public class Order
    {
        [BsonId]
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string Model {  get; set; }
        public string Year {  get; set; }
        public string DamageType {  get; set; }

    }
}
