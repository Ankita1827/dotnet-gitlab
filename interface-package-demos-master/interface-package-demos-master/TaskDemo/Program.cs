using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace TaskDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Future future = new Future();
            //future.UseNow(() => { Console.WriteLine("my implementation"); });
            //future.FutureMethod = (a, b) => { return a + b; };
            future.future2 = new Future2Imp();
            future.UseNow(new Future1());

        }
    }
    class Future2Imp : IFuture2
    {
        
               public int FutureProcess(int a,int b) { return a + b; }
    }
    class Future1 : IFuture
    {
        public void Action()
        {
            Console.WriteLine("action is implemented");
        }
    }
}
