using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models.RegisterModels
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "İsim")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Email Adresi Giriniz..")]
        public string Email { get; set; }

        [Display(Name = "Şifre ")]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "Şifre Tekrarı")]
        [Compare(nameof(Password), ErrorMessage = "Şifreniz uyuşmuyor.")]
        public string RepeatPassword { get; set; }

        [Required]

        public string PhoneNumber { get; set; }


        [Required]
        [Display(Name = "Adres")]
        [MinLength(15)]
        public string Address { get; set; }

        public string Token { get; set; }

        [Required]

        public bool IsAcceptContract { get; set; }

        public bool IsReceiveNews { get; set; }


    }
}
