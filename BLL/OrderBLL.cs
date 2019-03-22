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
    public class OrderBLL
    {
        OrderDAL dal = new OrderDAL();
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Order t)
        {
            return dal.Add(t);
        }
        /// <summary>
        /// 根据ID删除订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return dal.Del(Id);

        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        public List<Order> Show()
        {
            return dal.Show();

        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Order ShowById(int Id)
        {
            return dal.ShowById(Id);

        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Order t)
        {
            return dal.Upd(t);

        }
        //修改订单状态 为已处理
        public int UpdOrderState(int OId)
        {
            return dal.UpdOrderState(OId);
        }
        /// <summary>
        /// 显示订单及订单有关系的表
        /// </summary>
        /// <returns></returns>
        public List<OMCH> ShowAll()
        {
            return dal.ShowAll();
        }
    }
}
