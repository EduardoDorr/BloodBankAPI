using System.Reflection;
using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using FluentValidation;
using FluentValidation.AspNetCore;

using BloodBank.Domain.Interfaces;
using BloodBank.Infrastructure.Data;
using BloodBank.Infrastructure.Repositories;
using BloodBank.Application.Donors.Services;
using BloodBank.Application.Donations.Services;
using BloodBank.Application.BloodStorage.Services;

namespace BloodBank.API.Extensions;

public static class Startup
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString =
        builder.Configuration.GetValue<string>("DatabaseSettings:BloodBankConnectionString");

        // Contexts
        builder.Services.AddDbContext<BloodBankDbContext>(opts =>
                        opts.UseSqlServer(connectionString));

        // Validations
        builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies(), ServiceLifetime.Transient);
        builder.Services.AddFluentValidationAutoValidation();

        // Automapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Repositories
        builder.Services.AddTransient<IDonorRepository, DonorRepository>();
        builder.Services.AddTransient<IDonationRepository, DonationRepository>();
        builder.Services.AddTransient<IBloodStorageRepository, BloodStorageRepository>();

        // Services
        builder.Services.AddTransient<IDonorService, DonorService>();
        builder.Services.AddTransient<IDonationService, DonationService>();
        builder.Services.AddTransient<IBloodStorageService, BloodStorageService>();

        // Hosted Services
        //builder.Services.AddHostedService<VerifyBloodStorageHostedService>();

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
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
