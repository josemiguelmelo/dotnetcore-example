using System.Collections.Generic;
using WebApi.DataModels;
using WebApi.BusinessEntities;

namespace WebApi.BusinessServices
{
    public interface IValueService
    {
        IEnumerable<ValueEntity> GetValuesList();
        ValueEntity Add(ValueEntity value);
    }
}