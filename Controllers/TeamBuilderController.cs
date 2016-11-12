using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeNamesHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeNamesHelper.Controllers
{
    public class TeamBuilderController : Controller
    {
        private static volatile List<Player> _players = new List<Player>();

        public IActionResult Index()
        {
            return View(_players);
        }

        [HttpPost]
        public IActionResult Add(String playerName)
        {
            var lastPlayer = _players.LastOrDefault();

            var newId = 1;
            if (lastPlayer != null)
            {
                newId = lastPlayer.Id + 1;
            }


            var newPlayer = new Player
            {
                Id = newId,
                Name = playerName
            };

            _players.Add(newPlayer);

            return View("Index", _players);
        }
    }
}
