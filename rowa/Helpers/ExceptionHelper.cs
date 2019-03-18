using rowa.repository.Entities;
using rowa.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rowa.Helpers
{
    public class ExceptionHelper
    {
        private readonly IErrorLoggingRepository _errorLoggingRepository;

        public ExceptionHelper(IErrorLoggingRepository errorLoggingRepository)
        {
            _errorLoggingRepository = errorLoggingRepository;
        }

        public void LogError(Exception ex, int parentId = 0)
        {
            var error = new ErrorLog
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                LogDate = DateTime.UtcNow,
                IsInner = parentId > 0,
                ParentId = parentId,
                Server = Environment.MachineName
            };

            _errorLoggingRepository.Add(error);

            if (ex.InnerException != null)
            {
                LogError(ex.InnerException, error.Id);
            }
        }
    }
}