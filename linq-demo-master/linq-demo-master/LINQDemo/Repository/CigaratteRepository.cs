using LINQDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo.Repository
{
    internal class CigaratteRepository
    {
        public List<Cigarette> items = new();
        public List<Cigarette> GetCigarettes()
        {
            return items;
        }
        public void AddCigratte(Cigarette cigarette)
        {
            items.Add(cigarette);
        }
        public List<Cigarette> GetAllCigatettes()
        {
            return items;
        }
    }
}
