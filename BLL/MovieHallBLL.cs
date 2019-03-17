using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;
using DataService;

namespace BLL
{
   public  class MovieHallBLL
    {
        private static MovieHallBLL bll = null;
        private MovieHallBLL()
        {
        }
        public static MovieHallBLL CreateMovieHallBLL()
        {
            if (bll == null)
            {
                bll = new MovieHallBLL();
            }
            return bll;
        }
        /// <summary>
        /// 添加影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(MovieHall t)
        {
            return MovieHallDAL.CreateMovieHallDAL().Add(t);
        }
        /// <summary>
        /// 根据id删除影厅
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return MovieHallDAL.CreateMovieHallDAL().Del(Id);
        }
        /// <summary>
        /// 显示影厅信息
        /// </summary>
        /// <returns></returns>
        public List<MovieHall> Show()
        {
            return MovieHallDAL.CreateMovieHallDAL().Show();
        }
        /// <summary>
        /// 根据Id返填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MovieHall ShowById(int Id)
        {
            return MovieHallDAL.CreateMovieHallDAL().ShowById(Id);
        }
        /// <summary>
        /// 修改影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(MovieHall t)
        {
            return MovieHallDAL.CreateMovieHallDAL().Upd(t);
        }
        /// <summary>
        /// 打扫卫生能看到的该打扫的影厅信息
        /// </summary>
        /// <returns></returns>
        public List<MovieHall> SH()
        {
            return MovieHallDAL.CreateMovieHallDAL().SH();
        }
    }
}
