using ItemManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagment.Services
{
    public static class ItemServices
    {
        public static bool Add(Item item)
        {
            using var db = new DataBaseContext();
            try
            {
                db.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Item> GetItems()
        {
            using var db = new DataBaseContext();
            return db.items.OrderBy(i => i.Id).ToList();
        }
    }
}
