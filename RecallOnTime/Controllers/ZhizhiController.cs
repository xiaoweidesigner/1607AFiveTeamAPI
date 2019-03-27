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
       
        //修改订单状态 为已取消
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
        #region 微信端
        //获取所有座位信息
        SeatBLL bl = new SeatBLL();
        [HttpGet]
        public List<Seat> GetSeats(int HId)
        {
            List<Seat> list= bl.Show().Where(s=>s.MovieHallId==HId).ToList();
            return list;
        }
        //更改座位状态
        [HttpGet]
        public int UpdSeatWX(string Ids)
        {
            string strResult = Ids.Substring(0,Ids.LastIndexOf(','));
            int result= seatBLL.UpdSeats(strResult);
            return result;
        }
        
        //添加订单 
        [HttpPost]
        public int AddOrderWX(Order o)
        {
            o.CO_State = 1;//默认  下订单
            o.O_State = 2;//默认  未处理
            o.O_STime = DateTime.Now;
            int result = orderBLL.Add(o);
            return result;
        }

        /// <summary>
        /// 根据手机号查询
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Custom> shouCustomTel(string tel)
        {
            return CustomBLL.CreateCustomBll().shouCustomTel(tel);
        }




        /// <summary>
        /// 未使用
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<UserOrder> orders1(string tel)
        {
            return orderBLL.orders1(tel);
        }
        /// <summary>
        /// 已完成
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<UserOrder> orders2(string tel)
        {
            return orderBLL.orders2(tel);
        }
        /// <summary>
        /// 已取消
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        [HttpGet]
        public List<UserOrder> orders3(string tel)
        {
            return orderBLL.orders3(tel);
        }
        #region 微信端
        //获取所有座位信息
        SeatBLL bl = new SeatBLL();
        [HttpGet]
        public List<Seat> GetSeats(int HId)
        {
            List<Seat> list = bl.Show().Where(s => s.MovieHallId == HId).ToList();
            return list;
        }
        //更改座位状态
        [HttpGet]
        public int UpdSeatWX(string Ids)
        {
            string strResult = Ids.Substring(0, Ids.LastIndexOf(','));
            int result = seatBLL.UpdSeats(strResult);
            return result;
        }

        //添加订单 
        [HttpPost]
        public int AddOrderWX(Order o)
        {
            o.CO_State = 1;//默认  下订单
            o.O_State = 2;//默认  未处理
            o.O_STime = DateTime.Now;
            int result = orderBLL.Add(o);
            return result;
        }
        //下单成功  减去个人余额
        [HttpPost]
        public int UpdYuE(Custom c)
        {
            int CId= c.CId;
            float C_integral = c.C_integral;
            return CustomBLL.CreateCustomBll().UpdYuE(CId,C_integral);
        }
        #endregion
    }
}
