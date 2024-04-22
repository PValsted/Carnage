using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    public class Game
    {
        int day = 1, players = 24, funValue, activePlayers = 24, events=0, bloodbathDeaths=0, arenaEventDeaths=0, feastDeaths=0;
        string mode="Classic";
        bool isBloodbath = true, isEvent = false, isFeast= false, isActive= true, isDay= true, isDeath= false, hadFeast= false, doFullBattles= true, showCombatLevel=false, doSponsor=true;
        RNG rng = new();

        public Game() 
        {
            FunValue = rng.funValue();
        }
        
        public Game(int players) 
        { 
            this.players = players;
            FunValue = rng.funValue();
        }

        public Game(int players, string mode)
        {
            this.players = players;
            this.Mode = mode;
            FunValue = rng.funValue();
        }

        public int Day { get => day; set => day = value; }
        public int Players { get => players; set => players = value; }
        public bool IsBloodbath { get => isBloodbath; set => isBloodbath = value; }
        public bool IsEvent { get => isEvent; set => isEvent = value; }
        public bool IsFeast { get => isFeast; set => isFeast = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int ActivePlayers 
        { 
            get => activePlayers;
            set 
            {
                if (value > 0) activePlayers = value;
                else activePlayers = 1;
            }
        }

        public bool IsDay { get => isDay; set => isDay = value; }
        public bool IsDeath { get => isDeath; set => isDeath = value; }
        public int FunValue { get => funValue; set => funValue = value; }
        public bool HadFeast { get => hadFeast; set => hadFeast = value; }
        public int Events { get => events; set => events = value; }
        public string Mode { get => mode; set => mode = value; }
        public bool DoFullBattles { get => doFullBattles; set => doFullBattles = value; }
        public bool ShowCombatLevel { get => showCombatLevel; set => showCombatLevel = value; }
        public int BloodbathDeaths { get => bloodbathDeaths; set => bloodbathDeaths = value; }
        public int ArenaEventDeaths { get => arenaEventDeaths; set => arenaEventDeaths = value; }
        public int FeastDeaths { get => feastDeaths; set => feastDeaths = value; }
        public bool DoSponsor { get => doSponsor; set => doSponsor = value; }
    }
}
