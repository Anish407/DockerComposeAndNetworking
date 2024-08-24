using System.Text.Json;
using API.Core.Models;

namespace API1.Infra.HttpClients;

public class Api2Client
{
    private readonly HttpClient _httpClient;

    public Api2Client(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DataModel>> GetDataFromApi2()
    {
        // use this if we want to access another api that is running locally,
        // because within the container localhost wud mean a service running within the container and
        // not on the host.. so if we need to call any service that is running on the host and not inside the container then
        // we use the below value
        // var url = "http://host.docker.internal:7070";
        var response = await _httpClient.GetAsync("http://api2:5179/api/GetEmployees");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<DataModel>>(content);
    }
}

