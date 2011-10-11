using System;
using System.Collections;

using PD;

namespace PD.Players {
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
