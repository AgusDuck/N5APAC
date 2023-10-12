using System;
using System.Reflection.Metadata;
using System.Security.Authentication;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using PAC.IBusinessLogic;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private IStudentLogic _studentLogic;


        public AuthorizationFilter()
        {
        }

        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            this._studentLogic = context.HttpContext.RequestServices.GetService<IStudentLogic>();
            StringValues token;
            Exception exception = new AuthenticationException("No puedo authorizarme");
            ErrorDTO error = new ErrorDTO();
            try
            {
                context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            }
            catch(ArgumentNullException ex)
            {
                error.IsSuccess = false;
                error.ErrorMessage= exception.Message;
                error.Content = exception.Message;
                error.Code = 401;

            }
            //401 Unauthorized “No puedo authorizarme”
        }

    }
}

