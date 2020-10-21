using FluentAssertions;
using Kalibrate.Chuck.Norris.Models;
using Kalibrate.Chuck.Norris.Services;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kalibrate.Chuck.Norris.Tests.Services.ChuckNorrisServiceTests
{
    public class Search
    {
        private const string ValidJsonJokes = "{\"total\": 2, \"result\": [{ \"value\": \"This is a joke.\" },{ \"value\": \"This is our only other joke.\" }]}";
        private Mock<HttpMessageHandler> _httpClientHander;
        private ChuckNorrisService _service;

        public Search()
        {
            var httpClientFactory = new Mock<IHttpClientFactory>();
            _httpClientHander = new Mock<HttpMessageHandler>();
            httpClientFactory
                .Setup(cf => cf.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(_httpClientHander.Object));
            _service = new ChuckNorrisService(httpClientFactory.Object);
        }

        [Fact]
        public async Task Given_A_Valid_Response_Should_Return_Jokes()
        {
            //Given the request returns a valid response stream
            GivenAnHttpResponseOf(h =>
            {
                h.StatusCode = HttpStatusCode.OK;
                h.Content = new StringContent(ValidJsonJokes);
            });

            //When we call the client to search for jokes
            var result = await _service.Search("test");

            //Should return jokes
            result.Should().BeEquivalentTo(
                new List<Joke>
                {
                    new Joke { Value = "This is a joke." },
                    new Joke { Value = "This is our only other joke." }
                }
            );
        }

        [Fact]
        public async Task Given_An_Unsuccessful_Response_Should_Throw()
        {
            //Given the request indicated the response is unsuccessful
            GivenAnHttpResponseOf(h =>
            {
                h.StatusCode = HttpStatusCode.BadRequest;
            });

            //When we call the client to search jokes it should throw
            await Assert.ThrowsAsync<Exception>(async () => await _service.Search("test"));
        }

        [Fact]
        public async Task Given_Query_Is_Passed_Should_Pass_In_Correct_Format()
        {
            //Given the request returns a valid response stream
            GivenAnHttpResponseOf(h =>
            {
                h.StatusCode = HttpStatusCode.OK;
                h.Content = new StringContent(ValidJsonJokes);
            });

            //When we call the client with "test"
            await _service.Search("test");

            //Then we should call the client with the string "test" as a query param
            _httpClientHander
                .Protected()
                .Verify("SendAsync", Times.Once()
                    , ItExpr.Is<HttpRequestMessage>(hrm => hrm.RequestUri == new Uri("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/search?query=test"))
                    , ItExpr.IsAny<CancellationToken>());
        }

        private void GivenAnHttpResponseOf(Action<HttpResponseMessage> responseModifications)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            responseModifications(response);

            _httpClientHander
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
                ).ReturnsAsync(response);
        }
    }
}