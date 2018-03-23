using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTaskWebApplication.ViewModels
{
    public class ChangeNameViewModel
    {
        public string CurrentName { get; set; }

        [Required]
        [RegularExpression(@"^[а-яА-Я]+$", ErrorMessage = "Можно использовать только русские буквы")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
    }
}