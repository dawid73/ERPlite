using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace erplite.Models
{
    /**
     * Klasa opisująca pojedyńczego kontrahenta 
     */
    public class NewContractorClass
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Prosze wpisac nazwe ! ")]
        [Display(Name ="Nazwa")]
        public String name { get; set; }

        [Required(ErrorMessage = "Prosze wpisac ulice ! ")]
        [Display(Name = "Ulica")]
        public String street { get; set; }

        [Required(ErrorMessage = "Prosze wpisac numer domu / mieszkania ! ")]
        [Display(Name = "Numer domu / mieszkania")]
        public String house_number { get; set; }

        [Required(ErrorMessage = "Prosze wpisać miejscowość ! ")]
        [Display(Name = "Miejscowość")]
        public String resort { get; set; }

        [Required(ErrorMessage = "Prosze wpisać kod pocztowy ! ")]
        [Display(Name = "Kod pocztowy")]
        public String zip_code { get; set; }

        
        [Display(Name = "NIP")]
        public int nip { get; set; }

        [Display(Name = "PESEL")]
        public int pesel { get; set; }

        [Display(Name = "E-mail")]
        public String email { get; set; }

        [Display(Name = "Informacje dodatkowe")]
        public String addition { get; set; }











        
    }
}
