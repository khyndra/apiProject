using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;
using ApiProject.Entities;
using ApiProject.Requests;

namespace ApiProject.Tests;

public class JsonPlaceholderTests
{
    RequestClass request = new RequestClass();

    [Test]
    public void SearchBook()
    {
        RestResponse response = request.GetApiRequest();
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var bodyContent = JsonSerializer.Deserialize<FakePostEntities>(response.Content!);
        bodyContent!.UserId.Should().Be(1);
        bodyContent!.Title.Should().Be("sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        bodyContent!.Body.Should().Be("quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto");
        Console.WriteLine($"Get response: Status = {response.StatusCode}, Content = {response.Content}");
    }

    [Test]
    public void CreateABook()
    {
        RestResponse response = request.PostApiRequest();
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Content.Should().NotBeNull();
        var bodyContent = JsonSerializer.Deserialize<FakePostEntities>(response.Content!);
        bodyContent!.UserId.Should().Be(12);
        bodyContent!.Title.Should().Be("This is a title");
        bodyContent!.Body.Should().Be("This is a body");
        Console.WriteLine($"Post response: Status = {response.StatusCode}, Content = {response.Content}");
    }

    [Test]
    public void UpdateABook()
    {
        RestResponse response = request.PutApiRequest();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var bodyContent = JsonSerializer.Deserialize<FakePostEntities>(response.Content!);
        bodyContent!.UserId.Should().Be(15);
        bodyContent!.Title.Should().Be("This is a title");
        bodyContent!.Body.Should().Be("This is a body");
        Console.WriteLine($"Put response: Status = {response.StatusCode}, Content = {response.Content}");
    }

    [Test]
    public void DeleteABook()
    {
        RestResponse response = request.DeleteApiRequest();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();

        using var doc = JsonDocument.Parse(response.Content!);
        doc.RootElement.ValueKind.Should().Be(JsonValueKind.Object);
        doc.RootElement.EnumerateObject().Should().BeEmpty();
        Console.WriteLine($"Delete response: Status = {response.StatusCode}, Content = {response.Content}");
    }
}