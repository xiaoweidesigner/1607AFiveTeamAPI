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
    public class OrderDAL : ICommon<Order>
    {
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Order t)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Order.Add(t);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据ID删除订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var order = db.Order.Find(Id);
                db.Order.Remove(order);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        public List<Order> Show()
        {
            using (MyDbContext db = new MyDbContext())
            {

                return db.Order.Include("SessionS").Include("Custom").ToList();
            }
        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Order ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {

                return db.Order.Include("SessionS").Include("Custom").ToList().FirstOrDefault(m=>m.OId==Id);
            }
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Order t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Order.Attach(t);
                db.Entry(t).State= EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
