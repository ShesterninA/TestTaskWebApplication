using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTaskWebApplication.ViewModels
{
    public class ChangeLastNameViewModel
    {
        public string CurrentLastName { get; set; }

        [Required]
        [RegularExpression(@"^[а-яА-Я]+$", ErrorMessage = "Можно использовать только русские буквы")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}