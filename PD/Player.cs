using System;

namespace PD {
    interface Player {
        void Initialize();
        string GetName();
        PlayResult Play(Player opponent);
        void Notify(Match match);
    }
}
