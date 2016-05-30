using System;

namespace Terra.Models{    
    public class GameServerModel {
        public string Title {get;set;}
        public string Description {get;set;}
        public string Type {get;set;}
        public Uri Uri {get;set;}
        public DateTime LastUpdate {get;set;}
    }
}