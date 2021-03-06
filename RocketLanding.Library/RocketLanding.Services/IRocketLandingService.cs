namespace RocketLanding.Services
{
    public interface IRocketLandingService
    {
        /// <summary>
        /// Check if the trajectory is correct
        /// </summary>
        /// <param name="x">X axis</param>
        /// <param name="y">Y axis</param>
        /// <returns></returns>
        string CheckTrajectory(int x, int y);

        /// <summary>
        /// Book a position for landing
        /// </summary>
        /// <param name="x">X axis</param>
        /// <param name="y">Y axis</param>
        /// <returns></returns>
        string AskLanding(int x, int y);
    }
}
