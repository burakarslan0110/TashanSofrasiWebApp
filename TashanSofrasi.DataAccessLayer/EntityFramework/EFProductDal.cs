using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TashanSofrasi.DataAccessLayer.Abstract;
using TashanSofrasi.DataAccessLayer.Concrete;
using TashanSofrasi.DataAccessLayer.Repositories;
using TashanSofrasi.EntityLayer.Entities;

namespace TashanSofrasi.DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(TashanSofrasiContext context) : base(context)
        {
        }

		public List<Product> GetProductWithCategories()
		{
			using (var context = new TashanSofrasiContext())
			{
				return context.Products.Include(x => x.Category).ToList();
			}
		}
	}
}
