using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using MODEL;
using Newtonsoft.Json;
using RecallOnTime.Models;
using StackExchange.Redis;

namespace RecallOnTime.Controllers
{
    public class LmqController : ApiController
    {
        #region  电影
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddMovie(Movie t)
        {
            return MovieBLL.CreateMovieBLL().Add(t);
        }
        /// <summary>
        /// 根据id删除影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelMovie(int Id)
        {
            return MovieBLL.CreateMovieBLL().Del(Id);
        }
        /// <summary>
        /// 显示影片信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] ShowMovie()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetMovies"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<Movie> list = MovieBLL.CreateMovieBLL().Show();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].MId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetMovies", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetMovies", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetMovies");
            return redis;
        }
        /// <summary>
        /// 根据Id查询影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public Movie ShowByIdMovie(int Id)
        {
            return MovieBLL.CreateMovieBLL().ShowById(Id);
        }
        /// <summary>
        /// 修改影片信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdMovie(Movie t)
        {
            return MovieBLL.CreateMovieBLL().Upd(t);
        }
        //下架
        public int Down(int MId)
        {
            return MovieBLL.CreateMovieBLL().Down(MId);
        }
        //上架
        public int UP(int MId)
        {
            return MovieBLL.CreateMovieBLL().UP(MId);
        }
        #endregion

        #region  场次
        /// <summary>
        /// 添加场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddSessionS(SessionS t)
        {
            return SessionSBLL.CreateSessionSBLL().Add(t);
        }
        /// <summary>
        /// 根据Id删除场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelSessionS(int Id)
        {
            return SessionSBLL.CreateSessionSBLL().Del(Id);
        }
        /// <summary>
        /// 显示场次信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] ShowSessionS()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetSessions"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<SessionS> list = SessionSBLL.CreateSessionSBLL().Show();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].SId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetSessions", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetSessions", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetSessions");
            return redis;
        }
        /// <summary>
        /// 根据Id查询场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public SessionS ShowByIdSessionS(int Id)
        {
            return SessionSBLL.CreateSessionSBLL().ShowById(Id);
        }
        /// <summary>
        /// 修改场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdSessionS(SessionS t)
        {
            return SessionSBLL.CreateSessionSBLL().Upd(t);
        }
        #endregion

        #region 影厅
        /// <summary>
        /// 添加影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddMovieHall(MovieHall t)
        {
            return MovieHallBLL.CreateMovieHallBLL().Add(t);
        }
        /// <summary>
        /// 根据id删除影厅
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelMovieHall(int Id)
        {
            return MovieHallBLL.CreateMovieHallBLL().Del(Id);
        }
        /// <summary>
        /// 显示影厅信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedisValue[] ShowMovieHall()
        {
            var conn = RedisGetConn.GetConn();//获取连接源
            var db = conn.GetDatabase();//获取数据库
            if (!db.KeyExists("GetMovieHalls"))//如果数据库中不存在key为GetCustom的键 则创建一个sorted set有序集合
            {
                List<MovieHall> list = MovieHallBLL.CreateMovieHallBLL().Show();//接收数据库中的数据
                SortedSetEntry[] sortedset = new SortedSetEntry[list.Count];//创建一个数组 长度为数据库数据条数
                //遍历sql server数据库中的数据  加入数组
                for (int i = 0; i < list.Count; i++)
                {
                    var value = JsonConvert.SerializeObject(list[i]);
                    double did = Convert.ToDouble(list[i].HId);
                    SortedSetEntry sse = new SortedSetEntry(value, did);
                    sortedset[i] = sse;
                }
                db.SortedSetAdd("GetMovieHalls", sortedset);//将数据放入有序集合  key为GetCustom value为数据
                db.KeyExpire("GetMovieHalls", DateTime.Now.AddMinutes(3));//设置数据库中key为key为GetCustom的集合 过期时间为3分钟
            }
            RedisValue[] redis = db.SortedSetRangeByRank("GetMovieHalls");
            return redis;
        }
        /// <summary>
        /// 根据Id返填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public MovieHall ShowByIdMovieHall(int Id)
        {
            return MovieHallBLL.CreateMovieHallBLL().ShowById(Id);
        }
        /// <summary>
        /// 修改影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdMovieHall(MovieHall t)
        {
            return MovieHallBLL.CreateMovieHallBLL().Upd(t);
        }
        #endregion
        #region 微信端
        //获取今日影讯
        [HttpGet]
        public List<Movie> GetTodaymovie()
        {
            List<Movie> list = MovieBLL.CreateMovieBLL().Show();
            string dt = DateTime.Now.ToLongDateString();
            list = list.Where(s => s.M_Show.ToLongDateString().Contains(dt)).ToList();
            return list;
        }
        //获取即将上映影讯
        [HttpGet]
        public List<Movie> GetFuturemovie()
        {
            List<Movie> list = MovieBLL.CreateMovieBLL().Show();
            list = list.Where(s => s.M_Show > DateTime.Now.AddDays(1)).ToList();
            return list;
        }
        //小程序根据电影名称查询场次
        [HttpGet]
        public List<SessionS> ShowByMIdSessionS(int MId)
        {
            return SessionSBLL.CreateSessionSBLL().Show().Where(s => s.MovieId == MId).ToList();
        }
        #endregion
    }
}
