using System;
using System.ComponentModel.DataAnnotations;

namespace rowa.repository.Entities
{
    public class ErrorLogging
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string StackTrace { get; set; }

        public DateTime LogDate { get; set; }

        public bool IsInner { get; set; }

        public int ParentId { get; set; }

        public string Server { get; set; }
    }
}
