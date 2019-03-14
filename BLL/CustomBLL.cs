using System;
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
    }
}
