using DAL;
using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartMentBLL : ICommon<DepartMent>
    {
        private static DepartMentBLL dal = null;
        public static DepartMentBLL DepartMent()
        {
            if (dal == null)
            {
                dal = new DepartMentBLL();
            }
            return DepartMent();
        }
        public int Add(DepartMent t)
        {
            return dal.Add(t);
        }

        public int Del(int Id)
        {
            return dal.Del(Id);
        }

        public List<DepartMent> Show()
        {
            return dal.Show();
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
