using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FinanceDAL : ICommon<Finance>
    {
        private static FinanceDAL dal = null;
        public static FinanceDAL DepartMent()
        {
            if (dal == null)
            {
                dal = new FinanceDAL();
            }
            return DepartMent();
        }

        public int Add(Finance t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.Finance.Add(t);
                return my.SaveChanges();
            }
        }

        public int Del(int Id)
        {
            using (MyDbContext my = new MyDbContext())
            {
                Finance p = my.Finance.Find(Id);
                my.Finance.Remove(p);
                return my.SaveChanges();
            }
        }

        public List<Finance> Show()
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.Finance.ToList();
            }
        }

        public Finance ShowById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Upd(Finance t)
        {
            throw new NotImplementedException();
        }
    }
}
