using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4Demo
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                // backward compat
                new ApiScope("api"),
                
                // more formal
                new ApiScope("api.scope1"),
                new ApiScope("api.scope2"),
                
                // scope without a resource
                new ApiScope("scope2"),
                
                // policyserver
                new ApiScope("policyserver.runtime"),
                new ApiScope("policyserver.management")
            };
        }
        
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "Demo API")
                {
                    ApiSecrets = { new Secret("secret".Sha256()) },
                    
                    Scopes = { "api", "api.scope1", "api.scope2" }
                },

                // PolicyServer demo (audience should match scope)
                new ApiResource("policyserver.runtime")
                {
                    Scopes = { "policyserver.runtime" }
                },
                new ApiResource("policyserver.management")
                {
                    Scopes = { "policyserver.runtime" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // oidc login only
                new Client
                {
                    ClientId = "login",
                    RequireClientSecret = false,
                    //RedirectUris = { "https://notused" },
                    //PostLogoutRedirectUris = { "https://notused" },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "openid", "profile", "email", "api" }
                }
            };
        }
    }
}
