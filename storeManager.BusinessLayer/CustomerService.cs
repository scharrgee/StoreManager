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
    public class CustomerService : ServiceBase<Customer, int>, ICustomerService
    {
       // private ICustomerRepository _customerRepository;

        public CustomerService():base(new CustomerRepository())
        {
            //_customerRepository = new CustomerRepository();       
        }
        //#region Wrapper Method

        //public List<Customer> GetAllCustomers()
        //{
        //    return GetAll();
        //}

        //public Customer GetByID(string id)
        //{
        //    return GetEntityID(id);
        //}

        //#endregion

        //#region IService<Customer,string> Members

        //public Customer GetEntityID(string id)
        //{
        //    return _customerRepository.GetById(id);
        //}

        //public List<Customer> GetAll()
        //{
        //    return _customerRepository.GetAll();
        //}

        //public void Add(Customer bzEntity)
        //{
        //    _customerRepository.AddObject(bzEntity);
        //}

        //public void Delete(Customer bzEntity)
        //{
        //    _customerRepository.DeleteObject(bzEntity);
        //}

        //public void Save(Customer bzEntity)
        //{
        //    _customerRepository.SaveObject(bzEntity);
        //}

        //#endregion
    }
}
