using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using roleDemo.Data;
using roleDemo.Repositories;
using roleDemo.ViewModels;

namespace roleDemo.Controllers
{
    [Authorize(Roles = "Manager, Admin")]
    public class InvoiceController : Controller
    {
        ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            InvoiceRepo allInvoiceRepo = new InvoiceRepo(_context);
            var invoices = allInvoiceRepo.All();
            return View(invoices);
        }

        [HttpGet]
        public IActionResult Create(string username)
        {
            ViewBag.SelectedUser = username;

            InvoiceRepo invoRepo = new InvoiceRepo(_context);

            var users = invoRepo.GetAllUsers().ToList();

            var preUsersList = users.Select(us =>
                new SelectListItem { Value = us.UserName, Text = us.UserName }).ToList();

            var userList = new SelectList(preUsersList, "Value", "Text");


            ViewBag.UserSelectList = userList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(InvoiceVM inVM)
        {
            if (ModelState.IsValid)
            {
                InvoiceRepo inVMRepo = new InvoiceRepo(_context);
                var success = inVMRepo.Create(inVM);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Error = "An error occurred while creating this invoice. Please try again.";
            return View();
        }

        public IActionResult Delete(int id)
        {

            InvoiceRepo deleteInvoiceRepo = new InvoiceRepo(_context);

            var success = deleteInvoiceRepo.Delete(id);

            if (success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "An error occurred while deleting this invoice. Please try again.";
            return View();
        }
    }
}