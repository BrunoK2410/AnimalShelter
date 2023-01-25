using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Range(minimum:0,maximum:1,ErrorMessage ="Type must be 0 or 1")]
        [Required(ErrorMessage ="You must choose Type")]
        
        public int Type { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Breed is required")]
        public string Breed { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        [Display(Name = "Gender")]
        public string Sex { get; set; }
        [Required(ErrorMessage ="Birthday is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [MaxLength(15)]
        [Required(ErrorMessage ="Microchip is required.")]
        
        public string Microchip { get; set; }
        
        [Url]
        [Display(Name="Image")]
        public string Image { get; set; }

       
        public string Description { get; set; }

        


        
    }
}
