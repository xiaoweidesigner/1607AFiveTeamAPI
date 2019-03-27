﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using MODEL;

namespace DAL
{
    public class CustomDAL : ICommon<Custom>
    {
        #region 单例
        private static CustomDAL dal = null;
        private CustomDAL()
        {
        }
        public static CustomDAL CreateCustomDal()
        {
            if (dal == null)
            {
                dal = new CustomDAL();
            }
            return dal;
        }
        #endregion
        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(Custom t)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Custom.Add(t);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 删除顾客
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Del(int Id)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Custom.Remove(db.Custom.Where(s => s.CId == Id).FirstOrDefault());
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 显示顾客列表
        /// </summary>
        /// <returns></returns>
        public List<Custom> Show()
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                return db.Custom.ToList();
            }
        }
        /// <summary>
        /// 返回顾客个人信息资料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Custom ShowById(int Id)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                return db.Custom.Where(s => s.CId == Id).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改顾客资料
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upd(Custom t)
        {
            using (MyDbContext db=new MyDbContext())
            {
                db.Database.CreateIfNotExists();
                db.Entry<Custom>(t).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
        //充值  加积分
        public int CZ(float C_integral,int CId)
        {
            using (MyDbContext db=new MyDbContext())
            {
                int result = Convert.ToInt32(C_integral / 10);
                return db.Database.ExecuteSqlCommand($"update Customs set C_integral=C_integral+{C_integral},C_EndTime=C_EndTime+{result} Where CId={CId}");;
            }
        }
        //加入会员   将状态改为1,将个人资料完善   普通游客添加时名称一律使用游客  以手机号进行标识
        public int JoinHY(int CId,string C_Name,string Img)
        {
            using (MyDbContext db=new MyDbContext())
            {
                int result= db.Database.ExecuteSqlCommand($"update Customs set C_Name='{C_Name}',C_Phote='{Img}',C_State=1 where CId={CId}");
                return result;
            }
        }
        //下单成功  减去个人余额
        public int UpdYuE(int CId, float C_integral)
        {
            using (MyDbContext db=new MyDbContext())
            {
                int result= db.Database.ExecuteSqlCommand($"update Customs set C_integral=C_integral-{C_integral} where CId={CId}");
                return result;
            }
        }
    }
}
