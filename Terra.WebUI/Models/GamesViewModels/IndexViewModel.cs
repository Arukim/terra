using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terra.Models;

namespace Terra.WebUI.Models.GamesViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<GameServerModel> GameServers {get;set;}
    }
}
