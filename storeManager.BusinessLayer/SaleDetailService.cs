using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using storeManager.Entities;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using storeManager.ViewModel;

namespace BusinessLayer
{
    public class SaleDetailService : ServiceBase<SaleDetail, int>, ISaleDetailService
    {
        private ISaleDetailRepository _saleDetailRepository;
        private ISaleService _sale;

        public SaleDetailService()
            : base(new SaleDetailRepository())
        {
            _saleDetailRepository = new SaleDetailRepository();
            _sale = new SaleService();
        }

        //#region ISaleDetailService Members

        //public List<SaleDetail> GetAllSaleDetails()
        //{
        //    return _saleDetailRepository.GetAll();
        //}

        //public SaleDetail GetSaleDetailByID(string id)
        //{
        //    return _saleDetailRepository.GetById(id);
        //}

        //public void AddSaleDetail(SaleDetail saleDetail)
        //{
        //    _saleDetailRepository.AddObject(saleDetail);
        //}

        //public void UpdateSaleDetail(SaleDetail saleDetail)
        //{
        //    _saleDetailRepository.SaveObject(saleDetail);
        //}

        //public void DeleteSaleDetail(SaleDetail saleDetail)
        //{
        //    _saleDetailRepository.DeleteObject(saleDetail);
        //}

        //#endregion

        //#region IService<SaleDetail,string> Members

        //public SaleDetail GetEntityID(string id)
        //{
        //    return _saleDetailRepository.GetById(id);
        //}

        //public List<SaleDetail> GetAll()
        //{
        //    return _saleDetailRepository.GetAll();
        //}

        //public void Add(SaleDetail bzEntity)
        //{
        //    _saleDetailRepository.AddObject(bzEntity);
        //}

        //public void Delete(SaleDetail bzEntity)
        //{
        //    _saleDetailRepository.DeleteObject(bzEntity);
        //}

        //public void Save(SaleDetail bzEntity)
        //{
        //    _saleDetailRepository.SaveObject(bzEntity);
        //}

        //#endregion

        public void ReverseSale(int saleID, bool voidSale)
        {
            List<SaleDetail> saleDetails = Query(s => s.SaleID == saleID).ToList();

            saleDetails.ForEach(s =>
            {
                int qty = s.Quantity;
                int locationid = s.LocationID.Value;
                int productid = int.Parse(s.ProductID);

                ProductLocation location = new GenericService<ProductLocation>().GetSingle(p => p.LocationID == locationid && p.ProductID == productid);

                location.Quantity += qty;

                new GenericService<ProductLocation>().Update(location, l => l.Id == location.Id);

            });

            Sale sale = _sale.GetSingle(so => so.SaleID == saleID);
            sale.VoidSale = voidSale;

            _sale.Update(sale, sa => sa.SaleID == saleID);
        }

        public void SaveChangesToAffectedProducts(List<AffectedProductsViewModel> affectedProducts)
        {
            foreach (var detail in affectedProducts)
            {
                SaleDetail saledetail = new SaleDetail
                {
                    SalesDetailsID = detail.SaleDetailID,
                    Quantity = detail.Quantity,
                    LineTotal = detail.LineTotal,
                    Discount = detail.LineDiscount,
                    ProductID = detail.ProductID.ToString(),
                    InvoiceNumber = detail.InvoiceNumber,
                    SaleID = detail.SaleID
                };

                switch (detail.State)
                {
                    case ProductState.Unchanged:
                        break;
                    case ProductState.Modified:
                        Update(saledetail, s => s.SalesDetailsID == detail.SaleDetailID);
                        break;
                    case ProductState.Deleted:
                        Delete(saledetail);
                        break;
                    case ProductState.Added:
                        if (detail.InvoiceNumber == null) break;

                        Add(saledetail);
                        break;
                }
            }
            //affectedProducts.ForEach(detail =>
            //{

            //});


        }
    }
}
