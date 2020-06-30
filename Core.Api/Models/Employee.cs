using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }


        public double Age { get; set; }



        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }

    }
}
