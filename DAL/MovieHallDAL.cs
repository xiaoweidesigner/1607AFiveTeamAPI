using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using MODEL;

namespace DAL
{
    
    public class MovieHallDAL : ICommon<MovieHall>
    {
        private static MovieHallDAL dal;
        public MovieHallDAL()
        {

        }
        public static MovieHallDAL CreateMovieHallDAL()
        {
            if (dal == null)
            {
                dal = new MovieHallDAL();
            }
            return dal;
        }
        /// <summary>
        /// 添加影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(MovieHall t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.MovieHall.Add(t);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据id删除影厅
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext db=new MyDbContext()) {
                var mhall = db.MovieHall.Find(Id);
                db.MovieHall.Remove(mhall);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 显示影厅信息
        /// </summary>
        /// <returns></returns>
        public List<MovieHall> Show()
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                return db.MovieHall.ToList();
            }
        }
        /// <summary>
        /// 根据Id返填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MovieHall ShowById(int Id)
        {
            using (MyDbContext db=new MyDbContext()) {
                return db.MovieHall.Find(Id);
            }
        }
        /// <summary>
        /// 修改影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(MovieHall t)
        {
            using (MyDbContext db=new MyDbContext()) {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 打扫卫生能看到的该打扫的影厅信息
        /// </summary>
        /// <returns></returns>
        public List<MovieHall> SH()
        {
            using (MyDbContext db=new MyDbContext())
            {
                return db.Database.SqlQuery<MovieHall>($"select * from MovieHalls where H_State in (3,4)").ToList();
            }
        }
    }
}
