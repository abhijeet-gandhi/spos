using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Veronica.Identity
{
    public static class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
                new List<TestUser>
                {
                    new TestUser
                    {
                        Username = "john",
                        Password = "Pass@123!",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "John Wick"),
                            new Claim(JwtClaimTypes.WebSite, "https://github.com/"),
                            new Claim(JwtClaimTypes.Email, "john.wick@email.com")
                        },
                    },
                    new TestUser
                    {
                        Username = "spos",
                        Password = "Pass@123!",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Silverware Pos"),
                            new Claim(JwtClaimTypes.WebSite, "https://www.silverwarepos.com/"),
                            new Claim(JwtClaimTypes.Email, "info@silverwarepos.com")
                        },
                    }
                };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
                new ApiScope("pos")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
                new Client
                {
                    ClientId = "blackWidow",
                    ClientName = "Black Widow",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"http://localhost:4200/signing-callback"},
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "pos"
                    },
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    RequireClientSecret= false,
                    PostLogoutRedirectUris = new List<string> { "http://localhost4200/signout-callback"},
                    RequireConsent = false,
                    AccessTokenLifetime = 600
                }
            };
    }
}