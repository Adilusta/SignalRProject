using SignalR.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class,IEntity,new()
    {
        void TAdd(TEntity entity);
        void TDelete(TEntity entity);
        void TUpdate(TEntity entity);
        TEntity TGetById(int id);
        List<TEntity> TGetListAll();
    }
}
