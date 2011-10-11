using System;
using System.Collections;
using System.Collections.Generic;

using PD;

namespace PD.Players {
    // bad until the opponent goes good
    class BadTillOpponentGoesGood : Player {
        private List<string> playersWhoCooperated;
            
        public string GetName() {
            return "BadTillOpponentGoesGood";
        }

        public void Initialize() { 
            playersWhoCooperated = new List<string>();
        }

        public PlayResult Play(Player opponent) {
            if (playersWhoCooperated.Contains(opponent.GetName())) {
                return PlayResult.Defect;
            }

            // else defect
            return PlayResult.Defect;
        }

        public void Notify(Match match) {
            Player opp = match.GetOpponent(this);
            if (match.GetResult(opp.GetName()) == PlayResult.Cooperate) {
                playersWhoCooperated.Add(opp.GetName());
            }
        }
    }
}
