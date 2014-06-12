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
    public class PaymentModeService : ServiceBase<PaymentMode, int>, IPaymentModeService
    {
        private IPaymentModeRepository _repository;
        IErrorLogRepository _logger;

        public PaymentModeService():base(new PaymentModeRepository())
        {
            _repository = new PaymentModeRepository();
            _logger = new ErrorLogRepository();
        }

        #region IPaymentModeService Members

        public IEnumerable<PaymentMode> GetAllPaymentModes()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        public PaymentMode GetPaymentModeByID(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
           
        }

        public PaymentMode[] GetPaymentModesArray()
        {
            try
            {
                return _repository.GetPaymentModes();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred", "", "");
                throw;
            }
            
        }

        #endregion
    }
}
