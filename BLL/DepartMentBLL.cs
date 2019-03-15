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
    public class DepartMentBLL :ICommon<DepartMent>
    {
        private static DepartMentBLL bll = null;
        private DepartMentBLL()
        {
        }
        public static DepartMentBLL CreateDepartMentBLL()
        {
            if (bll == null)
            {
                bll = new DepartMentBLL();
            }
            return bll;
        }

        public int Add(DepartMent t)
        {
            return DepartMentDAL.CreatDepartMentDal().Add(t);
        }

        public int Del(int Id)
        {
            return DepartMentDAL.CreatDepartMentDal().Del(Id);
        }

        public List<DepartMent> Show()
        {
            return DepartMentDAL.CreatDepartMentDal().Show();
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
