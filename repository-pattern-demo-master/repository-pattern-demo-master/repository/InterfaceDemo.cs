using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface Demo
    {
        void Func1();
        void Func2() { Console.WriteLine("default implemenattion of func2 in interface"); }
    }
    public class Impl : Demo
    {
        public void Func1() //implicity overrding
        {
            Console.WriteLine("overrding interface func1 method implicitly");
        }
        void Demo.Func1()
        {
            Console.WriteLine("overrding interface default  method func 1explicitly");
        }
       public void Func2()//explicit overriding
        {
            Console.WriteLine("overrding interface default  method func 2 implicitly");
        }
    }
}
