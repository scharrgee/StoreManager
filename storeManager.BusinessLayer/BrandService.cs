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
    public class BrandService :ServiceBase<Brand,int>, IBrandService
    {
        //private IBrandRepository _brandRepository;

        public BrandService():base(new BrandRepository())
        {
            //_brandRepository = new BrandRepository();
        }

        //#region Wrapper Methods

        //public List<Brand> GetAllBrands()
        //{
        //    return GetAll();
        //}

        //public Brand GetById(int id)
        //{
        //   return GetEntityID(id);
        //}

        //public void DeleteBrand(Brand brand)
        //{
        //    Delete(brand);
        //}

        //public void SaveBrand(Brand brand)
        //{
        //    Save(brand);
        //}

        //public void AddBrand(Brand brand)
        //{
        //    Add(brand);
        //}

        //#endregion

        //#region IService<Brand,int> Members

        //public Brand GetEntityID(int id)
        //{
        //    return _brandRepository.GetById(id);
        //}

        //public List<Brand> GetAll()
        //{
        //    return _brandRepository.GetAll();
        //}

        //public void Add(Brand bzEntity)
        //{
        //    _brandRepository.AddObject(bzEntity);
        //}

        //public void Delete(Brand bzEntity)
        //{
        //    _brandRepository.DeleteObject(bzEntity);
        //}

        //public void Save(Brand bzEntity)
        //{
        //    _brandRepository.SaveObject(bzEntity);
        //}

        //#endregion
    }
}
