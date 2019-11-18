using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Department
    {
        [Key]
        public int DId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Dep { get; set; }

        public Student Student { get; set; }
    }
}
