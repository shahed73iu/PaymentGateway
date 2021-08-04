
//using Domain.Core.Bus;
//using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;


namespace PaymentGatewayIBMS
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            //services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            //{
            //    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            //    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            //});

            //Subscriptions

            // services.AddTransient<CreateClientAccountDemoEventHandler>();
            //services.AddTransient<EditUserInformationEventHandler>();

            //Domain Events

            //services.AddTransient<IEventHandler<CreateAccountEvent>, CreateAccountEventHandler>();
            //services.AddTransient<IEventHandler<EditPasswordEvent>, EditPasswordEventHandler>();

            //Domain Banking Commands

            // services.AddTransient<IRequestHandler<CreateUserCommand, bool>, CreateUserCommandHandler>();
            //services.AddTransient<IRequestHandler<EditRoleManagerCommand, bool>, EditRoleManagerCommandHandler>();

            //data
            //services.AddTransient<IBusinessType, BusinessType>();
            
        }
    }
}
