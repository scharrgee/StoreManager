using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using storeManager.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        StoreManagerDBEntities ctx;

        public ErrorLogRepository()
        {
            ctx = new Connection().GetContext(); ;
        }

        public void LogError(Exception ex, string message, string formName, string controlName)
        {
            if (ex == null) return;

            string InnerExeptionMessage = ex.InnerException == null ? "" : ex.InnerException.Message;
            string InnerExceptionStackTrace = ex.InnerException == null ? "" : ex.InnerException.StackTrace;
            try
            {
                ErrorLog errorlog = new ErrorLog
                {
                    CustomMessage = message,
                    ExceptionMessage = ex.Message,
                    ExceptionStackTrace = ex.StackTrace,
                    InnerExceptionStackTrace = InnerExceptionStackTrace,
                    InnerExeptionMessage = InnerExeptionMessage,
                    FormName = formName,
                    ControlName = controlName,
                    ExceptionDate = DateTime.Now
                };

                ctx.ErrorLogs.AddObject(errorlog);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
