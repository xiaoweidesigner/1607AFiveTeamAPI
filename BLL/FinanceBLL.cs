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
    public class FinanceBLL : ICommon<Finance>
    {
        private static FinanceBLL dal = null;
        public static FinanceBLL DepartMent()
        {
            if (dal == null)
            {
                dal = new FinanceBLL();
            }
            return DepartMent();
        }
        public int Add(Finance t)
        {
            return dal.Add(t);
        }

        public int Del(int Id)
        {
            return dal.Del(Id);
        }

        public List<Finance> Show()
        {
            return dal.Show();
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
