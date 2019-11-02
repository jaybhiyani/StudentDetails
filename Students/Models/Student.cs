using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(2)")]
        public string Department { get; set; }
    }
}
