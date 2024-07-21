using ApiProject.Entities;
using RestSharp;

namespace ApiProject.Requests;

public class RequestClass
{
    static readonly string baseUrl = "https://jsonplaceholder.typicode.com/posts";

    public RestResponse GetApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        RestRequest restRequest = new RestRequest($"{baseUrl}/1", Method.Get);
        RestResponse restResponse = client.Execute(restRequest);
        Console.WriteLine($"Get request: Method = {restRequest.Method}, Resource = {restRequest.Resource}");

        return restResponse;
    }

    public static FakePostEntities BuildBodyRequest(int userId)
    {
        return new FakePostEntities
        {
            UserId = userId,
            Title = "This is a title",
            Body = "This is a body",
        };
    }

    public RestResponse PostApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        var body = BuildBodyRequest(12);
        RestRequest restRequest = new RestRequest(baseUrl, Method.Post);
        restRequest.AddBody(body, ContentType.Json);
        RestResponse restResponse = client.Execute(restRequest);
        Console.WriteLine($"Post request: Method = {restRequest.Method}, Resource = {restRequest.Resource}, Body = {body}");

        return restResponse;
    }

    public RestResponse PutApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        var body = BuildBodyRequest(15);
        RestRequest restRequest = new RestRequest($"{baseUrl}/1", Method.Put);
        restRequest.AddBody(body, ContentType.Json);
        RestResponse restResponse = client.Execute(restRequest);

        Console.WriteLine($"Put request: Method = {restRequest.Method}, Resource = {restRequest.Resource}, Body = {body}");

        return restResponse;
    }

    public RestResponse DeleteApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        RestRequest restRequest = new RestRequest($"{baseUrl}/1", Method.Delete);
        RestResponse restResponse = client.Execute(restRequest);

        Console.WriteLine($"Delete request: Method = {restRequest.Method}, Resource = {restRequest.Resource}");

        return restResponse;
    }
}