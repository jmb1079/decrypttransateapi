using DecryptTranslateApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.AzureAppServices;

namespace DecryptTranslateApi
{
    public class Startup
    {
        public IConfiguration Configuration{get;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.Configure<AzureFileLoggerOptions>(Configuration.GetSection("AzureLogging"));
            services.AddDbContext<CaseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddDbContext<OrganizationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddDbContext<InvestigatorContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddDbContext<ImageContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            
            //services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}