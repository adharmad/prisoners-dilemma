using System;
using System.Collections;

using PD;

namespace PD.Players {
    // always plays evil
    class Evil : Player {
        public string GetName() {
            return "Evil";
        }

        public void Initialize() { }

        public PlayResult Play(Player opponent) {
            return PlayResult.Defect;
        }

        public void Notify(Match match) {
        }
    }
}
