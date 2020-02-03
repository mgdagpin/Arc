using Arc.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Domain.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string EmailAddress { get; set; }

        public Gender Gender { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    }
}
