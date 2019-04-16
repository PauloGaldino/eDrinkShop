using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECOMMERCE.UI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Infra.Data.Repositories;
using Domain.Interfaces.IPessoas;
using Infra.Data.Repositories.RPessoas;
using Application.Interfaces.IAppPessoas;
using Infra.Data.Data.Context;
using Application.Aplications.AppPessoas;
using Domain.Interfaces.IUser;
using Infra.Data.Identity;
using Application.Interfaces.IAppPessoas.IAppProfissoes;
using Domain.Interfaces.IPessoas.IProfissoes;
using Infra.Data.Repositories.RPessoas.RProfissoes;
using Application.Aplications.AppPessoas.AppProfissoes;
using Infra.Data.Repositories.RPessoas.RProfissoaes;
using Application.Aplications.AppContatos;
using Application.Interfaces.IAppContatos;
using Infra.Data.Repositories.RContatos;
using Domain.Interfaces.IContatos;

namespace ECOMMERCE.UI
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<ContextoGeral>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();


            services.AddSingleton(typeof(IGenerica<>), typeof(RepositorioGenerico<>));
            services.AddSingleton<IPessoaTipo, PessoaTipoRepositorio>();
            services.AddSingleton<IAppPessoaTipo, AppPessoaTipo>();

            services.AddSingleton<IPessoa, PessoaRepositorio>();
            services.AddSingleton<IAppPessoa, AppPessoa>();

            services.AddSingleton<IFisica, FisicaRepositorio>();
            services.AddSingleton<IAppFisica, AppFisica>();

            services.AddSingleton<IJuridica, JuridicaRepositorio>();
            services.AddSingleton<IAppJuridica, AppJuridica>();

            services.AddSingleton<ICliente, ClienteRepositorio>();
            services.AddSingleton<IAppCliente, AppCliente>();

            services.AddSingleton<IAppProfissao, AppProfissao>();
            services.AddSingleton<IProfissao, ProfissaoRepositorio>();

            services.AddSingleton<IAppProfissaoPessoa, AppProfissaoPessoa>();
            services.AddSingleton<IProfissaoPessoa, ProfissaoPessoaRepositorio>();

            services.AddSingleton<IAppTelefoneTipo, AppTeleFoneTipo>();
            services.AddSingleton<ITelefoneTipo, TelefoneTipoRepositorio>();

            services.AddSingleton<IAppContato, AppContato>();
            services.AddSingleton<IContato, ContatoRepositorio>();

            services.AddSingleton<IAppEmail, AppEmail>();
            services.AddSingleton<IEmail, EmailRepositorio>();

            services.AddSingleton<IAppEndereco, AppEndereco>();
            services.AddSingleton<IEndereco, EnderecoRepositorio>();

            services.AddSingleton<IAppEnderecoPessoa, AppEnderecoPessoa>();
            services.AddSingleton<IEnderecoPessoa, EnderecoPessoaRepositorio>();

            services.AddSingleton<IAppEnderecoCliente, AppEnderecoCliente>();
            services.AddSingleton<IEnderecoCliente, EnderecoClienteRepositorio>();


            services.AddSingleton<IAppProfissaoCliente, AppProfissaoCliente>();
            services.AddSingleton<IProfissaoCliente, ProfissaoClienteRepositorio>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pessoa}/{action=Index}/{id?}");
            });
        }
    }
}
