﻿using Maletkunst.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maletkunst.DAL
{
	public interface IPaintingDao
	{
		IEnumerable<Painting> GetAllPaintings();

		IEnumerable<Painting> Search(string searchString);

		IEnumerable<Painting> GetPaintingsByCategory(string category);
	}
}
