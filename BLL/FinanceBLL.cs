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
    public class FinanceBLL
    {
        private static ICommon<Finance> bll;
        public FinanceBLL()
        {
            if (bll == null)
            {
                bll = new FinanceBLL() as ICommon<Finance>;
            }
        }
        public int Add(Finance t)
        {
            return bll.Add(t);
        }

        public int Del(int Id)
        {
            return bll.Del(Id);
        }

        public List<Finance> Show()
        {
            return bll.Show();
        }

        public Finance ShowById(int Id)
        {
            return bll.ShowById(Id);
        }

        public int Upd(Finance t)
        {
            return bll.Upd(t);
        }
    }
}
