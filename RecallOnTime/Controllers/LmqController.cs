using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using MODEL;
using Newtonsoft.Json;

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
        public List<Movie> ShowMovie()
        {
            return MovieBLL.CreateMovieBLL().Show();
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
        public List<SessionS> ShowSessionS()
        {
            return SessionSBLL.CreateSessionSBLL().Show();
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
        //小程序根据电影名称查询场次
        [HttpGet]
        public List<SessionS> ShowByMIdSessionS(int MId)
        {
            return ShowSessionS().Where(s => s.MovieId == MId).ToList();
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
        public List<MovieHall> ShowMovieHall()
        {
            return MovieHallBLL.CreateMovieHallBLL().Show();
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
            List<Movie> list = ShowMovie();
            string dt = DateTime.Now.ToLongDateString();
            list = list.Where(s => s.M_Show.ToLongDateString().Contains(dt)).ToList();
            return list;
        }
        //获取即将上映影讯
        [HttpGet]
        public List<Movie> GetFuturemovie()
        {
            List<Movie> list = ShowMovie();
            list = list.Where(s => s.M_Show>DateTime.Now.AddDays(1)).ToList();
            return list;
        }
        #endregion
    }
}
