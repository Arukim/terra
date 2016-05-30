using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terra.Models;

namespace Terra.BLL.Interfaces
{
    public interface IGameServersHub
    {
        void Add(GameServerModel gs);
        List<GameServerModel> GetAll();
    }
}
