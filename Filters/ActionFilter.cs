using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace Lr_11.Filters
{
    public class ActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string nameCont = context.RouteData.Values["controller"].ToString();
            string nameAction = context.RouteData.Values["action"].ToString();
            string logMessage = $"Action '{nameAction}' in controller '{nameCont}' is executing at {DateTime.Now}";

            string fileLocation = @"C:\Users\Vitalik\source\repos\Lr-11\Lr-11\ActionLog.txt";
            using (StreamWriter writer = new StreamWriter(fileLocation, true))
            {
                await writer.WriteLineAsync(logMessage);
            }
            await next();
        }

    }
}