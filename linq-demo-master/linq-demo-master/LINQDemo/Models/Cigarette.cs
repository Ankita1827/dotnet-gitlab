using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo.Models
{
    internal class Cigarette
    {
        public char IsFilter {  get; set; }
        public string Name { get; set; }
        public double Price {  get; set; }
        public int PacketSize {  get; set; }
        public double Length {  get; set; }
        public void InsertItem()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the Name");
            Name = Console.ReadLine();
            Console.Write("Enter the price");
            Price = Double.Parse(Console.ReadLine());
            Console.Write("Length:");
            Length = Double.Parse(Console.ReadLine());
            Console.Write("Is Filtered:");
            IsFilter = Convert.ToChar(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"Name:{Name} Price:{Price} Length:{Length} Filtered:{IsFilter}";
        }
    }
}
