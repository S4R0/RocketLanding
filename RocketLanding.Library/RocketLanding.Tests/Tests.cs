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
    }
}
