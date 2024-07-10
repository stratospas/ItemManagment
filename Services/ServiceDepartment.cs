using ItemManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagment.Services
{
    public static class ServiceDepartment
    {
        public static List<Department> Get_All()
        {
            using var db = new DataBaseContext();
            return [.. db.Departments];
        }

        public static Department? GetbyId(int id)
        {
            using var db = new DataBaseContext();
            return db.Departments.Find(id);
        }

        public static Department? GetbyName(int n)
        {
            using var db = new DataBaseContext();
            return db.Departments.FirstOrDefault( d => d.Number == n);
        }

        public static bool Add(int number)
        {
            Department d = new Department { Number = number };

            using var db = new DataBaseContext();
            try
            {
                db.Departments.Add(d);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(Department d)
        {
            using var db = new DataBaseContext();

            try
            {
                Department? update = db.Departments.FirstOrDefault(de => de.DepartmentId == d.DepartmentId);                
                update.Number = d.Number;
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool Remove(Department d)
        {
            using var db = new DataBaseContext();

            try
            {
                db.Remove(d);
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool Remove(int n)
        {
            using var db = new DataBaseContext();
            Department? d = db.Departments.Find(n);

            try
            {
                db.Remove(d);
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

    }
}
