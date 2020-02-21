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
            _context = context;
        }

        public IEnumerable<InvoiceVM> All()
        {
            var invoices = _context.Invoices.Select(inv => new InvoiceVM()
            {
                InvoiceID = inv.InvoiceID,
                Created = inv.Created,
                Total = inv.Total,
                UserName = inv.UserName
            });

            return invoices;
        }

        public List<InvoiceVM> GetAllUsers()
        {
            var users = _context.CustomUsers;
            List<InvoiceVM> usersList = new List<InvoiceVM>();

            foreach (var user in users)
            {
                usersList.Add(new InvoiceVM() { UserName = user.UserName });
            }
            return usersList;
        }

        public CustomUser GetUserName(string username)
        {
            var userFound = _context.CustomUsers.Where(cu => cu.UserName == username).FirstOrDefault();

            if (userFound != null)
            {
                return userFound;
            }

            return null;
        }

        public bool Create(InvoiceVM invoice)
        {
            try
            {
                var userName = GetUserName(invoice.UserName);

                _context.Invoices.Add(new InvoiceVM
                {
                    UserName = userName.UserName,
                    Created = DateTime.Now,
                    Total = invoice.Total
                });

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                InvoiceVM removeInvoice = _context.Invoices.Where(inv => inv.InvoiceID == id).FirstOrDefault();
                _context.Invoices.Remove(removeInvoice);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
