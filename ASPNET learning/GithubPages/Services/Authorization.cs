namespace GithubPages.Services
{
    /// <summary>
    /// Service to handle authorization logic for administrative endpoints using an API Key.
    /// </summary>
    public class AdminAuthorizationService
    {
        private readonly string _adminApiKey;
        private const string ApiKeyHeaderName = "x-api-key";

        // Inject IConfiguration to securely load the key from appsettings.json
        public AdminAuthorizationService(IConfiguration configuration)
        {
            // Fetches the key from the "AdminApiKey" setting in appsettings.json
            // IMPORTANT: Add "AdminApiKey": "YOUR_SUPER_SECRET_KEY" to your appsettings.json
            _adminApiKey = configuration["AdminApiKey"] ?? throw new InvalidOperationException("AdminApiKey configuration setting is missing or empty.");
        }

        /// <summary>
        /// Checks the HTTP request for a valid API key header.
        /// </summary>
        /// <param name="context">The current HttpContext.</param>
        /// <returns>IResult (e.g., Results.Unauthorized()) if check fails, otherwise null.</returns>
        public IResult? Authorize(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeader))
            {
                //Key header missing
                return Results.Unauthorized();
            }

            if (apiKeyHeader.ToString() != _adminApiKey)
            {
                //Key is incorrect
                return Results.Unauthorized();
            }

            //Key is correct
            return Results.Ok();
        }
    }
}
