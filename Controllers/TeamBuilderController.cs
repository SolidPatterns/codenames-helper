using System;
using System.Linq;
using CodeNamesHelper.Extensions;
using CodeNamesHelper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeNamesHelper.Controllers
{
    public class TeamBuilderController : Controller
    {
        private static volatile CodeNamesContext _codeNamesContext = new CodeNamesContext();
        
        public IActionResult Index()
        {
            return View(_codeNamesContext);
        }

        [HttpPost]
        public IActionResult Add(String playerName)
        {
            AddPlayer(playerName);

            return View("Index", _codeNamesContext);
        }

        [HttpGet]
        public IActionResult Generate()
        {
            if (_codeNamesContext.Players.Count <= 3)
            {
                ViewData["Message"] = "You must enter at least 4 players.";
                return View("Index", _codeNamesContext);
            }


            GenerateTeams();

            return View("Index", _codeNamesContext);
        }

        [HttpGet]
        public IActionResult Reset()
        {
            _codeNamesContext = new CodeNamesContext();
            return View("Index", _codeNamesContext);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var playerToDelete = _codeNamesContext.Players.FirstOrDefault(x => x.Id.Equals(id));
            _codeNamesContext.Players.Remove(playerToDelete);
            return View("Index", _codeNamesContext);
        }

        private static void GenerateTeams()
        {
            _codeNamesContext.ResetTeams();
            _codeNamesContext.Players.Shuffle();
            var teamPicker = new Random();
            var pickedTeam = teamPicker.Next(0, 2);
            var teamType = pickedTeam == 0 ? TeamType.Red : TeamType.Blue;

            for (var i = 0; i < _codeNamesContext.Players.Count; i++)
            {
                var isEven = i%2 == 0;
                var teamToAddPlayer = isEven
                    ? _codeNamesContext.GetTeamByType(teamType)
                    : _codeNamesContext.GetOtherTeamByType(teamType);

                var playerToAdd = _codeNamesContext.Players[i];

                playerToAdd.Role = teamToAddPlayer.Players.Count == 0 ? RoleType.Master : RoleType.Agent;

                teamToAddPlayer.Players.Add(playerToAdd);
            }
        }

        private static void AddPlayer(string playerName)
        {
            var lastPlayer = _codeNamesContext.Players.LastOrDefault();

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

            _codeNamesContext.Players.Add(newPlayer);
        }
    }
}
