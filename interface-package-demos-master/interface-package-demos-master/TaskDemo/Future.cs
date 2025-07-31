using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    internal class Future
    {
        //public void UseNow(Action action) { //functional programming
        //    action();
        //    Console.WriteLine(FutureMethod(44,4));
        //}
        //public Func<int, int, int> FutureMethod { get; set; } = (a,b) => { return 4; };
        public void UseNow(IFuture action)
        { //functional programming
            action.Action();
            Console.WriteLine(future2.FutureProcess(44, 4));
        }
       public IFuture2 future2 { get; set; }  
    }
    interface IFuture { 
        void Action();
    }
    interface IFuture2
    {
        int FutureProcess(int a,int b);
    }
}
