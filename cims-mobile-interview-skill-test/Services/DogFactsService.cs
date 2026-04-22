using cims_mobile_interview_skill_test.Interfaces;
using cims_mobile_interview_skill_test.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace cims_mobile_interview_skill_test.Services;

public class DogFactsService : IDogFactsService
{
    #region Fields & proeprties

    private const string BASE_ADDRESS = "https://dogapi.dog/api/v2";

    private HttpClient _httpClient = new();

    #endregion

    #region Constructor

    public DogFactsService()
    {
        // Documentation found also at https://dogapi.dog/docs/api-v2

        _httpClient.Dispose();

        _httpClient = new();

        _httpClient.Timeout = TimeSpan.FromMilliseconds(350000);
    }


    #endregion

    #region Methods



    #endregion

    #region Request Methods

    private async Task<SimpleRestResponse<T>> RequestAsync<T>(HttpRequestMessage message)
    {
        HttpResponseMessage httpResponse = null;

        try
        {
            httpResponse = await _httpClient.SendAsync(message);

            string content = await httpResponse.Content.ReadAsStringAsync();

            httpResponse.EnsureSuccessStatusCode();

            var response = new SimpleRestResponse<T>
            {
                StatusCode = httpResponse.StatusCode,
                Data = await Task.Run(() => JsonConvert.DeserializeObject<T>(content))
            };

            return response;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            return new SimpleRestResponse<T>
            {
                StatusCode = (System.Net.HttpStatusCode)(httpResponse?.StatusCode != null ?
                httpResponse?.StatusCode : System.Net.HttpStatusCode.Gone),
                Data = default
            };
        }
    }

    #endregion

}
