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
   public  class SessionSBLL
    {
        private static ICommon<SessionS> bll;
        public SessionSBLL()
        {
            if (bll == null)
            {
                bll = new SessionSBLL() as ICommon<SessionS>;
            }
        }
        /// <summary>
        /// 添加场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(SessionS t)
        {
            return bll.Add(t);
        }
        /// <summary>
        /// 根据Id删除场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return bll.Del(Id);
        }
        /// <summary>
        /// 显示场次信息
        /// </summary>
        /// <returns></returns>
        public List<SessionS> Show()
        {
            return bll.Show();
        }
        /// <summary>
        /// 根据Id查询场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SessionS ShowById(int Id)
        {
            return bll.ShowById(Id);
        }
        /// <summary>
        /// 修改场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(SessionS t)
        {
            return bll.Upd(t);
        }
    }
}
