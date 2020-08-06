using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Services;
using YouLearn.Infra.Persistence.EF;
using YouLearn.Infra.Persistence.Repositories;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            //Adicionando a injeção de dependência
            services.AddScoped<YouLearnContext, YouLearnContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddTransient<IServiceCanal, ServiceCanal>();
            //services.AddTransient<IServicePlayList, ServicePlayList>();
            //services.AddTransient<IServiceVideo, ServiceVideo>();
            services.AddTransient<IServiceUsuario, ServiceUsuario>();

            //services.AddTransient<IRepositoryCanal, RepositoryCanal>();
            //services.AddTransient<IRepositoryPlayList, RepositoryPlayList>();
            //services.AddTransient<IRepositoryVideo, RepositoryVideo>();
            services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();

            services.AddMvc();

            //Aplicando documentação com swagger
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "YouLearn", Version = "v1" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "YouLearn - V1");
            });
            
        }
    }
}
