using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Terra.BLL.Interfaces;
using Terra.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Terra.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class GameServers : Controller
    {
        private IGameServersHub _gameServersHub;
        
        public GameServers(IGameServersHub gameServersHub){
            _gameServersHub = gameServersHub;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<GameServerModel> Get()
        {
            return _gameServersHub.GetAll();
        }
        
        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]GameServerModel gs)
        {
            _gameServersHub.Add(gs);
        }
    }
}
