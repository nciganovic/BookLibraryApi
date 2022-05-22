using Api.Core;
using Application;
using Application.Commands.MembershipCommands;
using Application.Interfaces;
using Application.MapperProfiles;
using DataAccess;
using Implementation.EfCommands.MembershipCommands;
using Implementation.Logging;
using Implementation.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            /*
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });*/

            services.AddTransient<IApplicationActor, FakeAdminActor>();

            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

            services.AddDbContext<BookLibraryContext>();
            services.AddTransient<IAddMembershipCommand, EfAddMembershipCommand>();
            services.AddTransient<IChangeMembershipCommand, EfChangeMembershipCommand>();
            services.AddTransient<IRemoveMembershipCommand, EfRemoveMembershipCommand>();

            services.AddTransient<AddMembershipValidator>();
            services.AddTransient<ChangeMembershipValidator>();

            services.AddAutoMapper(typeof(DefaultProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
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
