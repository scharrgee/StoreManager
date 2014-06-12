using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace BusinessLayer
{
    public class TaxService : ServiceBase<Tax, int>, ITaxService
    {
        private ITaxRepository _taxRepository;

        public TaxService():base(new TaxRepository())
        {
            _taxRepository = new TaxRepository();
        }

        //#region ITaxService Members

        //public List<Tax> GetAllTaxes()
        //{
        //   return _repository.GetAll();
        //}

        //public Tax GetTaxByID(int id)
        //{
        //  return  _repository.GetById(id);
        //}

        //#endregion

        //#region IService<Tax,int> Members

        //public Tax GetEntityID(int id)
        //{
        //    return _taxRepository.GetById(id);
        //}

        //public List<Tax> GetAll()
        //{
        //    return _taxRepository.GetAll();
        //}

        //public void Add(Tax bzEntity)
        //{
        //    _taxRepository.AddObject(bzEntity);
        //}

        //public void Delete(Tax bzEntity)
        //{
        //    _taxRepository.DeleteObject(bzEntity);
        //}

        //public void Save(Tax bzEntity)
        //{
        //    _taxRepository.SaveObject(bzEntity);
        //}

        //#endregion
    }
}
