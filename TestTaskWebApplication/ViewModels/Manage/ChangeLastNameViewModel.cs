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
        //preg_match("/^\s*[A-ZА-Я][a-zа-я]+('[a-zа-я]+|-[A-ZА-Я][a-zа-я]+)?\s*$/",$name);
        [Required]
        [RegularExpression(@"^[а-яА-Я]+$", ErrorMessage = "Можно использовать только русские буквы")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}