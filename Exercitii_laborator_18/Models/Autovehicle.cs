using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercitii_laborator_18.Models
{
    internal class Autovehicle
    {
        [Key]
        public int AutovehicleId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Manufacturer")]
        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public List<Key> Keys { get; set; } = new List<Key>();

        [ForeignKey("VehicleIdentificationCard")]
        public int? VehicleIdentificationCardId { get; set; }
        public VehicleIdentificationCard? VehicleIdentificationCard { get; set; }
    }
}
