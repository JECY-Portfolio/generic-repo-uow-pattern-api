using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace generic_repo_pattern_api.CustomHealthCheck
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly HttpClient _httpClient;

        public ApiHealthCheck(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("https://localhost:7089/api/ProductWithGenericRepo");
             
            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(new HealthCheckResult(
                    status: HealthStatus.Healthy,
                    description: "The Api is up and running."
                    ));
            }
                return await Task.FromResult(new HealthCheckResult(
                    status: HealthStatus.Unhealthy,
                    description: "The Api is down."
                    ));
        }
    }
}
