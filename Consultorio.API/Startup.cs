using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Application.Service;
using Consultorio.Application.Service.Interface;
using Consultorio.Domain.Repository;
using Consultorio.Infra.Data.Context;
using Consultorio.Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Consultorio.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", buider =>
                {
                    buider
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .Build();

                });
            });

            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();
            services.AddScoped<IMedicoService, MedicoService>();

            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();

            services.AddDbContextPool<ConsultorioContext>(this.Builder());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("EnableCORS");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public Action<DbContextOptionsBuilder> Builder()
        {
            Action<SqlServerDbContextOptionsBuilder> sqlOptions = null;
            var migrationsAssemblyName = "Consultorio.Infra.Data.Migrations";
            if (!string.IsNullOrEmpty(migrationsAssemblyName))
                sqlOptions = (options) => options.MigrationsAssembly(migrationsAssemblyName);
            
            return options => options.UseSqlServer(this.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value, sqlOptions);
        }
    }
}
