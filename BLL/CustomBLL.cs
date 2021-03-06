﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using MODEL;
using DAL;

namespace BLL
{
    //Custombll
    public class CustomBLL : ICommon<Custom>
    {
        #region 单例
        private static CustomBLL bll = null;
        private CustomBLL()
        {
        }
        public static CustomBLL CreateCustomBll()
        {
            if (bll == null)
            {
                bll = new CustomBLL();
            }
            return bll;
        }
        #endregion
        
        public int Add(Custom t)
        {
            return CustomDAL.CreateCustomDal().Add(t);
        }

        public int Del(int Id)
        {
            return CustomDAL.CreateCustomDal().Del(Id);
        }

        public List<Custom> Show()
        {
            return CustomDAL.CreateCustomDal().Show();
        }

        public Custom ShowById(int Id)
        {
            return CustomDAL.CreateCustomDal().ShowById(Id);
        }

        public int Upd(Custom t)
        {
            return CustomDAL.CreateCustomDal().Upd(t);
        }
        //修改用户名
        public int UpdCustomName(int CId, string C_Name)
        {
            return CustomDAL.CreateCustomDal().UpdCustomName(CId,C_Name);
        }
        //充值
        public int CZ(float C_integral, int CId)
        {
            return CustomDAL.CreateCustomDal().CZ(C_integral, CId);
        }
        //加入会员   将状态改为1,将个人资料完善   普通游客添加时名称一律使用游客  以手机号进行标识
        public int JoinHY(int CId, string C_Name,string Img)
        {
            return CustomDAL.CreateCustomDal().JoinHY(CId,C_Name,Img);
        }
        /// <summary>
        /// 根据手机号查询
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public List<Custom> shouCustomTel(string tel)
        {
            return CustomDAL.CreateCustomDal().shouCustomTel(tel);
        }
        //下单成功  减去个人余额
        public int UpdYuE(int CId, float C_integral)
        {
            return CustomDAL.CreateCustomDal().UpdYuE(CId, C_integral);
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public int UptCustomTelPhoto(string tel, string url)
        {
            return CustomDAL.CreateCustomDal().UptCustomTelPhoto(tel, url);
        }
    }
}
