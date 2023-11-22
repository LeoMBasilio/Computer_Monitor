using System.ComponentModel.DataAnnotations;

namespace Computer_Monitor.Models
{
    internal class Usuarios
    {
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string usuario { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 12)]
        public string senha { get; set; }
        [Required]
        public bool session { get; set; }
        [Required]
        public bool terms { get; set; }
    }
}
