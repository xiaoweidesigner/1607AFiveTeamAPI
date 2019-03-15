using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using MODEL;

namespace RecallOnTime.Controllers
{
    public class LmqController : ApiController
    {
        MovieBLL movieBLL = new MovieBLL();//电影
        SessionSBLL sessionSBLL = new SessionSBLL();//场次
        MovieHallBLL hallBLL = new MovieHallBLL();//影厅
        #region  电影
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int AddMovie(Movie t)
        {
            return movieBLL.Add(t);
        }
        /// <summary>
        /// 根据id删除影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DelMovie(int Id)
        {
            return movieBLL.Del(Id);
        }
        /// <summary>
        /// 显示影片信息
        /// </summary>
        /// <returns></returns>
        public List<Movie> ShowMovie()
        {
            return movieBLL.Show();
        }
        /// <summary>
        /// 根据Id查询影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Movie ShowByIdMovie(int Id)
        {
            return movieBLL.ShowById(Id);
        }
        /// <summary>
        /// 修改影片信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int UpdMovie(Movie t)
        {
            return movieBLL.Upd(t);
        }
        #endregion

        #region  场次
        /// <summary>
        /// 添加场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int AddSessionS(SessionS t)
        {
            return sessionSBLL.Add(t);
        }
        /// <summary>
        /// 根据Id删除场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DelSessionS(int Id)
        {
            return sessionSBLL.Del(Id);
        }
        /// <summary>
        /// 显示场次信息
        /// </summary>
        /// <returns></returns>
        public List<SessionS> ShowSessionS()
        {
            return sessionSBLL.Show();
        }
        /// <summary>
        /// 根据Id查询场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SessionS ShowByIdSessionS(int Id)
        {
            return sessionSBLL.ShowById(Id);
        }
        /// <summary>
        /// 修改场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int UpdSessionS(SessionS t)
        {
            return sessionSBLL.Upd(t);
        }
        #endregion

        #region 影厅
        /// <summary>
        /// 添加影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int AddMovieHall(MovieHall t)
        {
            return hallBLL.Add(t);
        }
        /// <summary>
        /// 根据id删除影厅
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DelMovieHall(int Id)
        {
            return hallBLL.Del(Id);
        }
        /// <summary>
        /// 显示影厅信息
        /// </summary>
        /// <returns></returns>
        public List<MovieHall> ShowMovieHall()
        {
            return hallBLL.Show();
        }
        /// <summary>
        /// 根据Id返填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MovieHall ShowByIdMovieHall(int Id)
        {
            return hallBLL.ShowById(Id);
        }
        /// <summary>
        /// 修改影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int UpdMovieHall(MovieHall t)
        {
            return hallBLL.Upd(t);
        }
        #endregion
    }
}
