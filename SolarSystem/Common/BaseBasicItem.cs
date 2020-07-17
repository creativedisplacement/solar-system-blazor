using System;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.Common
{
    public class BaseBasicItem : BaseItem
    {
        [Required]
        [MinLength(3)]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(10)]
        [StringLength(150)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [MinLength(10)]
        [StringLength(150)]
        public string Introduction { get; set; } = string.Empty;
        public int Ordinal { get; set; }
    }
}