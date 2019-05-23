using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using FluentSim;
using Newtonsoft.Json.Linq;


namespace MissileLauncherTests
{
    [TestFixture]
    public class ApiTests
    {
        private FluentSimulator _simulator;
        private ApiGateway _apiGateway;


        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetRequestTest()
        {
            var response = new ApiResponse {Success = true};
            _simulator = new FluentSimulator("http://localhost:8050/");
            _simulator.Get("/api/v2/users").Responds(response);
            _simulator.Start();
            _apiGateway = new ApiGateway("http://localhost:8050/");
            var apiResponse = _apiGateway.RetrieveData();
            apiResponse.Success.Should().BeTrue();
            _simulator.Stop();
        }
    }

    public class ApiGateway
    {
        private readonly HttpClient _client;

        public ApiGateway(string address)
        {
            _client = new HttpClient { BaseAddress = new Uri(address) };
        }

        public ApiResponse RetrieveData()
        {
            var response = GetApiResponse("/api/v2/users");
            response.Wait();
            
            return response.Result.ToObject<ApiResponse>();
        }

        private async Task<JObject> GetApiResponse(string address)
        {
            var response = await _client.GetAsync(address);
            
            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
    }
}