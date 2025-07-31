using Entities;
using repository;
using System.Net.Http.Headers;

namespace repositorypatterndemo
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            Demo impl = new Impl();
            impl.Func1();
            impl.Func2();            
        }
        public static void add(int t ,int b,out int c) {
            c = t + b;
        }
    }
}
