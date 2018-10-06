using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using WebApi.BusinessEntities;
using WebApi.DataModels;
using WebApi.DataModels.UnitOfWork;
using AutoMapper;

namespace WebApi.BusinessServices
{
    public class ValueService : IValueService
    {
        private readonly UnitOfWork _unitOfWork;

        public ValueService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ValueEntity Add(ValueEntity valueEntity)
        {
            using (var scope = new TransactionScope())
            {
                var value = new Value
                {
                    id = valueEntity.id,
                    value = valueEntity.value
                };
                _unitOfWork.ValueRepository.Insert(value);

                _unitOfWork.Save();
                scope.Complete();
                return valueEntity;
            }
        }

        public IEnumerable<ValueEntity> GetValuesList()
        {
            var valuesList = _unitOfWork.ValueRepository.GetAll().ToList();

            if (valuesList.Any())
            {
                Mapper.CreateMap<Value, ValueEntity>();
                var valuesModel = Mapper.Map<List<Value>, List<ValueEntity>>(valuesList);
                return valuesModel;
            }

            return new List<ValueEntity>();
        }
    }
}