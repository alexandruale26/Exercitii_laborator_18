using System.ComponentModel.DataAnnotations;

namespace Exercitii_laborator_18.Models
{
    internal class Autovehicle
    {
        [Key]
        public int AutovehicleId { get; set; }
        public string Name { get; set; }
        public VehicleIdentificationCard? VehicleIdentificationCard { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public List<Key> Keys { get; set; } = new List<Key>();
    }
}
