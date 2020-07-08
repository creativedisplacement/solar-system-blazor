namespace SolarSystem.Common
{
    public abstract class BaseDetailedItem : BaseItem
    {
        public string Description { get; set; }
        public double Density { get; set; }
        public double Tilt { get; set; }
        public double RotationPeriod { get; set; }
        public double Period { get; set; }
        public int Radius { get; set; }
        public int Moons { get; set; }
        public double Au { get; set; }
        public double Eccentricity { get; set; }
        public double Velocity { get; set; }
        public double Mass { get; set; }
        public double Inclination { get; set; }
        public string Type { get; set; }
    }
}