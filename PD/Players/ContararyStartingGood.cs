using System;
using System.Collections;
using System.Collections.Generic;

using PD;

namespace PD.Players {
    // starts with good. then switches to bad when the opponent defects.
    // keeps bad until the opponent switches to good
    class ContararyStartingGood : Player {
        private Hashtable playerLastAction;
            
        public string GetName() {
            return "ContararyStartingGood";
        }

        public void Initialize() { 
            playerLastAction = new Hashtable();
        }

        public PlayResult Play(Player opponent) {
            if (playerLastAction.ContainsKey(opponent.GetName())) {
                PlayResult lastAction = (PlayResult)playerLastAction[opponent.GetName()];
                return lastAction;
            } 

            // else cooperate
            return PlayResult.Cooperate;
        }

        public void Notify(Match match) {
            Player opp = match.GetOpponent(this);
            if (playerLastAction.ContainsKey(opp.GetName())) {
                playerLastAction[opp.GetName()] = match.GetResult(opp.GetName());
            } else {
                playerLastAction.Add(opp.GetName(), match.GetResult(opp.GetName()));
            }
        }
    }
}
