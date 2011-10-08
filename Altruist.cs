using System;
using System.Collections;

namespace prisonersdilemma.players {
    // always plays nice
    class Altruist : Player {
        public string GetName() {
            return "Altruist";
        }

        public void Initialize() { }

        public PlayResult Play(Player opponent) {
            return PlayResult.Cooperate;
        }

        public void Notify(Match match) { }
    }
}
