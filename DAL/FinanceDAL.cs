using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FinanceDAL : ICommon<Finance>
    {
        private static FinanceDAL dal = null;
        public FinanceDAL()
        {

        }
        public static FinanceDAL CreatFinanceDAL()
        {
            if (dal == null)
            {
                dal = new FinanceDAL();
            }
            return dal;
        }
        /// <summary>
        /// 添加财务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Finance t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.Finance.Add(t);
                return my.SaveChanges();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext my = new MyDbContext())
            {
                Finance p = my.Finance.Find(Id);
                my.Finance.Remove(p);
                return my.SaveChanges();
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Finance> Show()
        {
            using (MyDbContext my = new MyDbContext())
            {
                return my.Finance.Include("Finance").ToList();
            }
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Finance ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Finance.Include("Finance").Where(s => s.FId == Id).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Finance t)
        {
            using (MyDbContext my = new MyDbContext())
            {
                my.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return my.SaveChanges();
            }
        }


        /// <summary>
        /// 根据年月日查询财务
        /// </summary>
        /// <returns></returns>
        public DataTable ShowCaiwuRi(int year, int month, int day, int state)
        {
            string sql = @"select sum(O_Money) qian,count(*) shu from Orders join SessionS on SessionS.SId=SessionSId where SessionSId in (select SId from SessionS where DATEPART(YYYY,S_BeginTime)=" + year + " and DATEPART(MM, S_BeginTime)= " + month + " and DATEPART(DAY, S_BeginTime)= " + day + ")  ";
            if (state == 1)
            {
                sql += " and O_State = 1 ";
            }
            else if (state == 2)
            {
                sql += " and O_State = 2 ";
            }
            return DBHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 根据年月日查询图表
        /// </summary>
        /// <returns></returns>
        public DataTable ShowTuBiaoRi(int year, int month, int day)
        {
            string sql = @"select SessionSId,sum(O_Money) qian2,S_BeginTime from Orders join SessionS on SessionS.SId=SessionSId where SessionSId in (select SId from SessionS where DATEPART(YYYY,S_BeginTime)=" + year + " and DATEPART(MM,S_BeginTime)= " + month + " and  DATEPART(DAY,S_BeginTime)= " + day + ") and O_State=1  group by SessionSId,S_BeginTime";
            return DBHelper.GetDataTable(sql);
        }

    }
}
