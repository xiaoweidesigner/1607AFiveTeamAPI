using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    //CRUD泛型接口
    public interface ICommon<T>
    {
        int Add(T t);
        int Del(int Id);
        List<T> Show();
        T ShowById(int Id);//反填
        int Upd(T t);
    }
}
