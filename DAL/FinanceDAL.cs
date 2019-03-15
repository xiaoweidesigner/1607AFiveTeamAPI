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
    }
}
