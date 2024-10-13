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
    public class EFOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EFOrderDal(TashanSofrasiContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Orders.Where(x => x.OrderDescription == "Aktif Sipariş").Count();
            }
        }

        public decimal LastOrderPrice()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Orders.OrderByDescending(x => x.OrderID).Select(z => z.TotalPrice).FirstOrDefault();
            }
        }

        public decimal TodayAmount()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Orders.Where(x=>x.OrderDescription == "Hesap Ödendi").Where(y=>y.Date == DateTime.Now).Sum(z=>z.TotalPrice);
            }
        }

        public int TotalOrderCount()
        {
            using (var context = new TashanSofrasiContext())
            {
                return context.Orders.Count();
            }
        }
    }
}
