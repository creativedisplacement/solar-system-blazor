using System.ComponentModel.DataAnnotations;

namespace SolarSystem.Common
{
    public abstract class BaseDetailedItem : BaseBasicItem
    {
        [Required]
        [MinLength(30)]
        [StringLength(300)]
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
        
        [Required]
        [MinLength(5)]
        [StringLength(20)]
        public string Type { get; set; }
    }
}