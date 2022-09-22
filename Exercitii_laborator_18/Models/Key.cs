using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercitii_laborator_18.Models
{
    internal class Key
    {
        [Key]
        public int KeyId { get; set; }
        public Guid AccessCode { get; set; } = Guid.NewGuid();

        [ForeignKey("AutovehicleId")]
        public int AutovehicleId { get; set; }
        public Autovehicle Autovehicle { get; set; }
    }
}