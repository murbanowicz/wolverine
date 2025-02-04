// <auto-generated/>
#pragma warning disable
using Marten;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_orders_create3
    public class POST_orders_create3 : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Marten.ISessionFactory _sessionFactory;

        public POST_orders_create3(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Marten.ISessionFactory sessionFactory) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
            _sessionFactory = sessionFactory;
        }



        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            await using var documentSession = _sessionFactory.OpenSession();
            try
            {
                var (command, jsonContinue) = await ReadJsonAsync<WolverineWebApi.Marten.StartOrder>(httpContext);
                if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
                (var creationResponse_response, var startStream) = WolverineWebApi.Marten.MarkItemEndpoint.StartOrder3(command);
                
                // Placed by Wolverine's ISideEffect policy
                startStream.Execute(documentSession);

                ApplyHttpAware(creationResponse_response, httpContext);
                
                // Commit any outstanding Marten changes
                await documentSession.SaveChangesAsync(httpContext.RequestAborted).ConfigureAwait(false);

                await WriteJsonAsync(httpContext, creationResponse_response);
            }


            catch(Marten.Exceptions.ExistingStreamIdCollisionException e)
            {
                await WolverineWebApi.Marten.StreamCollisionExceptionPolicy.RespondWithProblemDetails(e, httpContext);
                return;
            }


        }

    }

    // END: POST_orders_create3
    
    
}

