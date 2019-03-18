using DAL;
using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FinanceBLL:ICommon<Finance>
    {
        private static FinanceBLL bll = null;
        private FinanceBLL()
        {
        }
        public static FinanceBLL CreateFinanceBLL()
        {
            if (bll == null)
            {
                bll = new FinanceBLL();
            }
            return bll;
        }
        public int Add(Finance t)
        {
            return FinanceDAL.CreatFinanceDAL().Add(t);
        }

        public int Del(int Id)
        {
            return FinanceDAL.CreatFinanceDAL().Del(Id);
        }

        public List<Finance> Show()
        {
            return FinanceDAL.CreatFinanceDAL().Show();
        }

        public Finance ShowById(int Id)
        {
            return FinanceDAL.CreatFinanceDAL().ShowById(Id);
        }

        public int Upd(Finance t)
        {
            return FinanceDAL.CreatFinanceDAL().Upd(t);
        }


        FinanceDAL financeDAL = new FinanceDAL();
        /// <summary>
        /// 根据年月日查询财务
        /// </summary>
        /// <returns></returns>
        public DataTable ShowCaiwuRi(int year, int month, int day, int state)
        {

            return financeDAL.ShowCaiwuRi(year, month, day, state);
        }
        /// <summary>
        /// 根据年月日查询图表
        /// </summary>
        /// <returns></returns>
        public DataTable ShowTuBiaoRi(int year, int month, int day)
        {

            return financeDAL.ShowTuBiaoRi(year, month, day);
        }
        public List<Finance> ShowFinance()
        {
            return FinanceDAL.CreatFinanceDAL().ShowFinance();
        }
    }
}
