// <copyright file="Startup.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookLibraryBusinessLogic.Data;
    using BookLibraryBusinessLogic.Service;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Swashbuckle.AspNetCore.Swagger;

    /// <summary>
    /// Class which serve in order to
    /// configurate web application
    /// start up settings.
    /// </summary>
    public class Startup
    {
        // Swagger constants
        private const string VERSION = "v.0.50";
        private const string API_NAME = "Library API";

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration of application.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// Adds services to the container.
        /// </summary>
        /// <param name="services">The services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDataProvider, LibraryDataProvider>();
            services.AddSingleton<ILibraryService, LibraryService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Swagger Setting
            Info info = new Info
            {
                Version = VERSION,
                Title = API_NAME,
                Description = API_NAME,

                // TermsOfService = "None",

                Contact = new Contact()
                {
                    Name = "Serhii Maksymchuk",
                    Email = "smakdealcase@gmail.com",
                    Url = "https://github.com/smoukiDev/SoftServeWebApiEssentials/tree/master"
                }
            };
            services.AddSwaggerGen(c => { c.SwaggerDoc(VERSION, info); });
        }

        /// <summary>
        /// Gets called by the runtime
        /// and configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// <see cref="IApplicationBuilder"/> object
        /// </param>
        /// <param name="env">
        /// <see cref="IHostingEnvironment"/> object
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Swagger Setting
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{VERSION}/swagger.json", API_NAME);
            });
        }
    }
}
