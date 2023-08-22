using EnginCan.Core.Elastic.Abstract;
using EnginCan.Core.Elastic.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using EnginCan.Core.Middleware;

namespace EnginCan.Core.Elastic.ActionFilters
{
    public class LoginLogFilter : IActionFilter
    {
        private readonly IElasticSearchService<LoginLogModel> _elasticSearchService;
        Microsoft.Extensions.Options.IOptions<ElasticConnectionSettings> _elasticConfig;
        private readonly ICustomHttpContextAccessor _customHttpContextAccessor;
        public LoginLogFilter(IElasticSearchService<LoginLogModel> elasticSearchService, Microsoft.Extensions.Options.IOptions<ElasticConnectionSettings> elasticConfig, ICustomHttpContextAccessor customHttpContextAccessor)
        {
            _elasticSearchService = elasticSearchService;
            _elasticConfig = elasticConfig;
            _customHttpContextAccessor = customHttpContextAccessor;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string action = (string)context.RouteData.Values["action"];
            string controller = (string)context.RouteData.Values["controller"];
            var result = context.Result;

            string userID = String.Empty;
            if (result.GetType() == typeof(UnauthorizedResult))
            {
                return;
            }

            userID = _customHttpContextAccessor.GetUserId().Value.ToString();

            LoginLogModel logModel = new LoginLogModel();
            logModel.Action = action;
            logModel.Controller = controller;
            logModel.PostDate = DateTime.Now;
            logModel.UserID = userID;
            _elasticSearchService.CheckExistsAndInsertLog(logModel, _elasticConfig.Value.ElasticLoginIndex);
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try { }
            catch (Exception ex)
            {
                //Forbidden 430 Result. Yetkiniz Yoktur..
                context.Result = new ObjectResult(context.ModelState)
                {
                    Value = "Geçerli Bir Token Girilmemiştir",
                    StatusCode = 430
                };
                return;
            }

        }
    }
}
