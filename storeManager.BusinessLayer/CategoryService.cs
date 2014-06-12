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
    public class CategoryService : ServiceBase<Category, int>, ICategoryService
    {
        //private ICategoryRepository _categoryRepository;

        public CategoryService():base( new CategoryRepository())
        {
            //_categoryRepository = new CategoryRepository();
        }

        //#region ICategoryService Members

        //public List<Category> GetAllCategoties()
        //{
        //    return _categoryRepository.GetAll();
        //}

        //public Category GetByID(int id)
        //{
        //    return GetEntityID(id);
        //}

        //public void DeleteCategory(Category category)
        //{
        //    Delete(category);
        //}

        //public void SaveCategory(Category category)
        //{
        //    Save(category);
        //}

        //public void AddCategory(Category category)
        //{
        //    Add(category);
        //}

        //#endregion

        //#region IService<Category,int> Members


        //public List<Category> GetAll()
        //{
        //   return _categoryRepository.GetAll();
        //}

        //public void Add(Category bzEntity)
        //{
        //    _categoryRepository.AddObject(bzEntity);
        //}

        //public void Delete(Category bzEntity)
        //{
        //    _categoryRepository.DeleteObject(bzEntity);
        //}

        //public void Save(Category bzEntity)
        //{
        //    _categoryRepository.SaveObject(bzEntity);
        //}

        //public Category GetEntityID(int id)
        //{
        //   return _categoryRepository.GetById(id);
        //}

        //#endregion
    }
}
