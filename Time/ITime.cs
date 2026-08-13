namespace IceFebruary.Time
{
    /// <summary>
    /// Core time management interface. Controls execution of regular and fixed update frames.
    /// </summary>
    public interface ITime : IBaseEntity
    {
        /// <summary>
        /// Total elapsed game time in seconds since system startup.
        /// </summary>
        float CurrentTime { get; }

        /// <summary>
        /// Fixed time step duration specifically for fixed updates.
        /// </summary>
        float FixedFrameRate { get; set; }

        /// <summary>
        /// Registers and launches a frame update listener.
        /// </summary>
        void LaunchIFrame(IFrame frame);

        /// <summary>
        /// Registers and launches a fixed frame update listener.
        /// </summary>
        void LaunchIFixedFrame(IFixedFrame fixedFrame);

        /// <summary>
        /// Processes a single regular frame iteration.
        /// </summary>
        void DoFrame(float frameLength);

        /// <summary>
        /// Processes a single fixed frame tick step.
        /// </summary>
        void DoFixedFrame();
    }
}
