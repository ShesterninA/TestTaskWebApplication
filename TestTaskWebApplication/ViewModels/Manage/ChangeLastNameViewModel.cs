using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTaskWebApplication.ViewModels
{
    public class ChangeLastNameViewModel : LastNameViewModel
    {
        public string CurrentLastName { get; set; }
    }
}