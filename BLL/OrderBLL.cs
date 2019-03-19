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
        //处理订单状态
        public int DisposedOrder(int Oid)
        {
            return dal.DisposedOrder(Oid);
        }
    }
}
