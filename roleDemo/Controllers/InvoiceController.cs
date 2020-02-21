using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roleDemo.Data;
using roleDemo.Repositories;

namespace roleDemo.Controllers
{
    public class InvoiceController : Controller
    {
        ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Role
        public ActionResult Index()
        {
            InvoiceRepo roleRepo = new InvoiceRepo(_context);
            return View(roleRepo.GetAllInvoices());
        }
    }
}