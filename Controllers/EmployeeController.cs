using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ODC_Task2__MVC_.Data.IServices;
using ODC_Task2__MVC_.Models;
using ODC_Task2__MVC_.ViewModel;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace ODC_Task2__MVC_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpService _service;
        private readonly IMapper _mapper;
        private readonly IEmailSender emailSender;
        public EmployeeController(IEmpService service, IMapper mapper,IEmailSender sender)
        {
            _service = service;
            emailSender= sender;
            _mapper = mapper;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}




        


            [HttpGet]
            public IActionResult Index()
            {
                
                
                    var model = _service.Get();
                    var data = _mapper.Map<IEnumerable<EmployeeVM>>(model);
                    return View(data);
                
                
            }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var obj = _mapper.Map<Employee>(emp);


                     _service.Create(obj);
                    emailSender.SendEmailAsync(emp.Email, "Vrification sent to your email", $"<h1> congrats{emp.Name}</h1>");

                }
                return RedirectToAction(nameof(SubmitInfo));
                


                

                
                

            }
            catch (Exception ex)
            {
                

                return View(emp);
            }





        }

        public async Task<IActionResult> SubmitInfo()
        {
            

            return View("SubmitCompleted");


        }

        public IActionResult Delete(int id)
        {

            var model = _service.GetById(id);
            var data = _mapper.Map<EmployeeVM>(model);
            
            
            return View(data);
        }



    }
}
