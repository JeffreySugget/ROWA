using System;
using System.ComponentModel.DataAnnotations;

namespace rowa.repository.Entities
{
    public class PerformanceLog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ServerName { get; set; }

        [Required]
        [StringLength(500)]
        public string Uri { get; set; }

        [Required]
        [StringLength(200)]
        public string Controller { get; set; }

        [Required]
        [StringLength(200)]
        public string Method { get; set; }

        public double ExecutionTime { get; set; }

        public DateTime? RequestDate { get; set; }

        public string IpAddress { get; set; }
    }
}
