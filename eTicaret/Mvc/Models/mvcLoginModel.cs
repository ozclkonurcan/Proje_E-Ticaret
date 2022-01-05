using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcLoginModel
    {
        [Key]
        public int K_ID { get; set; }
        [Required(ErrorMessage = "Devam etmek için kullanıcı adı gir")]
        public string kullaniciAdi { get; set; }
        [Required(ErrorMessage = "Devam etmek için sifre adı gir")]
        public string kullaniciPassword { get; set; }
        public string kullaniciAdiSoyadi { get; set; }
        public string kullaniciEmail { get; set; }
        public string kullaniciResim { get; set; }
        public string kullaniciUnvan { get; set; }

        public string loginErrorMessage { get; set; }
    }
}