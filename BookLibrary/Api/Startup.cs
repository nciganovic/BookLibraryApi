using Api.Core;
using Application;
using Application.Commands.Authors;
using Application.Commands.Books;
using Application.Commands.Categories;
using Application.Commands.Formats;
using Application.Commands.Languages;
using Application.Commands.MembershipCommands;
using Application.Commands.Publishers;
using Application.Commands.Roles;
using Application.Interfaces;
using Application.MapperProfiles;
using Application.Queries.Authors;
using Application.Queries.Books;
using Application.Queries.Categories;
using Application.Queries.Format;
using Application.Queries.Language;
using Application.Queries.Memberships;
using Application.Queries.Publishers;
using Application.Queries.Roles;
using DataAccess;
using Implementation.EfCommands.BookCommands;
using Implementation.EfCommands.FormatCommands;
using Implementation.EfCommands.LanguageCommands;
using Implementation.EfCommands.MembershipCommands;
using Implementation.EfCommands.PublisherCommands;
using Implementation.EfCommands.RoleCommands;
using Implementation.Logging;
using Implementation.Queries.AuthorQueries;
using Implementation.Queries.BookQueries;
using Implementation.Queries.CategoryQueries;
using Implementation.Queries.FormatQueries;
using Implementation.Queries.LanguageQueries;
using Implementation.Queries.MembershipQueries;
using Implementation.Queries.PublisherQueries;
using Implementation.Queries.RoleQueries;
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
            services.AddTransient<IGetOneMembershipQuery, EfGetOneMembershipQuery>();
            services.AddTransient<IGetMembershipsQuery, EfGetMembershipsQuery>();
            services.AddTransient<AddMembershipValidator>();
            services.AddTransient<ChangeMembershipValidator>();

            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IChangeRoleCommand, EfChangeRoleCommand>();
            services.AddTransient<IRemoveRoleCommand, EfRemoveRoleCommand>();
            services.AddTransient<IGetOneRoleQuery, EfGetOneRoleQuery>();
            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<AddRoleValidator>();
            services.AddTransient<ChangeRoleValidator>();

            services.AddTransient<IAddLanguageCommand, EfAddLanguageCommand>();
            services.AddTransient<IChangeLanguageCommand, EfChangeLanguageCommand>();
            services.AddTransient<IRemoveLanguageCommand, EfRemoveLanguageCommand>();
            services.AddTransient<IGetOneLanguageQuery, EfGetOneLanguageQuery>();
            services.AddTransient<IGetLanguagesQuery, EfGetLanguagesQuery>();
            services.AddTransient<AddLanguageValidator>();
            services.AddTransient<ChangeLanguageValidator>();

            services.AddTransient<IAddPublisherCommand, EfAddPublisherCommand>();
            services.AddTransient<IChangePublisherCommand, EfChangePublisherCommand>();
            services.AddTransient<IRemovePublisherCommand, EfRemovePublisherCommand>();
            services.AddTransient<IGetOnePublisherQuery, EfGetOnePublisherQuery>();
            services.AddTransient<IGetPublishersQuery, EfGetPublishersQuery>();
            services.AddTransient<AddPublisherValidator>();
            services.AddTransient<ChangePublisherValidator>();

            services.AddTransient<IAddFormatCommand, EfAddFormatCommand>();
            services.AddTransient<IChangeFormatCommand, EfChangeFormatCommand>();
            services.AddTransient<IRemoveFormatCommand, EfRemoveFormatCommand>();
            services.AddTransient<IGetOneFormatQuery, EfGetOneFormatQuery>();
            services.AddTransient<IGetFormatsQuery, EfGetFormatsQuery>();
            services.AddTransient<AddFormatValidator>();
            services.AddTransient<ChangeFormatValidator>();

            services.AddTransient<IAddCategoryCommand, EfAddCategoryCommand>();
            services.AddTransient<IChangeCategoryCommand, EfChangeCategoryCommand>();
            services.AddTransient<IRemoveCategoryCommand, EfRemoveCategoryCommand>();
            services.AddTransient<IGetOneCategoryQuery, EfGetOneCategoryQuery>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<AddCategoryValidator>();
            services.AddTransient<ChangeCategoryValidator>();

            services.AddTransient<IAddAuthorCommand, EfAddAuthorCommand>();
            services.AddTransient<IChangeAuthorCommand, EfChangeAuthorCommand>();
            services.AddTransient<IRemoveAuthorCommand, EfRemoveAuthorCommand>();
            services.AddTransient<IGetOneAuthorQuery, EfGetOneAuthorQuery>();
            services.AddTransient<IGetAuthorsQuery, EfGetAuthorsQuery>();
            services.AddTransient<AddAuthorValidator>();
            services.AddTransient<ChangeAuthorValidator>();

            services.AddTransient<IAddBookCommand, EfAddBookCommand>();
            services.AddTransient<IChangeBookCommand, EfChangeBookCommand>();
            services.AddTransient<IRemoveBookCommand, EfRemoveBookCommand>();
            services.AddTransient<IGetOneBookQuery, EfGetOneBookQuery>();
            services.AddTransient<IGetBooksQuery, EfGetBooksQuery>();
            services.AddTransient<AddBookValidator>();
            services.AddTransient<ChangeBookValidator>();

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
