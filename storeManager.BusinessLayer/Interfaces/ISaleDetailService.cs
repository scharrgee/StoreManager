using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using storeManager.ViewModel;

namespace BusinessLayer.Interfaces
{
    public interface ISaleDetailService : IServiceBase<SaleDetail, string>
    {
        void ReverseSale(int saleID,bool voidSale);
        void SaveChangesToAffectedProducts(List<AffectedProductsViewModel> affectedProducts);
    }
}
