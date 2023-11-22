using System;
using System.ComponentModel.DataAnnotations;

namespace Computer_Monitor.Models
{
    internal class Informacoes
    {
        [Key]
        [Required]
        public string usuario { get; set; }
        [Required]
        public int pingMax { get; set; }
        [Required]
        public int pingMin { get; set; }
        [Required]
        public int porcentCpu { get; set; }
        [Required]
        public int porcentRam { get; set; }
        [Required]
        public int porcentHd { get; set; }
        [Required]
        public bool conexao { get; set; }
        [Required]
        public DateTime data { get; set; }
    }
}
