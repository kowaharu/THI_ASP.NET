using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using learnX.Models;

namespace learnX.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService CustomerService;
        private readonly IMapper mapper;
        public CustomerController(ICustomerService CustomerService, IMapper mapper)
        {
            this.CustomerService = CustomerService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(CustomerService.GetCustomers());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            CustomerViewModel data = new CustomerViewModel();
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

            if (id != 0)
            {
                Customer res = CustomerService.GetCustomer(id);
                data = mapper.Map<CustomerViewModel>(res);
                if (data == null)
                {
                    return NotFound();
                }
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, CustomerViewModel data)
        {
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

            if (ModelState.IsValid)
            {
                try
                {
                    Customer res = mapper.Map<Customer>(data);
                    if (id != 0)
                    {
                        CustomerService.UpdateCustomer(res);
                    }
                    else
                    {
                        CustomerService.InsertCustomer(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Customer");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Customer res = CustomerService.GetCustomer(id);
            CustomerService.DeleteCustomer(res);

            return RedirectToAction("Index", "Customer");
        }
    }
}
