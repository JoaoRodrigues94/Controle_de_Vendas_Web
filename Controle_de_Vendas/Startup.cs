﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Controle_de_Vendas.Data;
using Controle_de_Vendas.Servicos;
using System.Globalization;
using System.Collections.Generic;

namespace Controle_de_Vendas
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
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });


      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddDbContext<Controle_de_VendasContext>(options =>
              options.UseMySql(Configuration.GetConnectionString("Controle_de_VendasContext"), builder =>
builder.MigrationsAssembly("Controle_de_Vendas")));

      services.AddScoped<SeedingService>();
      services.AddScoped<ServicosVendedores>();
      services.AddScoped<ServicosDepartamento>();
      services.AddScoped<VendasRecordsServices>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
    {
      var enBR = new CultureInfo("en-BR");
      var localizationOptions = new RequestLocalizationOptions
      {
        DefaultRequestCulture = new RequestCulture(enBR),
        SupportedCultures = new List<CultureInfo> { enBR },
        SupportedUICultures = new List<CultureInfo> { enBR }
      };

      app.UseRequestLocalization(localizationOptions);

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        seedingService.Seed();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
