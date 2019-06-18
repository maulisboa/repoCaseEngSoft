using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace caseEngSoftApi.Security
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //if (UsuariosSeguranca.Login(context.UserName, context.Password))
            //{
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    identity.AddClaim(new Claim("sub", context.UserName));
            //    identity.AddClaim(new Claim("role", "user"));
            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
            //    return;
            //}
        }
    }
}
