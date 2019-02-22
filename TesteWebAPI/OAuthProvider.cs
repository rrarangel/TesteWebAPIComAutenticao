using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using TesteWebAPI.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace TesteWebAPI
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                string username = context.UserName;
                string password = context.Password;

                Usuario user = new Usuario().Get(username, password);

                if(user != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.nome),
                        new Claim("UserID", user.login),
                        new Claim(ClaimTypes.Role, user.role)
                    };

                    ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new Microsoft.Owin.Security.AuthenticationTicket(OAuthIdentity, new Microsoft.Owin.Security.AuthenticationProperties() { }));
                }else
                {
                    context.SetError("Erro", "erro");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if(context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

    }
}