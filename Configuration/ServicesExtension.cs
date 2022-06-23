using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.Authentication;
using RapidPay.Database;
using RapidPay.Repositories;
using RapidPay.Repositories.Interfaces;
using RapidPay.Services;
using RapidPay.Services.Interfaces;

namespace RapidPay.Configuration
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<RapidPayContext>(opt => opt.UseInMemoryDatabase("RapidPay"));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICardService, CardService>();
            services.AddTransient<ICardRepository, CardRepository>();

            services.AddSingleton<IPaymentFeeService, PaymentFeeService>();
            services.AddTransient<IPaymentFeeRepository, PaymentFeeRepository>();

            services.AddAuthentication("BasicAuthentication")
                                        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                                        ("BasicAuthentication", null);

            return services;
        }
    }
}
