using System.ComponentModel.DataAnnotations;

namespace Exercitii_laborator_18.Models
{
    internal class VehicleIdentificationCard
    {
        [Key]
        public int VehicleIdentificationCardId { get; set; }
        public int CylinderCapacity { get; set; }
        public int ManufacturingYear { get; set; }
        public string VIN { get; set; }
        public Autovehicle Autovehicle { get; set; }
    }
}