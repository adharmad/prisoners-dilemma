using System;

namespace prisonersdilemma {
    interface Player {
        void Initialize();
        string GetName();
        PlayResult Play(Player opponent);
        void Notify(Match match);
    }
}
