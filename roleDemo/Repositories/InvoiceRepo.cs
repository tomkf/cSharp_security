using Microsoft.AspNetCore.Identity;
using roleDemo.Data;
using roleDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roleDemo.Repositories
{
    public class InvoiceRepo
    {
        ApplicationDbContext _context;

        public InvoiceRepo(ApplicationDbContext context)
        {
            this._context = context;
            var invoicesCreated = CreateInitialInvoices();
        }

        public List<ViewModels.InvoiceVM> GetAllInvoices()
        {
            var invoices = _context.Invoices;
            List<ViewModels.InvoiceVM> invoiceList = new List<ViewModels.InvoiceVM>();

            foreach (var item in invoices)
            {
                invoiceList.Add(new ViewModels.InvoiceVM() { UserName = item.UserName, InvoiceID = item.InvoiceID });
            }
            return invoiceList;
        }

        public ViewModels.InvoiceVM GetInvoice(string invoiceName)
        {
            var invoice = _context.Invoices.Where(r => r.UserName == invoiceName).FirstOrDefault();
            if (invoice != null)
            {
                return new ViewModels.InvoiceVM() { UserName = invoice.UserName, InvoiceID = invoice.InvoiceID };
            }
            return null;
        }

        public bool CreateInvoice(string invoiceName)
        {
            var invoice = GetInvoice(invoiceName);
            if (invoice != null)
            {
                return false;
            }
            _context.Invoices.Add(new Data.InvoiceVM
            {
                UserName = invoiceName,
                Id = invoiceName
            });
            _context.SaveChanges();
            return true;
        }

        public bool CreateInitialInvoices()
        {
            // Create invoices if none exist.
            // This is a simple way to do it but it would be better to use a seeder.
            string[]invoiceNames = { "Internal", "Sales", "Quarter 2" };
            foreach (var invoiceName in invoiceNames)
            {
                var created = CreateInvoice(invoiceName);
                // Role already exists so exit.
                if (!created)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
