using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class SingleTaskModel
    {
        public int Id { get; set; }
        public bool Checkbox { get; set; }
        
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Describe your task")]
        public string Descript { get; set; }
    }
}
