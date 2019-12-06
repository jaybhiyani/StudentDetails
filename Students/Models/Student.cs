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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SId { get; set; }
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        //public Department Department { get; set; }
    }
}
