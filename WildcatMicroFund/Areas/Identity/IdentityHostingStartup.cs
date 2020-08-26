using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WildcatMicroFund.Areas.Identity.Data;
using WildcatMicroFund.Data;
using WildcatMicroFund.Data.Context;

[assembly: HostingStartup(typeof(WildcatMicroFund.Areas.Identity.IdentityHostingStartup))]
namespace WildcatMicroFund.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            

            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WildcatMicroFundAccountDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WildcatMicroFundAccountDbContextConnection")));

                //testing
                services.AddDbContext<WildcatMicroFundDatabaseContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Amazon")));

                services.AddDefaultIdentity<WildcatMicroFundUserAccount>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WildcatMicroFundAccountDbContext>();
            });
        }
    }
}