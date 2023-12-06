using BloodBank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace BloodBank.API.Extensions;

public static class Startup
{
    public static void ConfigureServices(this  WebApplicationBuilder builder)
    {
        var connectionString =
        builder.Configuration.GetValue<string>("DatabaseSettings:BookManagementConnectionString");

        // Contexts
        builder.Services.AddDbContext<BloodBankDbContext>(opts =>
                        opts.UseSqlServer(connectionString));

        // Validations
        //builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);
        //builder.Services.AddFluentValidationAutoValidation();

        // Automapper
        //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Repositories
        //builder.Services.AddTransient<IBookRepository, BookRepository>();
        //builder.Services.AddTransient<IUserRepository, UserRepository>();
        //builder.Services.AddTransient<IBorrowRepository, BorrowRepository>();

        // Services
        //builder.Services.AddTransient<IBookService, BookService>();
        //builder.Services.AddTransient<IUserService, UserService>();
        //builder.Services.AddTransient<IBorrowService, BorrowService>();

        // Hosted Services
        //builder.Services.AddHostedService<CheckNotReturnedBorrowsHostedService>();

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BookManagement.API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Dörr",
                    Email = "edudorr@hotmail.com",
                    Url = new Uri("https://github.com/EduardoDorr")
                }
            });
        });
    }
}
