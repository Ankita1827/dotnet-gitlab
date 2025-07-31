using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    delegate float MyDelegate(float x,float y);
    internal class DelegateEx
    {

        static MyDelegate m = delegate(float a, float b) { return a + b; };  //lambda
        
       Action <int> a = (x) => { };
        Predicate<int> p = (x) => true;
        public static void Func1(float x, float y) {  }
        public void CallFunc()
        {
            m(4,6);
        }
        public void FutureFunc(Func<int,int,int> f) {
            f(3,4);
        }
        // Func,Predicate,Action
    }
}
