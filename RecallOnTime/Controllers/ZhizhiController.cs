using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecallOnTime.Controllers
{
    public class ZhizhiController : ApiController
    {

        #region 活动
        ActivityBLL activityBLL = new ActivityBLL();
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddActivity(Activity t)
        {
            return activityBLL.Add(t);
        }
        /// <summary>
        /// 根据ID删除活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelActivity(int Id)
        {
            return activityBLL.Del(Id);
        }
        /// <summary>
        /// 查询活动
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Activity> ShowActivity()
        {
            return activityBLL.Show();

        }
        /// <summary>
        /// 根据ID活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public Activity ShowByIdActivity(int Id)
        {
            return activityBLL.ShowById(Id);

        }
        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdActivity(Activity t)
        {
            return activityBLL.Upd(t);

        }
        #endregion



        #region 订单
        OrderBLL orderBLL = new OrderBLL();
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddOrder(Order t)
        {
            return orderBLL.Add(t);
        }
        /// <summary>
        /// 根据ID删除订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelOrder(int Id)
        {
            return orderBLL.Del(Id);

        }

        //修改订单状态 为已处理
        public int UpdOrderState(int OId)
        {
            return orderBLL.UpdOrderState(OId);
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Order> ShowOrder()
        {
            return orderBLL.Show();

        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public Order ShowByIdOrder(int Id)
        {
            return orderBLL.ShowById(Id);

        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdOrder(Order t)
        {
            return orderBLL.Upd(t);

        }
        /// <summary>
        /// 显示订单及订单有关系的表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<OMCH> ShowAll()
        {
            return orderBLL.ShowAll();
        }
        #endregion


        #region 座位
        SeatBLL seatBLL = new SeatBLL();
        /// <summary>
        /// 添加座位
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddSeat(Seat t)
        {
            return seatBLL.Add(t);
        }
        /// <summary>
        /// 根据ID删除座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelSeat(int Id)
        {
            return seatBLL.Del(Id);

        }
        /// <summary>
        /// 查询座位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Seat> ShowSeat()
        {
            return seatBLL.Show();

        }
        /// <summary>
        /// 根据ID座位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public Seat ShowByIdSeat(int Id)
        {
            return seatBLL.ShowById(Id);

        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdSeat(Seat t)
        {
            return seatBLL.Upd(t);

        }
        #endregion



        FinanceBLL financeBLL = FinanceBLL.CreateFinanceBLL();
        /// <summary>
        /// 根据年月日查询财务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DataTable ShowCaiwuRi(int year, int month, int day, int state)
        {

            return financeBLL.ShowCaiwuRi(year, month, day, state);
        }
        /// <summary>
        /// 根据年月日查询图表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public DataTable ShowTuBiaoRi(int year, int month, int day)
        {

            return financeBLL.ShowTuBiaoRi(year, month, day);
        }
        //小程序查询订单的座位信息
        //[HttpGet]
        //public List<dynamic> GetOrderBySId(int SId)
        //{
        //    var list = ShowOrder();
        //    var seat = list.Where(l=>l.SessionSId == SId).ToList();
        //    List<dynamic> seatList = new List<dynamic>();//所有座位
        //    foreach (var item in seat)
        //    {
        //        var seats =item.Number.Split('/');
        //        seatList.Add(seats);
        //    }
        //    return seatList;
        //}
    }
}
