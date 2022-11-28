There are 2 APIs
1. Identity - based on IdentityServer4 - OpenId and OAuth2
2. Veronica - ASP.NET Web API, has 2 controllers Menu and Order

Identity server implementation is completed from backend but frontend is not ready.

Both Menu and Order modules are implemented keeping distributed design in mind, 
has scope to be deployed as a separate services by creating dedicated API wrapper.

Menu and Order module both have tests written in xUnit, these are integration tests
