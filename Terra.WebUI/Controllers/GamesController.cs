using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Terra.BLL.Interfaces;
using Terra.WebUI.Models.GamesViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Terra.WebUI.Controllers
{
    public class GamesController : Controller
    {
        private IGameServersHub _gameServersHub;
        
        public GamesController(IGameServersHub gameServersHub){
            _gameServersHub = gameServersHub;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.GameServers = _gameServersHub.GetAll();
            return View(model);
        }
    }
}
