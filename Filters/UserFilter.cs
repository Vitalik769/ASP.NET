using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace Lr_11.Filters
{
    public class UniqueFilter : IAsyncActionFilter
    {
        private readonly string _fileLocation = "UniqueUser.txt";

        public UniqueFilter()
        {
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string userIdentifier = context.HttpContext.Connection.RemoteIpAddress.ToString();

            string[] existingUsers = File.Exists(_fileLocation) ? File.ReadAllLines(_fileLocation) : Array.Empty<string>();

            if (!existingUsers.Contains(userIdentifier))
            {
                File.AppendAllLines(_fileLocation, new[] { userIdentifier });
            }

            await LogUniqueUsers();
            await next();
        }

        private async Task LogUniqueUsers()
        {
            string[] allUsers = File.Exists(_fileLocation) ? File.ReadAllLines(_fileLocation) : Array.Empty<string>();
            int uniqueUsersCount = allUsers.Distinct().Count();

            string logMessage = $"Number of unique users: {uniqueUsersCount}";
            await File.WriteAllTextAsync("UniqueUsersCount.txt", logMessage);
        }
    }
}