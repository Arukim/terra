using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terra.BLL.Interfaces;
using Terra.Models;

namespace Terra.BLL.Services
{
    ///Naive implementation to test libraries linking and DI
    public class GameServersHub : IGameServersHub
    {
        private Dictionary<string, GameServerModel> _servers;
        
        public GameServersHub()
        {
            _servers = new Dictionary<string, GameServerModel>();
            Task.Run(() => CleanUp());
        }
        
        async Task CleanUp(){
            while(true){
                await Task.Delay(1000);
                var now = DateTime.Now;
                var toDelete = new List<string>();
                foreach(var entry in _servers){
                    if(now.Subtract(entry.Value.LastUpdate).TotalMinutes > 1){
                        toDelete.Add(entry.Key);
                    }                    
                }
                lock(_servers){
                    toDelete.ForEach(x => _servers.Remove(x));
                }
            }
        }

        public void Add(GameServerModel gs)
        {
            if(gs == null || string.IsNullOrEmpty(gs.Type) || gs.Uri == null)
                throw new ArgumentException("Empty model");
                
            var key = $"{gs.Type}_{gs.Uri.AbsoluteUri}";
            gs.LastUpdate = DateTime.Now;
            lock(_servers){
                _servers[key] = gs;
            }
        }

        public List<GameServerModel> GetAll()
        {
            return _servers.Values.ToList();
        }
        
    }
}
