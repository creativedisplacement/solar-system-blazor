using System.ComponentModel.DataAnnotations;

namespace SolarSystem.Common
{
    public class BaseBasicItem : BaseItem
    {
        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
                [MinLength(10)]
                [StringLength(150)]
        public string ImageUrl { get; set; }
        
        [Required]
        [MinLength(10)]
        [StringLength(150)]
        public string Introduction { get; set; }
        public int Ordinal { get; set; }
    }
}