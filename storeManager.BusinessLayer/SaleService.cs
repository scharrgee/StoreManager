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
    public class SaleService : ServiceBase<Sale, int>, ISaleService
    {
        enum SaleStatus
        {
            Open = 1,
            Close = 2
        }

        private ISaleRepository _saleRepository;
        IErrorLogRepository _logger;


        public SaleService()
            : base(new SaleRepository())
        {
            _saleRepository = new SaleRepository();
            _logger = new ErrorLogRepository();
        }

        #region ISaleService Members

        //public List<Sale> GetAllSales()
        //{
        //    return _saleRepository.GetAll();
        //}

        //public Sale GetSaleByID(string id)
        //{
        //    return _saleRepository.GetById(id);
        //}

        //public void AddSale(Sale sale)
        //{
        //    _saleRepository.AddObject(sale);
        //}

        //public void UpdateSale(Sale sale)
        //{
        //    _saleRepository.SaveObject(sale);
        //}

        //public void DeleteSale(Sale sale)
        //{
        //    _saleRepository.DeleteObject(sale);
        //}


        public void RollBackSaleTransaction(string invoiceNo)
        {
            _saleRepository.RollBackSaleTransaction(invoiceNo);
        }

        public void CalculateLineTotal(int lineItmQty, decimal lineItmPrice, decimal tax, decimal discount, out decimal subTotal, out decimal total)
        {
            decimal lineTotal = lineItmPrice * lineItmQty;

            subTotal = 0;
            total = 0;

            if (discount == 0 && tax == 0)
            {
                subTotal = lineTotal;
                total = lineTotal;
            }
            else if (discount != 0 && tax == 0)
            {
                subTotal = lineTotal - discount;

                total = lineTotal - discount;
            }
            else if (discount == 0 && tax != 0)
            {
                subTotal = lineTotal;
                total = lineTotal + tax;
            }
            else if (discount != 0 && tax != 0)
            {
                subTotal = lineTotal - discount;
                total = (lineTotal - discount) + tax;
            }
        }

        public List<string> GetInvoiceNos(string invoiveNo)
        {
            return _saleRepository.GetInvoiceNos(invoiveNo);
        }

        #endregion

        //#region IService<Sale,string> Members

        //public Sale GetEntityID(string id)
        //{
        //    return _saleRepository.GetById(id);
        //}

        //public List<Sale> GetAll()
        //{
        //   return _saleRepository.GetAll();
        //}

        //public void Add(Sale bzEntity)
        //{
        //    _saleRepository.AddObject(bzEntity);
        //}

        //public void Delete(Sale bzEntity)
        //{
        //    _saleRepository.DeleteObject(bzEntity);
        //}

        //public void Save(Sale bzEntity)
        //{
        //    _saleRepository.SaveObject(bzEntity);
        //}

        //#endregion


        public decimal CalculateTax(decimal saleAmount, decimal tax)
        {
            try
            {
                decimal taxamount = ((tax / 100) * saleAmount);
                return taxamount;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }


        public int GetSaleStatus(decimal saleAmount, decimal amoutPaid)
        {
            try
            {
                return amoutPaid >= saleAmount ? (int)SaleStatus.Close : (int)SaleStatus.Open;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }
    }
}
