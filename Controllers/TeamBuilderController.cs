using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeNamesHelper.Controllers
{
    public class TeamBuilderController : Controller
    {
        List<String> players;

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(String playerName) {
            
            return View("Index");
        }
    }
}
