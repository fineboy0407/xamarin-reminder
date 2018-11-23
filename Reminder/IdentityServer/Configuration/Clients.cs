using System.Collections.Generic;
using IdentityServer4.Models;
using Reminder.Helpers;

namespace IdentityServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                // Angular client
                new Client {
                    ClientId = ConstantsHelper.AngularClientId,
                    ClientName = ConstantsHelper.AngularClientName,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = ConstantsHelper.AngularClientAllowedScopes,
                    RedirectUris = ConstantsHelper.AngularClientRedirectUris,
                    PostLogoutRedirectUris = ConstantsHelper.AngularClientPostLogoutRedirectUris,
                    AllowedCorsOrigins = ConstantsHelper.AngularClientAllowedCorsOrigins,
                    AllowAccessTokensViaBrowser = true
                },

                // Xamarin client
                new Client
                {
                    ClientId = ConstantsHelper.XamarinClientId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("MDXamarinClientSecretKey".Sha256())
                    },
                    AllowedScopes = { ConstantsHelper.ApiName }
                }
            };
        }
    }
}