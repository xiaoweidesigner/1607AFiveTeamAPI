using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public class DepartMentDAL : ICommon<DepartMent>
    {
        private static DepartMentDAL dal = null;
        public static DepartMentDAL DepartMent()
        {
            if (dal==null)
            {
                dal = new DepartMentDAL();
            }
            return DepartMent();
        }

        public int Add(DepartMent t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.DepartMent.Add(t);
                return my.SaveChanges();
            }
        }

        public int Del(int Id)
        {
            using (MyDbContext my = new MyDbContext())
            {
                DepartMent p = my.DepartMent.Find(Id);
                my.DepartMent.Remove(p);
                return my.SaveChanges();
            }
        }

        public List<DepartMent> Show()
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.DepartMent.ToList();
            }
        }

        public DepartMent ShowById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Upd(DepartMent t)
        {
            throw new NotImplementedException();
        }
    }
}
