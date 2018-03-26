using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTaskWebApplication.ViewModels
{
    public class LastNameViewModel
    {
        [Required]
        [RegularExpression(@"^[А-Я][а-я]+('[а-я]+|-[А-Я][а-я]+)?$", ErrorMessage = "Можно использовать только русские буквы")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}