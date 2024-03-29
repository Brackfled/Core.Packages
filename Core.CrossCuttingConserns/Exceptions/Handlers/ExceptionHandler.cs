﻿using Core.CrossCuttingConserns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {

        public Task HandleExceptionAsync(Exception exception) =>
            exception switch
            {
                BusinessException businessException => HandleException(businessException),
                ValidationException businessException => HandleException(businessException),
                AuthorizationException authorizationException => HandleException(authorizationException),
                _ => HandleException(exception)
            };

        protected abstract Task HandleException(BusinessException businessException);
        protected abstract Task HandleException(ValidationException businessException);
        protected abstract Task HandleException(AuthorizationException authorizationException);
        protected abstract Task HandleException(Exception exception);

    }
}
