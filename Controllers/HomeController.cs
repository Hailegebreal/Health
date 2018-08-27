using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProject.LeprosyModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper){

            _mapper = mapper;
        }


        // GET: /<controller>/
        public IActionResult Index(ContactViewModel vm)
        {
            var contact = _mapper.Map<Contact>(vm);
            return View();
        }
    }
}
