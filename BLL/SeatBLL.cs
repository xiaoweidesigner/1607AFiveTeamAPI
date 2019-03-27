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
    public class SeatBLL
    {
        SeatDAL dal = new SeatDAL();
        /// <summary>
        /// 添加座位
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Seat t)
        {
            return dal.Add(t);
        }
        /// <summary>
        /// 根据ID删除座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            return dal.Del(Id);

        }
        /// <summary>
        /// 查询座位
        /// </summary>
        /// <returns></returns>
        public List<Seat> Show()
        {
            return dal.Show();

        }
        /// <summary>
        /// 根据ID座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Seat ShowById(int Id)
        {
            return dal.ShowById(Id);

        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Seat t)
        {
            return dal.Upd(t);

        }
        public int UpdSeats(string Ids)
        {
            return dal.UpdSeats(Ids);
        }

    }
}
