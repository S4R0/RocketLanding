namespace RocketLanding.Services
{
    public class RocketLandingService : IRocketLandingService
    {
        private static string[,] _landingArea = new string[101, 101];

        public RocketLandingService()
        {
            InitLandingArea();
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
        #endregion
    }
}
