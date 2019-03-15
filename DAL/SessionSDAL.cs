using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using MODEL;

namespace DAL
{
    public class SessionSDAL : ICommon<SessionS>
    {
        private static SessionSDAL dal;
        public SessionSDAL()
        {

        }
        public static SessionSDAL CreateSessionSDAL()
        {
            if (dal == null)
            {
                dal = new SessionSDAL();
            }
            return dal;
        }
        /// <summary>
        /// 添加场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(SessionS t)
        {
            using (MyDbContext db=new MyDbContext()) {
                db.SessionS.Add(t);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据Id删除场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var s = db.SessionS.Find(Id);
                db.SessionS.Remove(s);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 显示场次信息
        /// </summary>
        /// <returns></returns>
        public List<SessionS> Show()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.SessionS.Include("Movie").Include("MovieHall").ToList();
            }
        }
        /// <summary>
        /// 根据Id查询场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SessionS ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.SessionS.Include("Movie").Include("MovieHall").Where(s=>s.SId==Id).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(SessionS t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
