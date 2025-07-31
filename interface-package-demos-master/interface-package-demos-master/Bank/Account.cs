namespace Bank
{
    public class Account
    {
        public string AccoutType {  get; set; }
        public string AccountId { get; set; } = string.Empty;
        public Customer AccountHolder {  get; set; }
        public double Balance {  get; set; }
    }
}
