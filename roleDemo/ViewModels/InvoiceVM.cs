using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace roleDemo.ViewModels
{
    public class InvoiceVM
    {

        public int InvoiceID { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public decimal Total { get; set; }
    }
}