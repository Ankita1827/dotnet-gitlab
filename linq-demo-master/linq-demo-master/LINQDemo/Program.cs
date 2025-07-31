using LINQDemo.Models;
using LINQDemo.Repository;
using System.Security.Cryptography;
using System.Text.Json;

namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            //DelegateEx dg = new DelegateEx();
            //dg.FutureFunc((a,b)=>a+b);
            CigaratteRepository repo=new();
            Cigarette cigarette;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("select the property type 1.AddItem, 2.ViewItems,3.Filtered,4.Price>,5.Exit");
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("====================================================================");
                Console.ForegroundColor=ConsoleColor.Yellow;
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        cigarette = new Cigarette();
                        cigarette.InsertItem();
                        repo.AddCigratte(cigarette);
                        break;
                    case 2:
                        foreach(Cigarette cig in repo.GetAllCigatettes())
                        {
                            Console.WriteLine(cig);//cig.tostring()
                        }
                        break;
                    case 3:
                        var items = repo.GetAllCigatettes();
                        var filtered =  from c in items
                                        where c.IsFilter == 'y'
                                        select c;// IEnumerable
                        foreach(var item in filtered)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 4:
                        Console.WriteLine("enter the price");
                        double price = Convert.ToDouble(Console.ReadLine());
                        var result = repo.GetAllCigatettes().Where((c) => c.Price > price);
                          foreach(Cigarette obj in result  )
                        {
                            Console.WriteLine(obj);
                        }
                        break;
                    default:
                        break;
                }
                
            } while (choice != 5);

        }
       static  int check(int a,int b) { return a + b; }
    }
}
