using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;
using Reminder.Helpers;

namespace IdentityServer.Configuration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                // some standard scopes from the OIDC spec
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),

                // custom identity resource with some consolidated claims
                new IdentityResource("custom.profile", new[] { JwtClaimTypes.Name, JwtClaimTypes.Id, JwtClaimTypes.Email, "location" })
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            var apiResources = new List<ApiResource>
            {
                new ApiResource(ConstantsHelper.ApiName, ConstantsHelper.ApiName)
            };
            return apiResources;
        }
    }
}