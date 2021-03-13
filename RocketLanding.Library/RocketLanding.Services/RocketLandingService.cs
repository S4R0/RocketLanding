namespace RocketLanding.Services
{
    public class RocketLandingService : IRocketLandingService
    {
        private static string[,] _landingArea = new string[101, 101];

        public RocketLandingService()
        {
            InitLandingArea();
            InitLandingPlatform();
        }

        #region public methods
        public string CheckTrajectory(int x, int y) => _landingArea[x, y];
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
            var platformXLenght = 10;
            var platformYLenght = 10;

            for (var x = 0; x <= platformXLenght - 1; x++)
            {
                for (var y = 0; y <= platformYLenght - 1; y++)
                {
                    _landingArea[5 + x, 5 + y] = Constants.ok;
                }
            }
        }
        #endregion
    }
}
