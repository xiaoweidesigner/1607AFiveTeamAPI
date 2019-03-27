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
    public class SeatDAL : ICommon<Seat>
    {
        /// <summary>
        /// 添加座位
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Seat t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                
                db.Database.CreateIfNotExists();
                db.Seat.Add(t);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据ID删除座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var seat = db.Seat.Find(Id);
                db.Seat.Remove(seat);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 查询座位
        /// </summary>
        /// <returns></returns>
        public List<Seat> Show()
        {
            using (MyDbContext db = new MyDbContext())
            {

                return db.Seat.Include("MovieHall").ToList();
            }
        }
        /// <summary>
        /// 根据ID座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Seat ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {

                return db.Seat.Include("MovieHall").ToList().FirstOrDefault(m => m.SeId == Id);
            }
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Seat t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Seat.Attach(t);
                db.Entry(t).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
        //座位被选定
        public int UpdSeats(string Ids)
        {
            using (MyDbContext db=new MyDbContext())
            {
                string sql = $"update Seats set IsCheck=1 where SeId in ({Ids})";
                int result = db.Database.ExecuteSqlCommand(sql);
                return result;
            }
        }
       
    }
}
