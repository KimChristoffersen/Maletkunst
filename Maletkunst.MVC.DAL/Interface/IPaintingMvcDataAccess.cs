using Maletkunst.MVC.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maletkunst.MVC.DAL.Interface
{
    public interface IPaintingMvcDataAccess
    {
        IEnumerable<Painting> GetAllAvailablePaintings();
        IEnumerable<Painting> GetAllPaintingsByFreeSearch(string searchString);
        IEnumerable<Painting> GetAllPaintingsByCategory(string category);
        //IEnumerable<Painting> GetAllPaintingsByCategoryAndFreeSearch(string category, string searchString); Not yet implemented in mvc
        Painting GetPaintingById(int id);
    }
}
