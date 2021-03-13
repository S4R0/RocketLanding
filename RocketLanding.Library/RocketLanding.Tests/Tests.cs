using Microsoft.Extensions.DependencyInjection;
using RocketLanding.Services;
using Xunit;

namespace RocketLanding.Tests
{
    public class Tests
    {
        private readonly IRocketLandingService _rocketLandingService;

        public Tests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IRocketLandingService, RocketLandingService>();
            _rocketLandingService = serviceCollection.BuildServiceProvider().GetService<IRocketLandingService>();
        }

        [Fact]
        public void CheckTrajectory_CorrectTrajectory_False()
        {
            var result = _rocketLandingService.CheckTrajectory(16, 15);
            Assert.Equal(Constants.outPlatform, result);
        }

        [Fact]
        public void CheckTrajectory_CorrectTrajectory_True()
        {
            var result = _rocketLandingService.CheckTrajectory(5, 5);
            Assert.Equal(Constants.ok, result);
        }

        [Fact]
        public void AskLanding_CorrectPosition_True()
        {
            var result = _rocketLandingService.AskLanding(5, 5);
            Assert.Equal(Constants.ok, result);
        }

        [Fact]
        public void AskLanding_CorrectPosition_False()
        {
            var result = _rocketLandingService.AskLanding(19, 92);
            Assert.Equal(Constants.outPlatform, result);
        }

        [Fact]
        public void AskLanding_ClashPosition_True()
        {
            var firstRocketLandingResult = _rocketLandingService.AskLanding(7, 12);
            Assert.Equal(Constants.ok, firstRocketLandingResult);

            var secondRocketLandingResult = _rocketLandingService.AskLanding(7, 12);
            Assert.Equal(Constants.clash, secondRocketLandingResult);

            for (var x = 8; x >= 6; x--)
            {
                for (var y = 13; y >= 11; y--)
                {
                    secondRocketLandingResult = _rocketLandingService.AskLanding(x, y);
                    Assert.Equal(Constants.clash, secondRocketLandingResult);
                }
            }
        }

        [Fact]
        public void AskLanding_ClashPosition_False()
        {
            var firstRocketLandingResult = _rocketLandingService.AskLanding(7, 12);
            Assert.Equal(Constants.ok, firstRocketLandingResult);

            var secondRocketLandingResult = _rocketLandingService.AskLanding(7, 10);
            Assert.Equal(Constants.ok, secondRocketLandingResult);
        }
    }
}
