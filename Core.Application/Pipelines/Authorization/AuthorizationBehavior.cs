using Core.Security.Constants;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string> userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (userRoleClaims == null)
                throw new Exception("You are Not authenticated"); //buraya authexcp yapılcak unutma burayı unutmaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

            bool isNotMatchedAUserRoleClaimWithRequestRoles = userRoleClaims
                .FirstOrDefault(
                    userRoleClaims => userRoleClaims == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRoleClaims)
                )
                .IsNullOrEmpty();
            if (isNotMatchedAUserRoleClaimWithRequestRoles)
                throw new Exception("You are Not AutHORİZED");

            TResponse response = await next();

            return response;
        }
    }
}
