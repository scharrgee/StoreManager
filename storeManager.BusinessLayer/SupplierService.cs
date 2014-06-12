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
    public class SupplierService : ServiceBase<Supplier, int>, ISupplierService
    {
        private ISupplierRepository _supplierRepository;
        
        public SupplierService():base(new SupplierRepository())
        {
            _supplierRepository = new SupplierRepository();
        }

        //#region ISupplierService Members

        //public List<Supplier> GetAllSuppliers()
        //{           
        //    return _supplierRepository.GetAll();
        //}

        //public Supplier GetByID(string id)
        //{
        //    return _supplierRepository.GetById(id);
        //}

        //#endregion



        //#region IService<Supplier,string> Members

        //public Supplier GetEntityID(int id)
        //{
        //   return _supplierRepository.GetById(id);
        //}

        //public List<Supplier> GetAll()
        //{
        //    return _supplierRepository.GetAll();
        //}

        //public void Add(Supplier bzEntity)
        //{
        //    _supplierRepository.AddObject(bzEntity);
        //}

        //public void Delete(Supplier bzEntity)
        //{
        //    _supplierRepository.DeleteObject(bzEntity);
        //}

        //public void Save(Supplier bzEntity)
        //{
        //    _supplierRepository.SaveObject(bzEntity);
        //}



        //#endregion
    }
}
