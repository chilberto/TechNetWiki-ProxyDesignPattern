using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using TechNetWikiProxyDesignPattern.Repository;

namespace TechNetWikiProxyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
    var serviceProvider = new ServiceCollection()
                                .AddTransient<IRegistrationViewModelProxy>(GetRegistrationViewModelProtectionProxy)     
                                .AddTransient<RegistrationRepository>()                                                         
                                .BuildServiceProvider();

            //configure console logging
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("TechNetWikiProxyDesignPattern.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            
            logger.LogDebug("Simple example of how the Proxy Design Pattern could be used.");
            logger.LogDebug("This example returns a collection of models representing item registrations.");
            logger.LogDebug("An item registration may contain sensitive information depending on who is view the data. Instead of using a different model for each");
            logger.LogDebug("condition or context and to keep the logic contained in a maintainable class whose responsibility is just to ensure the model is");
            logger.LogDebug("built appropriately, the Proxy Design Pattern is used.");            
            
            logger.LogDebug("The following is an example of how the model appears to a adminstrator who has full access to all information:");
            // set the role of the current user to Admin
            Security.CurrentUser = new User { UserName = "MrAdmin", Role = Role.Admin };
            RunIllustrationOfProxyDesign(serviceProvider, logger);

            logger.LogDebug("The following is an example of how the model appears to a buyer who should only see information relating to the item:");
            // set the role of the current user to User
            Security.CurrentUser = new User { UserName = "JoeUser", Role = Role.User };
            RunIllustrationOfProxyDesign(serviceProvider, logger);

            logger.LogDebug("End of example");
        }   
        
        private static void RunIllustrationOfProxyDesign(IServiceProvider serviceProvider, ILogger logger)
        {
            var repository = serviceProvider.GetService<RegistrationRepository>();
            var result = repository.GetRegistrationViewModels(1, 1);

            logger.LogInformation(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));
        }
        
        private static IRegistrationViewModelProxy GetRegistrationViewModelProtectionProxy(IServiceProvider arg)
        {
            // in Microsoft.AspNetCore.Http you could determine the user by checking their claims
            // var httpContextAccessor = arg.GetService<IHttpContextAccessor>();            

            // this does assume someone is set as currentuser
            switch(Security.CurrentUser.Role)
            {
                case Role.Admin: 
                    return new AdminRegistrationViewModelProxy();
                default: 
                    return new UserRegistrationViewModelProxy();
            }            
        }


    }
}
