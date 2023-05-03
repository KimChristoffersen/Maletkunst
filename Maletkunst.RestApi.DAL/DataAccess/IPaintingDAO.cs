﻿using Maletkunst.RestApi.DAL.Model;

namespace Maletkunst.RestApi.DAL.DataAccess;

public interface IPaintingDAO
{
    IEnumerable<Painting> GetAll();
    IEnumerable<Painting> GetAllAvailable();
    IEnumerable<Painting> GetAllFreeSearch(string searchString);
    IEnumerable<Painting> GetAllByCategory(string category);
    IEnumerable<Painting> GetAllByCategoryAndFreeSearch(string category, string searchString);
    int CreatePainting(Painting painting);
    bool DeletePainting(int id);
    bool UpdatePainting(Painting painting);
}