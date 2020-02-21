using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace roleDemo.ViewModels
{
    public class InvoiceVM
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Invoice Name")]
       // [Display(InvoiceDetail = "Invoice Detail")]
        public string Name { get; set; }
    //    public string InvoiceDetail { get; set; }
    }
}