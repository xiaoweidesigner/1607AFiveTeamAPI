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
    public class DepartMentBLL 
    {

        private static ICommon<DepartMent> bll;
        public DepartMentBLL()
        {
            if (bll == null)
            {
                bll = new DepartMentBLL() as ICommon<DepartMent>;
            }
        }
        public int Add(DepartMent t)
        {
            return bll.Add(t);
        }

        public int Del(int Id)
        {
            return bll.Del(Id);
        }

        public List<DepartMent> Show()
        {
            return bll.Show();
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
