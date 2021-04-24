using AspDotNetCoreWebApi.API.Filter;
using AspDotNetCoreWebApi.Core.Repository;
using AspDotNetCoreWebApi.Core.Service;
using AspDotNetCoreWebApi.Core.UnitOfWork;
using AspDotNetCoreWebApi.Data;
using AspDotNetCoreWebApi.Data.Repository;
using AspDotNetCoreWebApi.Data.UnitOfWork;
using AspDotNetCoreWebApi.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspDotNetCoreWebApi.API.Extension;
using Microsoft.OpenApi.Models;

namespace AspDotNetCoreWebApi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // servisleri eklediğimiz yer
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Template API", Version = "V1"});
            });

            services.AddAutoMapper(typeof(Startup)); // automapper için eklendi

            services.AddScoped<NotFoundProductFilter>(); // NotFoundFilter constructor da interface aldığı için buraya kaydediyoruz

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // generic olduğu için IRepository<> deki <> koyuyoruz
            //IRepository i implement eden bir class ile karşılaştığında Repository.cs den bir instance yarat ve IRepository e ata

            services.AddScoped(typeof(IService<>), typeof(Service<>));

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => {

                    o.MigrationsAssembly("AspDotNetCoreWebApi.Data"); // AppDbContext data katmanında olduğu için verdik
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>(); // addscoped request atıldığında bir classın constructorında IUnitOfWork ile karşılaşırsa UnştOfWork den instance yaratıcak
            //aynı request içinde kullanılan birden fazla class da const unda IUnitOfWork varsa ilk yaratılan yerdeki instance ı kullanıcak. tekrardan new ile instance yaratmaycak. Performansa katkısı var.
            
            //services.AddControllers();

            services.AddControllers(o => 
            {
                o.Filters.Add(new ValidationFilter()); // validation filter ı tüm controller lara uyguluyor
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //  Api ye filterları kontrol etme ben kontrol edicem diyorum yani ProductDto daki spesifik olarak yazdıklarımızı görme onu tek yerden kontrol edicez. Yani kendimiz yazıcaz diyoruz
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // middleware leri eklediğimz yer yani katmanları
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCustomException(); // UseCustomExceptionHandler extension nındaki metodu kullandık burda

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
