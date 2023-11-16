using CoffeeShop.Api.Core;
using CoffeeShop.Api.Extensions;
using CoffeeShop.Application.Emails;
using CoffeeShop.Application.Logging;
using CoffeeShop.Application.UseCases.Commands.Baverages;
using CoffeeShop.Application.UseCases.Commands.Categories;
using CoffeeShop.Application.UseCases.Commands.Ingredients;
using CoffeeShop.Application.UseCases.Commands.Orders;
using CoffeeShop.Application.UseCases.Commands.Reservations;
using CoffeeShop.Application.UseCases.Commands.User;
using CoffeeShop.Application.UseCases.Queries.Baverages;
using CoffeeShop.Application.UseCases.Queries.Categories;
using CoffeeShop.Application.UseCases.Queries.Ingredients;
using CoffeeShop.Application.UseCases.Queries.Reservations;
using CoffeeShop.Application.UseCases.Queries.Users;
using CoffeeShop.DataAccess;
using CoffeeShop.Implementation;
using CoffeeShop.Implementation.Emails;
using CoffeeShop.Implementation.Logging;
using CoffeeShop.Implementation.UseCases.Commands.Baverage;
using CoffeeShop.Implementation.UseCases.Commands.Categories;
using CoffeeShop.Implementation.UseCases.Commands.Ingredients;
using CoffeeShop.Implementation.UseCases.Commands.Orders;
using CoffeeShop.Implementation.UseCases.Commands.Reservations;
using CoffeeShop.Implementation.UseCases.Commands.User;
using CoffeeShop.Implementation.UseCases.Queries;
using CoffeeShop.Implementation.UseCases.Queries.Baverage;
using CoffeeShop.Implementation.UseCases.Queries.Ingredients;
using CoffeeShop.Implementation.UseCases.Queries.Reservations;
using CoffeeShop.Implementation.UseCases.Queries.Users;
using CoffeeShop.Implementation.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CaffeShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var settings = new AppSettings();

            Configuration.Bind(settings);
            services.AddSingleton(settings);
            services.AddApplicationUser();
            services.AddJwt(settings);

            //services.AddTransient<Context>(x =>
            //{
            //    return new Context();
            //});

            services.AddTransient<Context>(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var conn = Configuration.GetSection("ConnString").Value;

                optionsBuilder.UseSqlServer(conn);

                var options = optionsBuilder.Options;

                return new Context(options);
            });

            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, UpdateCategoryCommand>();
            services.AddTransient<IGetOneCategoryQuery, GetOneCategoryQuery>();
            services.AddTransient<IChangeStatusOfCategoryCommand, ChangeStatusOfCategoryCommand>();

            services.AddTransient<CreateIngredientValidator>();
            services.AddTransient<IGetIngredientsQuery, GetIngredientsQuery>();
            services.AddTransient<IGetOneIngredientQuery, GetOneIngredientQuery>();
            services.AddTransient<IUpdateIngredientCommand, UpdateIngredientCommand>();
            services.AddTransient<ICreateIngredientCommand, CreateIngredientCommand>();
            services.AddTransient<IChangeStatusOfIngredientCommand, ChangeStatusOfIngredientCommand>();

            services.AddTransient<RegisterUserValidator>(); 
            services.AddTransient<IGetOneUserQuery, GetOneUserQuery>();
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IGetUsersQuery, GetUsersQuery>();
            services.AddTransient<IChangeStatusOfUserCommand, ChangeStatusOfUserCommand>();

            services.AddTransient<CreateBaverageValidator>();
            services.AddTransient<IGetBaveragesQuery, GetBaveragesQuery>();
            services.AddTransient<IGetOneBaverageQuery, GetOneBaverageQuery>();
            services.AddTransient<ICreateBaverageCommand, CreateBaverageCommand>();

            services.AddTransient<ICreateReservationCommand, CreateReservationCommand>();
            services.AddTransient<IGetReservationQuery, GetReservationsQuery>();

            services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
            
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IEmailSender>(x =>
            new SmtpEmailSender(settings.EmailOptions.FromEmail,
                               settings.EmailOptions.Password,
                               settings.EmailOptions.Port,
                               settings.EmailOptions.Host));
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoffeShop.Api", Version = "v1" });
                //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoffeeShop.Api v1"));
            }

            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            //app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
