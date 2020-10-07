using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Arif.JWTAuthentication.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class, ITable, new()
    {
        private readonly IGenericService<TEntity> _genericService;

        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var keyValuePair = context.ActionArguments.FirstOrDefault(I => I.Key == "id");
            var checkedId = (int)keyValuePair.Value;

            // ReSharper disable once AsyncConverter.AsyncWait
            var entity = _genericService.GetByIdAsync(checkedId).Result;

            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{checkedId} değeri ile eşleşen bir kayıt bulunamadı");
            }
        }
    }
}
