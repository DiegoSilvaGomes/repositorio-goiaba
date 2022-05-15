using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Models;
using Microsoft.EntityFrameworkCore;
using Users.API.Data;

namespace Users.API.Services
{
    public static class DataBaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                .GetService<UserDbContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}