using System;
using System.Collections;

namespace prisonersdilemma.players {
    // remembers the last match result and acts accordingly
    class TitForTat : Player {
        private Hashtable lastResult;
            
        public string GetName() {
            return "TitForTat";
        }

        public void Initialize() { 
            lastResult = new Hashtable();
        }

        public PlayResult Play(Player opponent) {
            if (lastResult.ContainsKey(opponent.GetName())) {
                PlayResult pr = (PlayResult)lastResult[opponent.GetName()];

                return pr;
            }

            // else cooperate
            return PlayResult.Cooperate;
        }

        public void Notify(Match match) {
            Player opp = match.GetOpponent(this);
            lastResult[opp.GetName()] = match.GetResult(opp.GetName());
            
        }
    }
}
