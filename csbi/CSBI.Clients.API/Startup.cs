namespace CSBI.Clients.API
{
    using System;
    using AutoMapper;
    using BLL.Extensions;
    using Configuration;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using React.AspNet;
    using Swashbuckle.Swagger.Model;
    using Swashbuckle.SwaggerGen.Application;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        private static Action<SwaggerGenOptions> SwaggerGenOptions
        {
            get
            {
                return options =>
                {
                    options.SingleApiVersion(new Info
                    {
                        Version = "v1",
                        Title = "ToDo API",
                        Description = "Description",
                        TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = "Sergey Glazkov",
                            Email = "admin@sanqit.ru",
                            Url = "https://vk.com/sanqit"
                        },
                        License = new License { Name = "License" }
                    });
                };
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddMvc();

            if (SwaggerGenOptions != null)
            {
                services.AddSwaggerGen();

                services.ConfigureSwaggerGen(SwaggerGenOptions);
            }

            var connectionString = Configuration["Data:DefaultConnection:ConnectionString"];

            services.AddClientsService(connectionString);

            services.AddAutoMapper(typeof(MappingProfile), typeof(BLL.Configuration.MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseReact(config => { });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            if (SwaggerGenOptions != null)
            {
                app.UseSwagger();
                app.UseSwaggerUi();
            }
        }
    }
}
