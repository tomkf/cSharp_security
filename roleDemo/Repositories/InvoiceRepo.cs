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

        public List<InvoiceVM> GetAllInvoices()
        {
            var invoices = _context.Roles;
            List<InvoiceVM> invoiceList = new List<InvoiceVM>();

            foreach (var item in invoices)
            {
                invoiceList.Add(new InvoiceVM() { Name = item.Name, Id = item.Id });
            }
            return invoiceList;
        }

        public InvoiceVM GetInvoice(string invoiceName)
        {
            var invoice = _context.Roles.Where(r => r.Name == invoiceName).FirstOrDefault();
            if (invoice != null)
            {
                return new InvoiceVM() { Name = invoice.Name, Id = invoice.Id };
            }
            return null;
        }

        public bool CreateInvoice(string invoiceName)
        {
            var role = GetInvoice(invoiceName);
            if (role != null)
            {
                return false;
            }
            _context.Roles.Add(new IdentityRole
            {
                Name = invoiceName,
                Id = invoiceName,
                NormalizedName = invoiceName.ToUpper()
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
