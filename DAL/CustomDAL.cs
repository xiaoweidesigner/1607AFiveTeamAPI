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
    }
}