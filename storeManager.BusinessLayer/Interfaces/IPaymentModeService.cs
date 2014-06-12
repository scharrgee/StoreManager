using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IPaymentModeService
    {
        IEnumerable<PaymentMode> GetAllPaymentModes();
        PaymentMode GetPaymentModeByID(int id);
        PaymentMode[] GetPaymentModesArray();
    }
}
