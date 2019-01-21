using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.Sfa.Business.Abstract;
using CT.Sfa.Business.Concrete;
using CT.Sfa.DataAccess.Abstract;
using CT.Sfa.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppContext = CT.Sfa.DataAccess.Concrete.EntityFramework.AppContext;

namespace CT.Sfa.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            //services.AddDbContext<AppContext>(options => options.UseOracle(@"User Id=DSS;Password=teneke;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.55.5.148)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=MOBMVCT)));"));

            services.AddSession();
            services.AddDistributedMemoryCache();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseFileServer();
            //app.UseNodeModules(env.ContentRootPath);

            app.UseSession();

            app.UseMvcWithDefaultRoute();
        }
    }
}
