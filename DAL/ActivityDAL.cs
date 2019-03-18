using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ActivityDAL : ICommon<Activity>
    {
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Activity t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Activity.Add(t);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据ID删除活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var activity = db.Activity.Find(Id);
                db.Activity.Remove(activity);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 查询活动
        /// </summary>
        /// <returns></returns>
        public List<Activity> Show()
        {
            using (MyDbContext db = new MyDbContext())
            {

                return db.Activity.Include("MovieHall").Include("Movie").ToList();
            }
        }
        /// <summary>
        /// 根据ID活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Activity ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {

                return db.Activity.Include("MovieHall").Include("Movie").FirstOrDefault(m => m.AId == Id);
            }
        }
        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Activity t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Activity.Attach(t);
                db.Entry(t).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }


    }
}
