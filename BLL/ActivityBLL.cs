using DAL;
using DataService;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ActivityBLL
    {
        ActivityDAL dal = new ActivityDAL();
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Activity t)
        {
            return dal.Add(t);
        }
        /// <summary>
        /// 根据ID删除活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return dal.Del(Id);
        }
        /// <summary>
        /// 查询活动
        /// </summary>
        /// <returns></returns>
        public List<Activity> Show()
        {
            return dal.Show();

        }
        /// <summary>
        /// 根据ID活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Activity ShowById(int Id)
        {
            return dal.ShowById(Id);

        }
        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Activity t)
        {
            return dal.Upd(t);

        }


    }
}
