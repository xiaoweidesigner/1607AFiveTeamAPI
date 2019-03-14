using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DataService;

namespace BLL
{
   public  class MovieBLL
    {
        private static ICommon<Movie> bll;
        public MovieBLL()
        {
            if (bll == null)
            {
                bll = new MovieBLL() as ICommon<Movie>;
            }
        }
        /// <summary>
        /// 添加影片信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Movie t)
        {
            return bll.Add(t);
        }
        /// <summary>
        /// 根据id删除影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return bll.Del(Id);
        }
        /// <summary>
        /// 显示影片信息
        /// </summary>
        /// <returns></returns>
        public List<Movie> Show()
        {
            return bll.Show();
        }
        /// <summary>
        /// 根据Id查询影片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Movie ShowById(int Id)
        {
            return bll.ShowById(Id);
        }
        /// <summary>
        /// 修改影片信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Movie t)
        {
            return bll.Upd(t);
        }
    }
}
