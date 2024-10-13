﻿using Microsoft.EntityFrameworkCore;
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

        public int ProductCount()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Products.Count();
            }
        }

        public int ProductCountByCategoryNameCorba()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Products.Where(x => x.Category.CategoryName == "Çorba").Count();
            }
        }

        public int ProductCountByCategoryNamePide()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Products.Where(x => x.Category.CategoryName == "Pide").Count();
            }
        }

        public decimal ProductAveragePrice()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Products.Average(x => x.ProductPrice);
            }
        }

        public List<string> ProductWithHighestPrice()
        {
            using (var context = new TashanSofrasiContext())
            {
                var mep = context.Products
                    .OrderByDescending(x => x.ProductPrice)
                    .Select(z => new { z.ProductName, z.ProductPrice })
                    .FirstOrDefault();

                List<string> result = new List<string>
                {
                    $"Ürün Adı: {mep.ProductName}",
                    $"Fiyat:  {mep.ProductPrice}"
                };

                return result;
            }
        
        }

        public List<string> ProductWithLowestPrice()
        {
            using (var context = new TashanSofrasiContext())
            {
                var mep = context.Products
                    .OrderBy(x => x.ProductPrice)
                    .Select(z => new { z.ProductName, z.ProductPrice })
                    .FirstOrDefault();

                List<string> result = new List<string>
                {
                    $"Ürün Adı: {mep.ProductName}",
                    $"Fiyat:  {mep.ProductPrice}"
                };

                return result;
            }
        }
    }
}
