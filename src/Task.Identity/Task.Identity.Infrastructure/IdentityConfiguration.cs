using IdentityServer4.Models;

namespace Tasks.Identity.Infrastructure
{
    public class IdentityConfiguration
    {
        public static IEnumerable<Client> GetClients()
        {
            yield return new Client
            {
                ClientId = "m2m.client",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("FC2D2DCE-91F6-48ED-991F-8B1B7C1DB055".Sha256()) },

                AllowedScopes = { "M2mClient" }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("ServerAPI", "Server API");
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Address();
            yield return new IdentityResources.Email();
            yield return new IdentityResources.Profile();
        }

        public static IEnumerable<ApiScope> GetScopes()
        {
            yield return new ApiScope("ServerAPI", "Server API");
            yield return new ApiScope("M2mClient", "M2m Client");
        }
    }
}
