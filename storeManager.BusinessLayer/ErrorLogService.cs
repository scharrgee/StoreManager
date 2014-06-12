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
    public class ErrorLogService : ServiceBase<ErrorLog, int>, IErrorService
    {
        IErrorLogRepository _logger;

        public ErrorLogService()
        {
            _logger = new ErrorLogRepository();
        }

        public void LogError(Exception ex, string message, string formName, string controlName)
        {
            try
            {
                _logger.LogError(ex, message, formName, controlName);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
