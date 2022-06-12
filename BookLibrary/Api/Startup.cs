using Api.Core;
using Api.Middleware;
using Application;
using Application.Commands.Account;
using Application.Commands.Authors;
using Application.Commands.Books;
using Application.Commands.Categories;
using Application.Commands.Formats;
using Application.Commands.Languages;
using Application.Commands.MembershipCommands;
using Application.Commands.Publishers;
using Application.Commands.Reservations;
using Application.Commands.RoleCases;
using Application.Commands.Roles;
using Application.Commands.Users;
using Application.Email;
using Application.Interfaces;
using Application.MapperProfiles;
using Application.Queries.Authors;
using Application.Queries.Books;
using Application.Queries.Categories;
using Application.Queries.Format;
using Application.Queries.Language;
using Application.Queries.Memberships;
using Application.Queries.Publishers;
using Application.Queries.Reservations;
using Application.Queries.RoleCases;
using Application.Queries.Roles;
using Application.Queries.UseCaseLogs;
using Application.Queries.Users;
using Application.Settings;
using AutoMapper;
using DataAccess;
using Implementation.EfCommands.AccountCommands;
using Implementation.EfCommands.BookCommands;
using Implementation.EfCommands.FormatCommands;
using Implementation.EfCommands.LanguageCommands;
using Implementation.EfCommands.MembershipCommands;
using Implementation.EfCommands.PublisherCommands;
using Implementation.EfCommands.ReservationCommands;
using Implementation.EfCommands.RoleCaseCommands;
using Implementation.EfCommands.RoleCommands;
using Implementation.EfCommands.UserCommands;
using Implementation.Email;
using Implementation.Logging;
using Implementation.Queries.AuthorQueries;
using Implementation.Queries.BookQueries;
using Implementation.Queries.CategoryQueries;
using Implementation.Queries.FormatQueries;
using Implementation.Queries.LanguageQueries;
using Implementation.Queries.MembershipQueries;
using Implementation.Queries.PublisherQueries;
using Implementation.Queries.ReservationQueries;
using Implementation.Queries.RoleQueries;
using Implementation.Queries.RoleUseCaseQueries;
using Implementation.Queries.UseCaseLogQueries;
using Implementation.Queries.UserQueries;
using Implementation.Validator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Text;

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

            //services.AddTransient<IApplicationActor, FakeAdminActor>();

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
            services.AddTransient<IChangeBookAuthorsCommand, EfChangeBookAuthorsCommand>();
            services.AddTransient<AddBookValidator>();
            services.AddTransient<ChangeBookValidator>();
            services.AddTransient<ChangeBookAuthorValidator>();

            services.AddTransient<IAddUserCommand, EfAddUserCommand>();
            services.AddTransient<IChangeUserCommand, EfChangeUserCommand>();
            services.AddTransient<IRemoveUserCommand, EfRemoveUserCommand>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<AddUserValidator>();
            services.AddTransient<ChangeUserValidator>();

            services.AddTransient<IAddReservationCommand, EfAddReservationCommand>();
            services.AddTransient<IChangeReservationCommand, EfChangeReservationCommand>();
            services.AddTransient<IRemoveReservationCommand, EfRemoveReservationCommand>();
            services.AddTransient<IGetOneReservationQuery, EfGetOneReservationQuery>();
            services.AddTransient<IGetReservationsQuery, EfGetReservationsQuery>();
            services.AddTransient<AddReservationValidator>();
            services.AddTransient<ChangeReservationValidator>();

            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();

            services.AddTransient<LoginValidator>();
            services.AddTransient<RegisterValidator>();
            services.AddTransient<ChangeProfileValidator>();
            services.AddTransient<IRegisterCommand, EfRegisterCommand>();
            services.AddTransient<IChangeProfileCommand, EfChangeProfileCommand>();

            services.AddTransient<IGetCasesByRoleIdQuery, EfGetCasesByRoleIdQuery>();
            services.AddTransient<IAddRoleCaseCommand, EfAddRoleCaseCommand>();
            services.AddTransient<IGetOneRoleCaseQuery, EfGetOneRoleUseCaseQuery>();
            services.AddTransient<IRemoveRoleCaseCommand, EfRemoveRoleCaseCommand>();
            services.AddTransient<AddRoleCaseValidator>();
            services.AddTransient<RemoveRoleCaseValidator>();

            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddTransient<JwtManager>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            services.AddHttpContextAccessor();
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
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidateIssuer = true,
                    ValidAudience = Configuration["JwtSettings:Audience"],
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Secret"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //services.AddAutoMapper(typeof(DefaultProfile));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DefaultProfile(provider.GetService<BookLibraryContext>()));
            }).CreateMapper());
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
