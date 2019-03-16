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
        private static SessionSBLL bll = null;
        private SessionSBLL()
        {
        }
        public static SessionSBLL CreateSessionSBLL()
        {
            if (bll == null)
            {
                bll = new SessionSBLL();
            }
            return bll;
        }
        /// <summary>
        /// 添加场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(SessionS t)
        {
            return SessionSDAL.CreateSessionSDAL().Add(t);
        }
        /// <summary>
        /// 根据Id删除场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return SessionSDAL.CreateSessionSDAL().Del(Id);
        }
        /// <summary>
        /// 显示场次信息
        /// </summary>
        /// <returns></returns>
        public List<SessionS> Show()
        {
            return SessionSDAL.CreateSessionSDAL().Show();
        }
        /// <summary>
        /// 根据Id查询场次
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SessionS ShowById(int Id)
        {
            return SessionSDAL.CreateSessionSDAL().ShowById(Id);
        }
        /// <summary>
        /// 修改场次信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(SessionS t)
        {
            return SessionSDAL.CreateSessionSDAL().Upd(t);
        }
    }
}
