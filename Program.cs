using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectCompany.Services;
using ProjectCompany.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using ProjectCompany.Models;

namespace ProjectCompany
{
    public class Program
    {

        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
