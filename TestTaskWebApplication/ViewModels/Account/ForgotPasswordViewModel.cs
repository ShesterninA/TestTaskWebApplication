﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTaskWebApplication.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}