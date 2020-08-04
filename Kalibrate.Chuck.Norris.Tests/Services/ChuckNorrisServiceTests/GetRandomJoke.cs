using FluentAssertions;
using Kalibrate.Chuck.Norris.Models;
using Kalibrate.Chuck.Norris.Services;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kalibrate.Chuck.Norris.Tests.Services.ChuckNorrisServiceTests
{
    public class GetRandomJoke
    {
        private const string ValidJsonJoke = "{ \"value\": \"This is a joke.\", \"\": \"\" }";
        private Mock<HttpMessageHandler> _httpClientHander;
        private ChuckNorrisService _service;

        public GetRandomJoke()
        {
            var httpClientFactory = new Mock<IHttpClientFactory>();
            _httpClientHander = new Mock<HttpMessageHandler>();
            httpClientFactory
                .Setup(cf => cf.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(_httpClientHander.Object));
            _service = new ChuckNorrisService(httpClientFactory.Object);
        }

        [Fact]
        public async Task Given_A_Valid_Response_Should_Return_Joke()
        {
            //Given the request returns a valid response stream
            GivenAnHttpResponseOf(h =>
            {
                h.StatusCode = HttpStatusCode.OK;
                h.Content = new StringContent(ValidJsonJoke);
            });

            //When we call the client for a random joke
            var result = await _service.GetRandomJoke();

            //Should return a the joke returned by the client
            result.Should().BeEquivalentTo(new Joke { Value = "This is a joke." });
        }

        [Fact]
        public async Task Given_An_Unsuccessful_Response_Should_Throw()
        {
            //Given the request indicated the response is unsuccessful
            GivenAnHttpResponseOf(h =>
            {
                h.StatusCode = HttpStatusCode.BadRequest;
            });

            //When we call the client for a random joke it should throw
            await Assert.ThrowsAsync<Exception>(async () => await _service.GetRandomJoke());
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