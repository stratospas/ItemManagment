using ItemManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagment.Services
{
    public static class ServicePerson
    {

        public static List<Person> Get_All()
        {
            using var db = new DataBaseContext();
            return [.. db.People.Include(p=>p.Department)];
        }
        public static bool Add( Person? person)
        {
            using var db = new DataBaseContext();
            try
            {
                db.Add(person);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static Person? Get_By_Id(int id)
        {
            using var db = new DataBaseContext();
            return db.People.Include(p=>p.Department).FirstOrDefault(p => p.PersonId == id);
        }

        public static List<Person> Get_By_Fullname(string name, string surname)
        {
            using var db = new DataBaseContext();
            return [.. db.People.Where(p => p.Name == name && p.Lastname == surname)];
        }

        public static List<Person> Get_By_Name(string name)
        {
            using var db = new DataBaseContext();
            return [.. db.People.Where(p => p.Name == name)];
        }

        public static List<Person> Get_By_Lastname(string name)
        {
            using var db = new DataBaseContext();
            return [.. db.People.Where(p => p.Lastname == name)];
        }

        public static List<Person> Get_By_Department(int department)
        {
            using var db = new DataBaseContext();
            return [.. db.People.Where(p => p.DepartmentId == department)];
        }

        public static bool Update(Person person)
        {
            using var db = new DataBaseContext();
            var update = db.Find<Person>(person.PersonId);

            if (update == null)
                return Add(person);

            try
            {
                update.Name = person.Name.ToUpper();
                update.Lastname = person.Lastname.ToUpper();
                update.DepartmentId = person.DepartmentId;
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public static List<Person> Search(string s)
        {
            using var db = new DataBaseContext();
            var results = db.People
                .Include(p => p.Department)
                .Where(p => p.Lastname.Contains(s) || p.Name.Contains(s))
                .ToList();

            return results;                
        }

        public static bool Delete(int id)
        {
            using var db = new DataBaseContext();
            Person? result = db.Find<Person>(id);

            if (result == null)
                return false;
            
            try
            {
                db.Remove(result);
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
