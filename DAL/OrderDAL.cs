using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

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
            using (MyDbContext db = new MyDbContext())
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
                //return db.Order.Include("SessionS").Include("Custom").ToList();
                List<Order> list=  db.Database.SqlQuery<Order>("select *,m.M_Name as MName,h.H_Name as HName from Orders o join SessionS s on o.SessionSId=s.SId join Movies m on s.MovieId = m.MId join MovieHalls h on s.MovieHallId = h.HId").ToList();
                return list;
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

                return db.Order.Include("SessionS").Include("Custom").ToList().FirstOrDefault(m => m.OId == Id);
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
                db.Entry(t).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        //修改订单状态
        public int UpdOrderState(int OId)
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Database.ExecuteSqlCommand($"update Orders set CO_State=2 where OId={OId}");
            }
        }
        /// <summary>
        /// 显示订单及订单有关系的表
        /// </summary>
        /// <returns></returns>
        public List<OMCH> ShowAll()
        {
            using (MyDbContext db = new MyDbContext())//用户取消的订单不显示
            {
                List<OMCH> list= db.Database.SqlQuery<OMCH>($"select *,M.M_Name as MName,mh.H_Name as HName,C.C_Name as CName,C.C_Phote as Phone,S.S_BeginTime as BeginTime from Orders O join SessionS S on O.SessionSId=SId join Movies M on S.MovieId=M.MId join MovieHalls mh on S.MovieHallId=mh.HId join Customs C on O.CustomId=C.CId where O.CO_State!=2").ToList();
                return list;
            }
        }
        /// <summary>
        /// 未使用
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public List<UserOrder> orders1(string tel)
        {
            string sql = "select * from Orders join SessionS on SessionSId=SId join Movies on MovieId=MId where CustomId = (select CId from Customs where C_Cellphone = '" + tel + "') and S_BeginTime > GETDATE() and CO_State = 1";

            List<UserOrder> list = JsonConvert.DeserializeObject<List<UserOrder>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
            return list;
        }
        /// <summary>
        /// 已完成
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public List<UserOrder> orders2(string tel)
        {
            string sql = "select * from Orders join SessionS on SessionSId=SId join Movies on MovieId=MId where CustomId = (select CId from Customs where C_Cellphone = '" + tel + "') and S_BeginTime < GETDATE() and CO_State = 1";

            List<UserOrder> list = JsonConvert.DeserializeObject<List<UserOrder>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
            return list;
        }
        /// <summary>
        /// 已取消
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public List<UserOrder> orders3(string tel)
        {
            string sql = "select * from Orders join SessionS on SessionSId=SId join Movies on MovieId=MId where CustomId = (select CId from Customs where C_Cellphone = '" + tel + "') and CO_State=2";

            List<UserOrder> list = JsonConvert.DeserializeObject<List<UserOrder>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
            return list;
        }
    }
}
