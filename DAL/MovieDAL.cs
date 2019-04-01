using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using MODEL;
using Newtonsoft.Json;
namespace DAL
{
    public class MovieDAL : ICommon<Movie>
    {
        private static MovieDAL dal;
        public MovieDAL()
        {

        }
        public static MovieDAL CreateMovieDAL()
        {
            if (dal == null)
            {
                dal = new MovieDAL();
            }
            return dal;
        }
        /// <summary>
        /// 添加影片信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Movie t)
        {
            using (MyDbContext db = new MyDbContext()) {
                db.Movie.Add(t);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据id删除影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext db=new MyDbContext()) {
              var m=  db.Movie.Find(Id);
                db.Movie.Remove(m);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 显示影片信息
        /// </summary>
        /// <returns></returns>
        public List<Movie> Show()
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Movie.ToList();
            }
        }
        /// <summary>
        /// 根据Id查询影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Movie ShowById(int Id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Movie.Find(Id);
            }
        }
        /// <summary>
        /// 修改影片信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Movie t)
        {
            using (MyDbContext db = new MyDbContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
        //下架
        public int Down(int MId)
        {
            using (MyDbContext db=new MyDbContext())
            {
                return db.Database.ExecuteSqlCommand($"update Movies set M_State=2 where MId={MId}");
            }
        }
        //上架
        public int UP(int MId)
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Database.ExecuteSqlCommand($"update Movies set M_State=1 where MId={MId}");
            }
        }


        /// <summary>
        /// 根据用户查看历史影片
        /// </summary>
        /// <returns></returns>
        public List<Movie> ShowHistory(string tel)
        {
            string sql = @"select * from movies where mid in (select distinct movieid from sessions where sid in (
                          select distinct sessionsid from orders where customid = (select cid from customs where c_cellphone = '" + tel + "') and co_state = 1 and o_stime<getdate())) ";
            return  JsonConvert.DeserializeObject<List<Movie>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
        }
    }
}
