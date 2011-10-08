using System;

namespace prisonersdilemma.players {
    class RandomPlayer : Player {
        private Random random;

        public string GetName() {
            return "RandomPlayer";
        }

        public void Initialize() {
            random = new Random();
        }

        public PlayResult Play(Player opponent) {
            int r = random.Next(1, 100);
            if (r % 2 == 0) {
                return PlayResult.Cooperate;
            } else {
                return PlayResult.Defect;
            }
        }

        public void Notify(Match match) { }
    }
}
