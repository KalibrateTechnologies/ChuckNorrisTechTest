using FluentAssertions;
using Kalibrate.Chuck.Norris.Controllers;
using Kalibrate.Chuck.Norris.Models;
using Kalibrate.Chuck.Norris.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Kalibrate.Chuck.Norris.Tests.Controllers.ChuckNorrisControllerTests
{
    public class Get
    {
        private Mock<IChuckNorrisService> _chuckNorrisService;
        private ChuckNorrisController _controller;

        public Get()
        {
            _chuckNorrisService = new Mock<IChuckNorrisService>();
            _controller = new ChuckNorrisController(_chuckNorrisService.Object);
        }

        [Fact]
        public async Task Given_Random_Joke_Is_Returned_Should_Return_Random_Joke()
        {
            // Given a valid return from the chuck norris service
            _chuckNorrisService
                .Setup(x => x.GetRandomJoke())
                .ReturnsAsync(new Joke
                {
                    Value = "This is a random joke (decided fairly via dice roll by the dev team)"
                });

            //When we call the controller
            var result = await _controller.Get();

            // Then we should have a joke returned to us
            result.Value.Should().BeEquivalentTo(new Joke { Value = "This is a random joke (decided fairly via dice roll by the dev team)" });
        }
    }
}