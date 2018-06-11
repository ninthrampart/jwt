using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        private ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        //public CustomExceptionFilterAttribute(
        //    IHostingEnvironment hostingEnvironment,
        //    IModelMetadataProvider modelMetadataProvider)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //    _modelMetadataProvider = modelMetadataProvider;
        //}

        public override void OnException(ExceptionContext context)
        {
            //if (!_hostingEnvironment.IsDevelopment())
            //{
            //    // do nothing
            //    return;
            //}
            //var result = new ViewResult { ViewName = "CustomError" };
            //result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            //result.ViewData.Add("Exception", context.Exception);
            // TODO: Pass additional detailed data via ViewData
            

            _logger.LogError(new EventId(0), "Test exception");
            _logger.LogError(new EventId(), "Intercepted by CustomExceptionFilterAttribute");
            _logger.LogWarning("Unauthorized Access in Controller Filter.");
            context.HttpContext.Response.StatusCode = 400;

            var a = context.RouteData.DataTokens;
            var b = context.RouteData.Routers;
            var c = context.RouteData.Values["action"];
            var d = context.RouteData.Values["controller"];

            context.Result = new JsonResult("Test exception");
            

        }
    }
}
