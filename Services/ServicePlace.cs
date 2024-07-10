using Material_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagment.Services;

public static class ServicePlace
{

    public static bool Add_Place( Place? place )
    {
        if ( place == null ) 
            return false;

        using var db = new DataContext();

        try
        {
            db.Places.Add(place);
            db.SaveChanges();
            return true;
        }
        catch 
        { 
            return false; 
        }
    }

    public static bool Remove_Place(int id)
    {
        using var db = new DataContext();
        Place? place = db.Places.Find(id);
        
        if ( place == null ) 
            return false;

        try
        {
            db.Places.Remove(place);
            db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

}

