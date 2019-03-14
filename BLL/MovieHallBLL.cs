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
        private static ICommon<MovieHall> bll;
        public MovieHallBLL()
        {
            if (bll == null)
            {
                bll = new MovieHallBLL() as ICommon<MovieHall>;
            }
        }
        /// <summary>
        /// 添加影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(MovieHall t)
        {
            return bll.Add(t);
        }
        /// <summary>
        /// 根据id删除影厅
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return bll.Del(Id);
        }
        /// <summary>
        /// 显示影厅信息
        /// </summary>
        /// <returns></returns>
        public List<MovieHall> Show()
        {
            return bll.Show();
        }
        /// <summary>
        /// 根据Id返填
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MovieHall ShowById(int Id)
        {
            return bll.ShowById(Id);
        }
        /// <summary>
        /// 修改影厅信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(MovieHall t)
        {
            return bll.Upd(t);
        }
    }
}
