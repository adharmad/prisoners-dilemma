using System;
using System.Collections;
using System.Collections.Generic;

using PD;

namespace PD.Players {
    // remembers defection and always defects against that player
    class Vindictive : Player {
        private List<string> playersWhoDefected;
            
        public string GetName() {
            return "Vindictive";
        }

        public void Initialize() { 
            playersWhoDefected = new List<string>();
        }

        public PlayResult Play(Player opponent) {
            if (playersWhoDefected.Contains(opponent.GetName())) {
                return PlayResult.Defect;
            }

            // else cooperate
            return PlayResult.Cooperate;
        }

        public void Notify(Match match) {
            Player opp = match.GetOpponent(this);
            if (match.GetResult(opp.GetName()) == PlayResult.Defect) {
                playersWhoDefected.Add(opp.GetName());
            }
        }
    }
}
