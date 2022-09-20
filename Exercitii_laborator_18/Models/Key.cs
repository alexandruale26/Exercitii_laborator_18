using System.ComponentModel.DataAnnotations;

namespace Exercitii_laborator_18.Models
{
    internal class Key
    {
        [Key]
        public int KeyId { get; set; }
        public Guid AccessCode { get; set; } = Guid.NewGuid();
        public Autovehicle Autovehicle { get; set; }
    }
}