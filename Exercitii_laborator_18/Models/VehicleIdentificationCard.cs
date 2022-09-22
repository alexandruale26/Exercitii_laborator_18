using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercitii_laborator_18.Models
{
    internal class VehicleIdentificationCard
    {
        [Key]
        public int VehicleIdentificationCardId { get; set; }
        public int CylinderCapacity { get; set; }
        public int ManufacturingYear { get; set; }
        public string VIN { get; set; }

        [ForeignKey("AutovehicleId")]
        public int AutovehicleId { get; set; }
        public Autovehicle Autovehicle { get; set; }
    }
}