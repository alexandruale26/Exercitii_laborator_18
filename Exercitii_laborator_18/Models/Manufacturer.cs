using System.ComponentModel.DataAnnotations;

namespace Exercitii_laborator_18.Models
{
    internal class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}