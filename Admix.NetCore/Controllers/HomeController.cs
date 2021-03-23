using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Admix.NetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Admix.NetCore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public HomeController(ILogger<HomeController> logger,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            //TODO:PESQUISAR MODEL LOG
            if (_signInManager.IsSignedIn(User)) return Redirect("Dashboard/");
            return Redirect("~/Identity/Account/Login");
        }

    }
}