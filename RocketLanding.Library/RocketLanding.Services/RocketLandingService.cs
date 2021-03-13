using Microsoft.Extensions.Configuration;
using System;

namespace RocketLanding.Services
{
    public class RocketLandingService : IRocketLandingService
    {
        private readonly IConfiguration _configuration;
        private static string[,] _landingArea = new string[101, 101];

        public RocketLandingService(IConfiguration configuration)
        {
            _configuration = configuration;

            InitLandingArea();
            InitLandingPlatform();
        }

        #region public methods
        public string CheckTrajectory(int x, int y) => _landingArea[x, y];

        public string AskLanding(int x, int y)
        {
            if (_landingArea[x, y] == Constants.ok)
            {
                BookLanding(x, y);
                return Constants.ok;
            }

            return CheckTrajectory(x, y);
        }
        #endregion

        #region private methods
        private void InitLandingArea()
        {
            for (var x = 0; x <= 100; x++)
            {
                for (var y = 0; y <= 100; y++)
                {
                    _landingArea[x, y] = Constants.outPlatform;
                }
            }
        }

        private void InitLandingPlatform()
        {
            var platformXLenght = int.Parse(_configuration.GetSection("LandingPlatform:Size:X").Value);
            var platformYLenght = int.Parse(_configuration.GetSection("LandingPlatform:Size:Y").Value);

            for (var x = 0; x <= platformXLenght - 1; x++)
            {
                for (var y = 0; y <= platformYLenght - 1; y++)
                {
                    _landingArea[5 + x, 5 + y] = Constants.ok;
                }
            }
        }

        private void BookLanding(int x, int y)
        {
            for (var yAux = y + 1; yAux > y - 2; yAux--)
            {
                for (var xAux = x + 1; xAux > x - 2; xAux--)
                {
                    try
                    {
                        if (_landingArea[xAux, yAux] != Constants.outPlatform)
                        {
                            _landingArea[xAux, yAux] = Constants.clash;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // prevents adding value out of the landing area
                        continue;
                    }
                }
            }
        }
        #endregion
    }
}
