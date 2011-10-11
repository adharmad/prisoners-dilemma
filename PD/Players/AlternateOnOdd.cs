using System;

using PD;

namespace PD.Players {
    // good for 1, bad for next 3, good for next 5,
    // bad for next 9 etc.
    class AlternateOnOdd : Player {
        private int current;
        private int countDown;
        private PlayResult strategy;

        public string GetName() {
            return "AlternateOnOdd";
        }

        public void Initialize() {
            current = 1;
            countDown = 1;
            strategy = PlayResult.Cooperate;
        }

        public PlayResult Play(Player opponent) {
            return strategy;
        }

        public void Notify(Match match) { 
            countDown--;
            if (countDown == 0) {
                current += 2; // get next odd
                countDown = current;

                // switch strategy
                if (strategy == PlayResult.Cooperate) {
                    strategy = PlayResult.Defect;
                } 
                
                if (strategy == PlayResult.Defect) {
                    strategy = PlayResult.Cooperate;
                }
            }
        }
    }
}
